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
            List<float> bisectorList = new List<float>();

            foreach (var triangle in trianglesList)
            {
                for (int i = 0; i < trianglesList.Count; i++)
                {
                    float x, y;
                    if (triangle.a1 != trianglesList[i].a1)
                    {
                        Geometry_Service.intersectPoint(triangle.a1, triangle.b1, trianglesList[i].a1, trianglesList[i].b1, out x, out y);
                        PointF intersect = new PointF(x, y);
                        edgeList.Add(new Edge(intersect, triangle.circumcenter));
                    }
                }
            }

            return edgeList;
        }
    }
}
