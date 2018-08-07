using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delaunay
{
    class Draw_Service
    {
        //method to draw points
        public static List<PointF> drawRandomPoints(Bitmap bitmap, Graphics graphics, PictureBox pictureBox, int numberOfPoints, int width, int height)
        {
            List<PointF> list = new List<PointF>();
            Random random = new Random();

            //finds coordinates of all points
            for (int i = 0; i < numberOfPoints; i++)
            {
                int x = random.Next(0, width);
                int y = random.Next(0, height);
                list.Add(new PointF(x, y));

                graphics.DrawRectangle(new Pen(Color.Black), x, y, 1, 1);
            }
            pictureBox.Image = bitmap;

            //return list of poitns
            return list;
        }

        public static void drawTriangle(Bitmap bitmap, Graphics graphics, PictureBox pictureBox, List<Triangle> list)
        {
            foreach (var triangle in list)
            {
                /*graphics.DrawRectangle(new Pen(Color.Red), triangle.p1.X, triangle.p1.Y, 1, 1);
                graphics.DrawRectangle(new Pen(Color.Red), triangle.p2.X, triangle.p2.Y, 1, 1);
                graphics.DrawRectangle(new Pen(Color.Red), triangle.p3.X, triangle.p3.Y, 1, 1);*/

                graphics.DrawLine(new Pen(Color.Red), triangle.p1, triangle.p2);
                graphics.DrawLine(new Pen(Color.Red), triangle.p2, triangle.p3);
                graphics.DrawLine(new Pen(Color.Red), triangle.p3, triangle.p1);
            }
            pictureBox.Image = bitmap;
        }
    }
}
