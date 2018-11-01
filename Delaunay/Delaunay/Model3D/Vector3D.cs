using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay.Model3D
{
    class Vector3D
    {
        public float x;
        public float y;
        public float z;

        public Vector3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public PointF Count2d(Camera camera, float zoom)
        {
            PointF point = new PointF();
            float zValue = -this.z - camera.position.z;
            point.X = ((camera.position.x - this.x) / zValue * zoom);
            point.Y = ((camera.position.y - this.y) / zValue * zoom);

            return point;
        }
    }
}
