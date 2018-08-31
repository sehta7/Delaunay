using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delaunay
{
    class Voronoi_Service
    {
        //method to get Voronoi diagram from Delaunay Triangulation
        //returns bisectors of triangles which have circumcenter
        public static List<Edge> DelaunayToVoronoi(List<Triangle> trianglesList)
        {
            //list of Voronoi diagram edges
            List<Edge> edgeList = new List<Edge>();

            foreach (var triangle in trianglesList)
            {
                for (int i = 0; i < trianglesList.Count; i++)
                {
                    if (Triangle.commonSide(triangle, trianglesList[i]))
                    {
                        edgeList.Add(new Edge(triangle.circumcenter, trianglesList[i].circumcenter));
                    }
                }
            }

            for (int j = edgeList.Count - 2; j >= 0; j--)
            {
                PointF zero = new PointF(0, 0);
                if (edgeList[j].p1 == zero || edgeList[j].p2 == zero || edgeList[j].p1 == edgeList[j].p2)
                {
                    edgeList.RemoveAt(j);
                    //j--;
                }
                for (int k = edgeList.Count - 1; k >= j + 1; k--)
                {
                    if (Edge.areTheSame(edgeList[j], edgeList[k]))
                    {
                        edgeList.RemoveAt(k);
                        k--;
                        continue;
                    }
                }
            }

            return edgeList;
        }
    }
}
