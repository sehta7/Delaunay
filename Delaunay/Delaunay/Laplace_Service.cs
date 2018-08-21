using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay
{
    class Laplace_Service
    {
        //move vertices of triangles to smooth grid
        public static List<Triangle> Laplace(List<Triangle> triangleList)
        {
            foreach (var triangle in triangleList)
            {
                //new coordinates of triangle vertex
                float x = 0, y = 0;

                //first vertex of triangle
                Geometry_Service.movingTriangle(triangle.p1, triangleList, ref x, ref y);
                triangle.p1.X = x;
                triangle.p1.Y = y;

                //first vertex of triangle
                Geometry_Service.movingTriangle(triangle.p2, triangleList, ref x, ref y);
                triangle.p2.X = x;
                triangle.p2.Y = y;

                //first vertex of triangle
                Geometry_Service.movingTriangle(triangle.p3, triangleList, ref x, ref y);
                triangle.p3.X = x;
                triangle.p3.Y = y;
            }

            return triangleList;
        }
    }
}
