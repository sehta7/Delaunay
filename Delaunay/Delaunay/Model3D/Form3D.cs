using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delaunay.Model3D
{
    public partial class Form3D : Form
    {
        Graphics graphics3d;
        Bitmap bitmap3d;
        float zoom;
        List<Vector3D> points3d;
        Cube cube;

        public Form3D()
        {
            InitializeComponent();
            bitmap3d = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics3d = Graphics.FromImage(bitmap3d);
            zoom = (float)Screen.PrimaryScreen.Bounds.Width / 1.5f;
            points3d = new List<Vector3D>();
        }

        private void Form3D_Paint(object sender, PaintEventArgs e)
        {
            zoom = (float)Screen.PrimaryScreen.Bounds.Width / 1.5f;

            if (cube == null)
            {
                cube = new Cube();
                cube.InitializeCube(400, 200, 250);
                Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));

                cube.count2D(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));

                pictureBox1.Image = Drawing_Service.drawingCube(cube, graphics3d, bitmap3d);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points3d = Drawing_Service.randomPoints(bitmap3d, graphics3d, pictureBox1, Int32.Parse(textBox1.Text), pictureBox1.Size.Width, pictureBox1.Size.Height, 200);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            bitmap3d = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics3d = Graphics.FromImage(bitmap3d);

            zoom = (float)Screen.PrimaryScreen.Bounds.Width / 1.5f;
            cube.xRotation(15);

            Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));

            cube.count2D(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));

            bitmap3d = Drawing_Service.drawingCube(cube, graphics3d, bitmap3d);
            pictureBox1.Image = bitmap3d;
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            bitmap3d = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics3d = Graphics.FromImage(bitmap3d);

            zoom = (float)Screen.PrimaryScreen.Bounds.Width / 1.5f;
            cube.yRotation(15);

            Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));

            cube.count2D(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));

            bitmap3d = Drawing_Service.drawingCube(cube, graphics3d, bitmap3d);
            pictureBox1.Image = bitmap3d;
            pictureBox1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            bitmap3d = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics3d = Graphics.FromImage(bitmap3d);

            zoom = (float)Screen.PrimaryScreen.Bounds.Width / 1.5f;
            cube.zRotation(15);

            Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));

            cube.count2D(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));

            bitmap3d = Drawing_Service.drawingCube(cube, graphics3d, bitmap3d);
            pictureBox1.Image = bitmap3d;
            pictureBox1.Refresh();
        }
    }
}
