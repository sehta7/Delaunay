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

        public PointF Count2d(Camera camera, float zoom, PointF drawCenter)
        {
            PointF point = new PointF();
            float zValue = -this.z - camera.position.z;
            point.X = ((camera.position.x - this.x) / zValue * zoom) + drawCenter.X;
            point.Y = ((camera.position.y - this.y) / zValue * zoom) + drawCenter.Y;

            return point;
        }

        public void xRotation(float degrees)
        {
            float cDegrees = degrees * (float)(Math.PI / 180.0);
            float cosDegrees = (float)Math.Cos(cDegrees);
            float sinDegrees = (float)Math.Sin(cDegrees);

            float temp = y;
            float tempZ = z;
            y = (temp * cosDegrees) + (tempZ * sinDegrees);
            z = (temp * -sinDegrees) + (tempZ * cosDegrees);
        }

        public void yRotation(float degrees)
        {
            float cDegrees = degrees * (float)(Math.PI / 180.0);
            float cosDegrees = (float)Math.Cos(cDegrees);
            float sinDegrees = (float)Math.Sin(cDegrees);

            float temp = x;
            float tempZ = z;
            x = (temp * cosDegrees) + (tempZ * sinDegrees);
            z = (temp * -sinDegrees) + (tempZ * cosDegrees);
        }

        public void zRotation(float degrees)
        {
            float cDegrees = degrees * (float)(Math.PI / 180.0);
            float cosDegrees = (float)Math.Cos(cDegrees);
            float sinDegrees = (float)Math.Sin(cDegrees);

            float temp = x;
            float tempY = y;
            x = (temp * cosDegrees) + (tempY * sinDegrees);
            y = (temp * -sinDegrees) + (tempY * cosDegrees);
        }
    }
}
