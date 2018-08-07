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
    }
}
