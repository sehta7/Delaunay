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
        List<PointF> points2d;
        Cube cube;
        List<Triangle> trianglesXY;
        List<Triangle> trianglesYZ;
        List<Triangle> trianglesZX;
        List<Edge> edgesXY;
        List<Edge> edgesYZ;
        List<Edge> edgesZX;
        List<Tetrahedra> tetrahedras;

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
            //zoom = (float)Screen.PrimaryScreen.Bounds.Width / 1.5f;

            //if (cube == null)
            //{
                cube = new Cube();
                cube.InitializeCube(400, 200, 250);
            //    Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));

            //    cube.count2D(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));

            //    pictureBox1.Image = Drawing_Service.drawingCube(cube, graphics3d, bitmap3d);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points2d = new List<PointF>();
            int minX, maxX, minY, maxY, minZ, maxZ;

            minX = 50;
            maxX = 550;
            minY = 50;
            maxY = 250;
            minZ = 50;
            maxZ = 400;
            Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));
            points3d = Drawing_Service.randomPoints(bitmap3d, graphics3d, pictureBox1, Int32.Parse(textBox1.Text), minX, maxX, minY, maxY, minZ, maxZ, new PointF(pictureBox1.Size.Width/2, pictureBox1.Size.Height/2), camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            for (int i = 0; i < points3d.Count; i++)
            {
                points2d.Add(points3d[i].Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2)));
            }
            Drawing_Service.drawPoints(bitmap3d, graphics3d, pictureBox1, points2d);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            bitmap3d = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics3d = Graphics.FromImage(bitmap3d);
            //points2d = new List<PointF>();

            zoom = (float)Screen.PrimaryScreen.Bounds.Width / 1.5f;
            cube.xRotation(15);
            for (int i = 0; i < points3d.Count; i++)
            {
                points3d[i].xRotation(15);
            }

            Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));

            cube.count2D(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            for (int i = 0; i < points3d.Count; i++)
            {
                PointF temp = points2d[i];
                points2d[i] = points3d[i].Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
                //points2d.Add(points3d[i].Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2)));
                foreach (var triangle in trianglesXY)
                {
                    triangle.convert(temp, points2d[i]);
                }

                foreach (var triangle in trianglesYZ)
                {
                    triangle.convert(temp, points2d[i]);
                }

                foreach (var triangle in trianglesZX)
                {
                    triangle.convert(temp, points2d[i]);
                }
            }

            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesXY);
            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesYZ);
            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesZX);

            //bitmap3d = Drawing_Service.drawingCube(cube, graphics3d, bitmap3d);
            Drawing_Service.drawPoints(bitmap3d, graphics3d, pictureBox1, points2d);
            pictureBox1.Image = bitmap3d;
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            bitmap3d = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics3d = Graphics.FromImage(bitmap3d);
            //points2d = new List<PointF>();

            zoom = (float)Screen.PrimaryScreen.Bounds.Width / 1.5f;
            cube.yRotation(15);
            for (int i = 0; i < points3d.Count; i++)
            {
                points3d[i].yRotation(15);
            }

            Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));

            cube.count2D(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            for (int i = 0; i < points3d.Count; i++)
            {
                PointF temp = points2d[i];
                points2d[i] = points3d[i].Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
                //points2d.Add(points3d[i].Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2)));
                foreach (var triangle in trianglesXY)
                {
                    triangle.convert(temp, points2d[i]);
                }

                foreach (var triangle in trianglesYZ)
                {
                    triangle.convert(temp, points2d[i]);
                }

                foreach (var triangle in trianglesZX)
                {
                    triangle.convert(temp, points2d[i]);
                }
            }

            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesXY);
            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesYZ);
            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesZX);

            //bitmap3d = Drawing_Service.drawingCube(cube, graphics3d, bitmap3d);
            Drawing_Service.drawPoints(bitmap3d, graphics3d, pictureBox1, points2d);
            pictureBox1.Image = bitmap3d;
            pictureBox1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            bitmap3d = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics3d = Graphics.FromImage(bitmap3d);
            //points2d = new List<PointF>();

            zoom = (float)Screen.PrimaryScreen.Bounds.Width / 1.5f;
            cube.zRotation(15);
            for (int i = 0; i < points3d.Count; i++)
            {
                points3d[i].zRotation(15);
            }

            Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));

            cube.count2D(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            for (int i = 0; i < points3d.Count; i++)
            {
                PointF temp = points2d[i];
                points2d[i] = points3d[i].Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
                //points2d.Add(points3d[i].Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2)));
                foreach (var triangle in trianglesXY)
                {
                    triangle.convert(temp, points2d[i]);
                }

                foreach (var triangle in trianglesYZ)
                {
                    triangle.convert(temp, points2d[i]);
                }

                foreach (var triangle in trianglesZX)
                {
                    triangle.convert(temp, points2d[i]);
                }
            }

            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesXY);
            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesYZ);
            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesZX);

            //bitmap3d = Drawing_Service.drawingCube(cube, graphics3d, bitmap3d);
            Drawing_Service.drawPoints(bitmap3d, graphics3d, pictureBox1, points2d);
            pictureBox1.Image = bitmap3d;
            pictureBox1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            bitmap3d = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics3d = Graphics.FromImage(bitmap3d);
            textBox1.Text = null;

            zoom = (float)Screen.PrimaryScreen.Bounds.Width / 1.5f;
            Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));
            cube = new Cube();
            cube.InitializeCube(400, 200, 250);
            cube.count2D(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            //pictureBox1.Image = Drawing_Service.drawingCube(cube, graphics3d, bitmap3d);

            points2d = null;
            points3d = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));

            List<PointF> pointsXY = new List<PointF>();
            List<PointF> pointsYZ = new List<PointF>();
            List<PointF> pointsZX = new List<PointF>();
            foreach (var point in points3d)
            {
                //xy axis
                Vector3D vector3D = new Vector3D(point.x, point.y, 0);
                //PointF pointXY = vector3D.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
                PointF pointXY = new PointF(point.x, point.y);
                pointsXY.Add(pointXY);

                //yz axis
                vector3D = new Vector3D(point.y, point.z, 0);
                //PointF pointYZ = vector3D.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
                PointF pointYZ = new PointF(point.y, point.z);
                pointsYZ.Add(pointYZ);

                //zx axis
                vector3D = new Vector3D(point.z, point.x, 0);
                //PointF pointZX = vector3D.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
                PointF pointZX = new PointF(point.z, point.x);
                pointsZX.Add(pointZX);
            }

            trianglesXY = Delaunay_Service.BowyerWatsonAlgorithm(pointsXY);
            foreach (var triangle in trianglesXY)
            {
                triangle.convertXY(points2d, points3d);
            }
            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesXY);

            trianglesYZ = Delaunay_Service.BowyerWatsonAlgorithm(pointsYZ);
            foreach (var triangle in trianglesYZ)
            {
                triangle.convertYZ(points2d, points3d);
            }
            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesYZ);

            trianglesZX = Delaunay_Service.BowyerWatsonAlgorithm(pointsZX);
            foreach (var triangle in trianglesZX)
            {
                triangle.convertZX(points2d, points3d);
            }
            Draw_Service.drawTriangle(bitmap3d, graphics3d, pictureBox1, trianglesZX);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Camera camera = new Camera(cube.center.x, cube.center.z, ((cube.center.x * zoom) / cube.center.x));

            tetrahedras = Delaunay_3d.BowyerWatsonAlgorithm(points3d);
            for (int i = 0; i < tetrahedras.Count; i++)
            {
                tetrahedras[i].convert3dTo2d(camera, zoom, pictureBox1);
            }
            Drawing_Service.drawDiagram(bitmap3d, graphics3d, pictureBox1, tetrahedras);
            //List<PointF> pointsXY = new List<PointF>();
            //List<PointF> pointsYZ = new List<PointF>();
            //List<PointF> pointsZX = new List<PointF>();
            //foreach (var point in points3d)
            //{
            //    //xy axis
            //    Vector3D vector3D = new Vector3D(point.x, point.y, 0);
            //    //PointF pointXY = vector3D.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            //    PointF pointXY = new PointF(point.x, point.y);
            //    pointsXY.Add(pointXY);

            //    //yz axis
            //    vector3D = new Vector3D(point.y, point.z, 0);
            //    //PointF pointYZ = vector3D.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            //    PointF pointYZ = new PointF(point.y, point.z);
            //    pointsYZ.Add(pointYZ);

            //    //zx axis
            //    vector3D = new Vector3D(point.z, point.x, 0);
            //    //PointF pointZX = vector3D.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            //    PointF pointZX = new PointF(point.z, point.x);
            //    pointsZX.Add(pointZX);
            //}

            //trianglesXY = Delaunay_Service.BowyerWatsonAlgorithm(pointsXY);
            ////foreach (var triangle in trianglesXY)
            ////{
            ////    triangle.convertXY(points2d, points3d);
            ////}

            //trianglesYZ = Delaunay_Service.BowyerWatsonAlgorithm(pointsYZ);
            ////foreach (var triangle in trianglesYZ)
            ////{
            ////    triangle.convertYZ(points2d, points3d);
            ////}

            //trianglesZX = Delaunay_Service.BowyerWatsonAlgorithm(pointsZX);
            ////foreach (var triangle in trianglesZX)
            ////{
            ////    triangle.convertZX(points2d, points3d);
            ////}

            //edgesXY = Voronoi_Service.DelaunayToVoronoi(trianglesXY);
            //foreach (var edge in edgesXY)
            //{
            //    Vector3D vector1 = new Vector3D(edge.p1.X, edge.p1.Y, 0);
            //    Vector3D vector2 = new Vector3D(edge.p2.X, edge.p2.Y, 0);
            //    edge.p1 = vector1.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            //    edge.p2 = vector2.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            //}
            //edgesYZ = Voronoi_Service.DelaunayToVoronoi(trianglesYZ);
            //foreach (var edge in edgesYZ)
            //{
            //    Vector3D vector1 = new Vector3D(0, edge.p1.Y, edge.p1.X);
            //    Vector3D vector2 = new Vector3D(0, edge.p2.Y, edge.p2.X);
            //    edge.p1 = vector1.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            //    edge.p2 = vector2.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            //}
            //edgesZX = Voronoi_Service.DelaunayToVoronoi(trianglesZX);
            //foreach (var edge in edgesZX)
            //{
            //    Vector3D vector1 = new Vector3D(edge.p1.X, 0, edge.p1.Y);
            //    Vector3D vector2 = new Vector3D(edge.p2.X, 0, edge.p2.Y);
            //    edge.p1 = vector1.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            //    edge.p2 = vector2.Count2d(camera, zoom, new PointF(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2));
            //}

            //Draw_Service.drawDiagram(bitmap3d, graphics3d, pictureBox1, edgesXY);
            //Draw_Service.drawDiagram(bitmap3d, graphics3d, pictureBox1, edgesYZ);
            //Draw_Service.drawDiagram(bitmap3d, graphics3d, pictureBox1, edgesZX);


        }
    }
}
