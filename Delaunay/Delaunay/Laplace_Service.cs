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
        public static List<PointF> Laplace(List<Triangle> triangleList, List<PointF> pointList)
        {
            //list of points to return
            List<PointF> list = new List<PointF>();

            //check every point
            foreach (var point in pointList)
            {
                int n = 0;
                float sumX = 0;
                float sumY = 0;

                for (int i = 0; i < triangleList.Count; i++)
                {
                    //if triangle has common vertex with point nedd to count coordinates sum
                    if (triangleList[i].commonVertex(point))
                    {
                        n++;
                        sumX += triangleList[i].p1.X + triangleList[i].p2.X + triangleList[i].p3.X - point.X;
                        sumY += triangleList[i].p1.Y + triangleList[i].p2.Y + triangleList[i].p3.Y - point.Y;
                    }
                }

                //if point has more common triangles than 3 its not on the border
                if (n > 3)
                {
                    //count the average
                    //multiple by 2 because every triangle vertices was counted twice
                    float x = sumX / (2 * n);
                    float y = sumY / (2 * n);
                    PointF toChange = new PointF(x, y);
                    list.Add(toChange);
                }
                else
                {
                    list.Add(point);
                }
            }

            return list;
        }
    }
}
