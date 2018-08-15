using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay
{
    //class to store information about edges
    class Edge
    {
        //points of edge
        public PointF p1;
        public PointF p2;

        //constructors
        public Edge()
        {

        }

        public Edge(PointF p1, PointF p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        //checks if two edges are the same
        public static bool areTheSame(Edge e1, Edge e2)
        {
            bool same = false;

            if (e1.p1 == e2.p2 && e1.p2 == e2.p1 || e1.p1 == e2.p1 && e1.p2 ==e2.p2)
            {
                same = true;
            }

            return same;
        }
    }
}
