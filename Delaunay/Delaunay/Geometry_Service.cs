using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay
{
    class Geometry_Service
    {
        public static Triangle superTriangle(List<PointF> list)
        {
            float xmin = list[0].X;
            float ymin = list[0].Y;
            float xmax = xmin;
            float ymax = ymin;

            //finding the minimum and maksimum coordinates of points
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].X < xmin)
                {
                    xmin = list[i].X;
                }
                if (list[i].Y < ymin)
                {
                    ymin = list[i].Y;
                }
                if (list[i].X > xmax)
                {
                    xmax = list[i].X;
                }
                if (list[i].Y > ymax)
                {
                    ymax = list[i].Y;
                }
            }

            //distance between X's and Y's
            float xd = xmax - xmin;
            float yd = ymax - ymin;
            float maxd = (xd > yd) ? xd : yd;

            float xmid = (xmin + xmax) * 0.5f;
            float ymid = (ymin + ymax) * 0.5f;

            //triangle coordiantes
            PointF p1 = new PointF((xmid - 2 * maxd), (ymid - maxd));
            PointF p2 = new PointF(xmid, (ymid + 2 * maxd));
            PointF p3 = new PointF((xmid + 2 * maxd), (ymid - maxd));
            Triangle superTriangle = new Triangle(p1, p2, p3);

            return superTriangle;
        }

        //returns true if given point is inside the circumscribed circle
        //point is inside if radius is greater than distans between point and center of circle
        public static bool isInsideCircle(PointF toCheck, Triangle triangle)
        {
            //finds bisectors of the sides of the triangle
            float a1, b1;
            findBisector(triangle.p1, triangle.p2, out a1, out b1);
            triangle.a1 = a1;
            triangle.b1 = b1;

            float a2, b2;
            findBisector(triangle.p2, triangle.p3, out a2, out b2);
            triangle.a2 = a2;
            triangle.b2 = b2;

            float a3, b3;
            findBisector(triangle.p3, triangle.p1, out a3, out b3);
            triangle.a3 = a3;
            triangle.b3 = b3;

            //coordinates of circle center (only when line are't parallel to axis)
            float x = 0, y = 0;
            if (!float.IsInfinity(a1) && !float.IsInfinity(a2))
            {
                x = (b2 - b1) / (a1 - a2);
                y = a1 * x + b1;
            }
            else if (!float.IsInfinity(a2) && !float.IsInfinity(a3))
            {
                x = (b3 - b2) / (a2 - a3);
                y = a2 * x + b2;
            }
            else if (!float.IsInfinity(a3) && !float.IsInfinity(a2))
            {
                x = (b2 - b3) / (a3 - a2);
                y = a3 * x + b3;
            }
            triangle.circumcenter.X = x;
            triangle.circumcenter.Y = y;

            //count the distance between circle center and point
            float d = (float)Math.Sqrt(Math.Pow((toCheck.X - x), 2) + Math.Pow((toCheck.Y - y), 2));
            //coutn the radius of circle
            float ab = (float)Math.Sqrt(Math.Pow((triangle.p1.X - triangle.p2.X), 2) + Math.Pow((triangle.p1.Y - triangle.p2.Y), 2));
            float bc = (float)Math.Sqrt(Math.Pow((triangle.p2.X - triangle.p3.X), 2) + Math.Pow((triangle.p2.Y - triangle.p3.Y), 2));
            float ca = (float)Math.Sqrt(Math.Pow((triangle.p3.X - triangle.p1.X), 2) + Math.Pow((triangle.p3.Y - triangle.p1.Y), 2));
            float circuit = (ab + bc + ca) / 2;
            float area = (float)Math.Sqrt(circuit * (circuit - ab) * (circuit - bc) * (circuit - ca));
            float r = (ab * bc * ca) / (4 * area);

            //check if point is inside the circle with center in (x,y)
            if (d < r)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //count coefficients of bisector function
        public static void findBisector(PointF p1, PointF p2, out float a2, out float b2)
        {
            //eqation of line for points p1 and p2
            float a1 = (p1.Y - p2.Y) / (p1.X - p2.X);
            float b1 = p1.Y - p1.X * a1;

            //equation of bisector on p1p2
            PointF mid = new PointF(((p1.X + p2.X) * 0.5f), ((p1.Y + p2.Y) * 0.5f));
            a2 = -1 / a1;
            b2 = mid.Y - mid.X * a2;
        }

        //returns common point of two bisectors
        public static void intersectPoint(float a1, float b1, float a2, float b2, out float x, out float y)
        {
            x = (b2 - b1) / (a1 - a2);
            y = a1 * x + b1;
        }
    }
}
