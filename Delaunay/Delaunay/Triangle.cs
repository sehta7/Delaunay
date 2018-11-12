using Delaunay.Model3D;
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
        //points of triangle vertices
        public PointF p1;
        public PointF p2;
        public PointF p3;
        //circumcenter of triangle
        public PointF circumcenter;
        //coefficients of each side bisector
        //p1p2
        public float a1;
        public float b1;
        //p2p3
        public float a2;
        public float b2;
        //p3p1
        public float a3;
        public float b3;

        //constructors
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

        //checks if two triangles have common side
        public static bool commonSide(Triangle t1, Triangle t2)
        {
            bool common = false;

            if (t1.p1 == t2.p1 && t1.p2 == t2.p2 || t1.p1 == t2.p2 && t1.p2 == t2.p1 ||
                t1.p1 == t2.p2 && t1.p2 == t2.p3 || t1.p1 == t2.p3 && t1.p2 == t2.p2 ||
                t1.p1 == t2.p3 && t1.p2 == t2.p1 || t1.p1 == t2.p1 && t1.p2 == t2.p3 ||
                t1.p2 == t2.p1 && t1.p3 == t2.p2 || t1.p2 == t2.p2 && t1.p3 == t2.p1 ||
                t1.p2 == t2.p2 && t1.p3 == t2.p3 || t1.p2 == t2.p3 && t1.p3 == t2.p2 ||
                t1.p2 == t2.p3 && t1.p3 == t2.p1 || t1.p2 == t2.p1 && t1.p3 == t2.p3 ||
                t1.p3 == t2.p1 && t1.p1 == t2.p2 || t1.p3 == t2.p2 && t1.p1 == t2.p1 ||
                t1.p3 == t2.p2 && t1.p1 == t2.p3 || t1.p3 == t2.p3 && t1.p1 == t2.p2 ||
                t1.p3 == t2.p3 && t1.p1 == t2.p1 || t1.p3 == t2.p1 && t1.p1 == t2.p3)
            {
                common = true;
            }

            return common;
        }

        //checks if triangle has common vertex with given point
        public bool commonVertex(PointF point)
        {
            bool common = false;

            if (point.Equals(this.p1) ||
                point.Equals(this.p2) ||
                point.Equals(this.p3))
            {
                common = true;
            }

            return common;
        }

        public void convertXY(List<PointF> list2d, List<Vector3D> list3d)
        {
            for (int i = 0; i < list3d.Count; i++)
            {
                if (this.p1.X == list3d[i].x && this.p1.Y == list3d[i].y)
                {
                    this.p1.X = list2d[i].X;
                    this.p1.Y = list2d[i].Y;
                }

                if (this.p2.X == list3d[i].x && this.p2.Y == list3d[i].y)
                {
                    this.p2.X = list2d[i].X;
                    this.p2.Y = list2d[i].Y;
                }

                if (this.p3.X == list3d[i].x && this.p3.Y == list3d[i].y)
                {
                    this.p3.X = list2d[i].X;
                    this.p3.Y = list2d[i].Y;
                }
            }

        }

        public void convertYZ(List<PointF> list2d, List<Vector3D> list3d)
        {
            for (int i = 0; i < list3d.Count; i++)
            {
                if (this.p1.X == list3d[i].y && this.p1.Y == list3d[i].z)
                {
                    this.p1.X = list2d[i].X;
                    this.p1.Y = list2d[i].Y;
                }

                if (this.p2.X == list3d[i].y && this.p2.Y == list3d[i].z)
                {
                    this.p2.X = list2d[i].X;
                    this.p2.Y = list2d[i].Y;
                }

                if (this.p3.X == list3d[i].y && this.p3.Y == list3d[i].z)
                {
                    this.p3.X = list2d[i].X;
                    this.p3.Y = list2d[i].Y;
                }
            }

        }

        public void convertZX(List<PointF> list2d, List<Vector3D> list3d)
        {
            for (int i = 0; i < list3d.Count; i++)
            {
                if (this.p1.X == list3d[i].z && this.p1.Y == list3d[i].x)
                {
                    this.p1.X = list2d[i].X;
                    this.p1.Y = list2d[i].Y;
                }

                if (this.p2.X == list3d[i].z && this.p2.Y == list3d[i].x)
                {
                    this.p2.X = list2d[i].X;
                    this.p2.Y = list2d[i].Y;
                }

                if (this.p3.X == list3d[i].z && this.p3.Y == list3d[i].x)
                {
                    this.p3.X = list2d[i].X;
                    this.p3.Y = list2d[i].Y;
                }
            }

        }

        public void convert(PointF temp, PointF current)
        {
            if (this.p1.X == temp.X && this.p1.Y == temp.Y)
            {
                this.p1.X = current.X;
                this.p1.Y = current.Y;
            }

            if (this.p2.X == temp.X && this.p2.Y == temp.Y)
            {
                this.p2.X = current.X;
                this.p2.Y = current.Y;
            }

            if (this.p3.X == temp.X && this.p3.Y == temp.Y)
            {
                this.p3.X = current.X;
                this.p3.Y = current.Y;
            }
        }
    }
}
