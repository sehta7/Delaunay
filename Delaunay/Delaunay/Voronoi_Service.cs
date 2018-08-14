using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return edgeList;
        }
    }
}
