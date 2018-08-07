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
            //eqation of line for points p1 and p2
            float a1 = (triangle.p1.Y - triangle.p2.Y) / (triangle.p1.X - triangle.p2.X);
            float b1 = triangle.p1.Y - triangle.p1.X * a1;
            //equation of bisector on p1p2
            PointF p1Mid = new PointF(((triangle.p1.X + triangle.p2.X) * 0.5f), ((triangle.p1.Y + triangle.p2.Y) * 0.5f));
            float a2 = -1 / a1;
            float b2 = p1Mid.Y - p1Mid.X * a2;

            //eqation of line for points p2 and p3
            float a3 = (triangle.p2.Y - triangle.p3.Y) / (triangle.p2.X - triangle.p3.X);
            float b3 = triangle.p2.Y - triangle.p2.X * a3;
            //equation of bisector on p1p2
            PointF p2Mid = new PointF(((triangle.p2.X + triangle.p3.X) * 0.5f), ((triangle.p2.Y + triangle.p3.Y) * 0.5f));
            float a4 = -1 / a3;
            float b4 = p2Mid.Y - p2Mid.X * a4;

            //coordinates of circle center
            float x = (b4 - b2) / (a2 - a4);
            float y = a2 * x + b2;

            //count the distance between circle center and point
            float d = (float)Math.Sqrt(Math.Pow((toCheck.X - x), 2) + Math.Pow((toCheck.Y - y), 2));
            //coutn the radius of circle
            float ab = (float)Math.Sqrt(Math.Pow((triangle.p1.X - triangle.p2.X), 2) + Math.Pow((triangle.p1.Y - triangle.p2.Y), 2));
            float bc = (float)Math.Sqrt(Math.Pow((triangle.p2.X - triangle.p3.X), 2) + Math.Pow((triangle.p2.Y - triangle.p3.Y), 2));
            float ca = (float)Math.Sqrt(Math.Pow((triangle.p3.X - triangle.p1.X), 2) + Math.Pow((triangle.p3.Y - triangle.p1.Y), 2));
            float circuit = ab + bc + ca;
            float r = (ab * bc * ca) / 4 * circuit;

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
    }
}
