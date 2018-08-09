using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay
{
    //class to store information about triangles
    class Triangle
    {
        public PointF p1;
        public PointF p2;
        public PointF p3;

        public Triangle()
        {

        }

        public Triangle(PointF p1, PointF p2, PointF p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        //checks if given triangle has common vertices with supertriangle
        public static bool belongsToSupertriangle(Triangle supertriangle, Triangle triangle)
        {
            bool belong = false;

            if (supertriangle.p1.Equals(triangle.p1) ||
                supertriangle.p1.Equals(triangle.p2) ||
                supertriangle.p1.Equals(triangle.p3) ||
                supertriangle.p2.Equals(triangle.p1) ||
                supertriangle.p2.Equals(triangle.p2) ||
                supertriangle.p2.Equals(triangle.p3) ||
                supertriangle.p3.Equals(triangle.p1) ||
                supertriangle.p3.Equals(triangle.p2) ||
                supertriangle.p3.Equals(triangle.p3))
            {
                belong = true;
            }

            return belong;
        }
    }
}
