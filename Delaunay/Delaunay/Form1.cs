using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delaunay
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        List<PointF> list;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics = Graphics.FromImage(bitmap);
            list = new List<PointF>();
        }

        //drawing random points on picturebox - number of points enter by user
        private void button1_Click(object sender, EventArgs e)
        {
            list = Draw_Service.drawRandomPoints(bitmap, graphics, pictureBox1, Int32.Parse(textBox1.Text), pictureBox1.Size.Width, pictureBox1.Size.Height);
        }

        //drawing Delaunay triangulation
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
