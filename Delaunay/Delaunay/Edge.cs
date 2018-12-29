using Delaunay.Model3D;
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

        //public void convertXY(List<PointF> list2d, List<Vector3D> list3d)
        //{
        //    for (int i = 0; i < list3d.Count; i++)
        //    {
        //        if (this.p1.X == list3d[i].x && this.p1.Y == list3d[i].y)
        //        {
        //            this.p1.X = list2d[i].X;
        //            this.p1.Y = list2d[i].Y;
        //        }

        //        if (this.p2.X == list3d[i].x && this.p2.Y == list3d[i].y)
        //        {
        //            this.p2.X = list2d[i].X;
        //            this.p2.Y = list2d[i].Y;
        //        }

        //        if (this.p3.X == list3d[i].x && this.p3.Y == list3d[i].y)
        //        {
        //            this.p3.X = list2d[i].X;
        //            this.p3.Y = list2d[i].Y;
        //        }
        //    }

        //}
    }
}
