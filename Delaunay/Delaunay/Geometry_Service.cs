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

        //count new coordinates of triangle vertex - Laplace smoothing
        public static void movingTriangle(PointF point, List<Triangle> triangleList, ref float x, ref float y)
        {
            float xSum = 0;
            float ySum = 0;
            int vertex = 0;
            int n = 0;

            for (int i = 0; i < triangleList.Count; i++)
            {
                //looking for triangles with common vertex
                if (Triangle.commonVertex(point, triangleList[i], ref vertex))
                {
                    if (vertex == 1)
                    {
                        xSum = triangleList[i].p2.X + +triangleList[i].p3.X;
                        ySum = triangleList[i].p2.Y + +triangleList[i].p3.Y;
                    }
                    else if (vertex == 2)
                    {
                        xSum = triangleList[i].p1.X + +triangleList[i].p3.X;
                        ySum = triangleList[i].p1.Y + +triangleList[i].p3.Y;
                    }
                    else if (vertex == 3)
                    {
                        xSum = triangleList[i].p1.X + +triangleList[i].p2.X;
                        ySum = triangleList[i].p1.Y + +triangleList[i].p2.Y;
                    }

                    //count number of triangles
                    n++;
                }
            }
            //counting new coordinates
            x = xSum / (n * 2);
            y = ySum / (n * 2);
        }

        public static bool inCircle(PointF p, Triangle t)
        {
            if (System.Math.Abs(t.p1.Y - t.p2.Y) < double.Epsilon && System.Math.Abs(t.p2.Y - t.p3.Y) < double.Epsilon)
            {
                //INCIRCUM - F - Points are coincident !!
                return false;
            }

            float m1, m2;
            float mx1, mx2;
            float my1, my2;
            float xc, yc;

            if (System.Math.Abs(t.p2.Y - t.p1.Y) < double.Epsilon)
            {
                m2 = -(t.p3.X - t.p2.X) / (t.p3.Y - t.p2.Y);
                mx2 = (t.p2.X + t.p3.X) * 0.5f;
                my2 = (t.p2.Y + t.p3.Y) * 0.5f;
                //Calculate CircumCircle center (xc,yc)
                xc = (t.p2.X + t.p1.X) * 0.5f;
                yc = m2 * (xc - mx2) + my2;
            }
            else if (System.Math.Abs(t.p3.Y - t.p2.Y) < double.Epsilon)
            {
                m1 = -(t.p2.X - t.p1.X) / (t.p2.Y - t.p1.Y);
                mx1 = (t.p1.X + t.p2.X) * 0.5f;
                my1 = (t.p1.Y + t.p2.Y) * 0.5f;
                //Calculate CircumCircle center (xc,yc)
                xc = (t.p3.X + t.p2.X) * 0.5f;
                yc = m1 * (xc - mx1) + my1;
            }
            else
            {
                m1 = -(t.p2.X - t.p1.X) / (t.p2.Y - t.p1.Y);
                m2 = -(t.p3.X - t.p2.X) / (t.p3.Y - t.p2.Y);
                mx1 = (t.p1.X + t.p2.X) * 0.5f;
                mx2 = (t.p2.X + t.p3.X) * 0.5f;
                my1 = (t.p1.Y + t.p2.Y) * 0.5f;
                my2 = (t.p2.Y + t.p3.Y) * 0.5f;
                //Calculate CircumCircle center (xc,yc)
                xc = (m1 * mx1 - m2 * mx2 + my2 - my1) / (m1 - m2);
                yc = m1 * (xc - mx1) + my1;
            }
            t.circumcenter = new PointF(xc, yc);
            double dx = t.p2.X - xc;
            double dy = t.p2.Y - yc;
            double rsqr = dx * dx + dy * dy;
            //double r = Math.Sqrt(rsqr); //Circumcircle radius
            dx = p.X - xc;
            dy = p.Y - yc;
            double drsqr = dx * dx + dy * dy;

            return (drsqr <= rsqr);
        }
    }
}
