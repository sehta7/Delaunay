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
        List<PointF> pointList;
        List<Triangle> triangleList;
        List<Edge> VoronoiDiagram;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics = Graphics.FromImage(bitmap);
            pointList = new List<PointF>();
            VoronoiDiagram = new List<Edge>();
        }

        //drawing random points on picturebox - number of points enter by user
        private void button1_Click(object sender, EventArgs e)
        {
            pointList = Draw_Service.drawRandomPoints(bitmap, graphics, pictureBox1, Int32.Parse(textBox1.Text), pictureBox1.Size.Width, pictureBox1.Size.Height);
        }

        //drawing Delaunay triangulation
        private void button2_Click(object sender, EventArgs e)
        {
            triangleList = Delaunay_Service.BowyerWatsonAlgorithm(pointList);
            Draw_Service.drawTriangle(bitmap, graphics, pictureBox1, triangleList);
            //Laplace smoothing
            if (checkBox1.Checked)
            {
                System.Threading.Thread.Sleep(3000);
                //remove vertices of supertriangle from list
                pointList.RemoveAt(pointList.Count - 1);
                pointList.RemoveAt(pointList.Count - 1);
                pointList.RemoveAt(pointList.Count - 1);
                List<PointF> laplacePoints = new List<PointF>();
                List<Triangle> smoothTriangles = new List<Triangle>();
                laplacePoints = Laplace_Service.Laplace(triangleList, pointList);
                smoothTriangles = Delaunay_Service.BowyerWatsonAlgorithm(laplacePoints);
                Bitmap bitmap2 = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
                graphics = Graphics.FromImage(bitmap2);
                Draw_Service.drawPoints(bitmap2, graphics, pictureBox1, laplacePoints);
                Draw_Service.drawTriangle(bitmap2, graphics, pictureBox1, smoothTriangles);
            }
        }

        //drawing Voronoi diagram
        private void button3_Click(object sender, EventArgs e)
        {
            triangleList = Delaunay_Service.BowyerWatsonAlgorithm(pointList);
            triangleList = Delaunay_Service.BowyerWatsonAlgorithm(pointList);
            VoronoiDiagram = Voronoi_Service.DelaunayToVoronoi(triangleList);
            Draw_Service.drawDiagram(bitmap, graphics, pictureBox1, VoronoiDiagram);
            //Laplace smoothing
            if (checkBox1.Checked)
            {
                System.Threading.Thread.Sleep(3000);
                List<PointF> laplacePoints = new List<PointF>();
                List<Triangle> smoothTriangles = new List<Triangle>();
                laplacePoints = Laplace_Service.Laplace(triangleList, pointList);
                smoothTriangles = Delaunay_Service.BowyerWatsonAlgorithm(laplacePoints);
                Bitmap bitmap2 = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
                graphics = Graphics.FromImage(bitmap2);
                List<Edge> laplaceEdges = new List<Edge>();
                laplaceEdges = Voronoi_Service.DelaunayToVoronoi(smoothTriangles);
                Draw_Service.drawPoints(bitmap2, graphics, pictureBox1, laplacePoints);
                Draw_Service.drawDiagram(bitmap2, graphics, pictureBox1, laplaceEdges);
            }
        }

        //clear button
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics = Graphics.FromImage(bitmap);
            textBox1.Text = null;
            triangleList = new List<Triangle>();
            pointList = new List<PointF>();
            VoronoiDiagram = new List<Edge>();
            checkBox1.Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form Form3D = new Model3D.Form3D();
            Form3D.Show();
        }
    }
}
