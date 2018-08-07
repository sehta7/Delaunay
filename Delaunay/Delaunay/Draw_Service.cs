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
        public static List<Point> drawRandomPoints(Bitmap bitmap, Graphics graphics, PictureBox pictureBox, int numberOfPoints, int width, int height)
        {
            List<Point> list = new List<Point>();
            Random random = new Random();

            //finds coordinates of all points
            for (int i = 0; i < numberOfPoints; i++)
            {
                int x = random.Next(0, width);
                int y = random.Next(0, height);
                list.Add(new Point(x, y));

                graphics.DrawRectangle(new Pen(Color.Black), x, y, 1, 1);
            }
            pictureBox.Image = bitmap;

            //return list of poitns
            return list;
        }
    }
}
