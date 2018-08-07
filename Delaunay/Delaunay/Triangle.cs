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
    }
}
