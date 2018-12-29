using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delaunay.Model3D
{
    class Tetrahedra
    {
        public Vector3D p1;
        public Vector3D p2;
        public Vector3D p3;
        public Vector3D p4;

        public PointF p1_2d;
        public PointF p2_2d;
        public PointF p3_2d;
        public PointF p4_2d;

        public Tetrahedra()
        {

        }

        public Tetrahedra(Vector3D p1, Vector3D p2, Vector3D p3, Vector3D p4)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
        }

        internal static bool belongsToSuperTetrahedra(Tetrahedra superTetrahedra, Tetrahedra tetrahedra)
        {
            bool belong = false;

            if (superTetrahedra.p1.Equals(tetrahedra.p1) ||
                superTetrahedra.p1.Equals(tetrahedra.p2) ||
                superTetrahedra.p1.Equals(tetrahedra.p3) ||
                superTetrahedra.p1.Equals(tetrahedra.p4) ||
                superTetrahedra.p2.Equals(tetrahedra.p1) ||
                superTetrahedra.p2.Equals(tetrahedra.p2) ||
                superTetrahedra.p2.Equals(tetrahedra.p3) ||
                superTetrahedra.p2.Equals(tetrahedra.p4) ||
                superTetrahedra.p3.Equals(tetrahedra.p1) ||
                superTetrahedra.p3.Equals(tetrahedra.p2) ||
                superTetrahedra.p3.Equals(tetrahedra.p3) ||
                superTetrahedra.p3.Equals(tetrahedra.p4) ||
                superTetrahedra.p4.Equals(tetrahedra.p1) ||
                superTetrahedra.p4.Equals(tetrahedra.p2) ||
                superTetrahedra.p4.Equals(tetrahedra.p3) ||
                superTetrahedra.p4.Equals(tetrahedra.p4))
            {
                belong = true;
            }

            return belong;
        }

        public void convert3dTo2d(Camera camera, float zoom, PictureBox pictureBox)
        {
            p1_2d = p1.Count2d(camera, zoom, new PointF(pictureBox.Size.Width / 2, pictureBox.Size.Height / 2));
            p2_2d = p2.Count2d(camera, zoom, new PointF(pictureBox.Size.Width / 2, pictureBox.Size.Height / 2));
            p3_2d = p3.Count2d(camera, zoom, new PointF(pictureBox.Size.Width / 2, pictureBox.Size.Height / 2));
            p4_2d = p4.Count2d(camera, zoom, new PointF(pictureBox.Size.Width / 2, pictureBox.Size.Height / 2));
        }
    }
}
