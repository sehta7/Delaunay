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
        public static void drawRandomPoints(Bitmap bitmap, Graphics graphics, PictureBox pictureBox, int numberOfPoints, int width, int height)
        {
            Random random = new Random();

            for (int i = 0; i < numberOfPoints; i++)
            {
                int x = random.Next(0, width);
                int y = random.Next(0, height);

                graphics.DrawRectangle(new Pen(Color.Black), x, y, 1, 1);
            }
            pictureBox.Image = bitmap;
        }
    }
}
