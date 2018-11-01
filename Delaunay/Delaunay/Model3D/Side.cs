using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay.Model3D
{
    class Side
    {
        public Vector3D[] tops3d;
        public PointF[] tops2d = new PointF[4];

        public Side(Vector3D[] tops3d)
        {
            this.tops3d = tops3d;
        }

        public Side(PointF[] tops2d)
        {
            this.tops2d = tops2d;
        }

        public Side(Vector3D[] tops3d, PointF[] tops2d)
        {
            this.tops3d = tops3d;
            this.tops2d = tops2d;
        }
    }
}
