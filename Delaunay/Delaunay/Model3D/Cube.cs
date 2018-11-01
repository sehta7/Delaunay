using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay.Model3D
{
    class Cube
    {
        public Side front;
        public Side back;
        public Side left;
        public Side right;
        public Side top;
        public Side bottom;

        public Vector3D center;

        public void InitializeCube(int width, int height, int depth)
        {
            //center
            center = new Vector3D(width / 2, height / 2, depth / 2);

            //front
            Vector3D[] front = new Vector3D[4];
            front[0] = new Vector3D(width, height, 0);
            front[1] = new Vector3D(0, height, 0);
            front[2] = new Vector3D(0, 0, 0);
            front[3] = new Vector3D(width, 0, 0);
            this.front = new Side(front);

            //back
            Vector3D[] back = new Vector3D[4];
            back[0] = new Vector3D(width, height, depth);
            back[1] = new Vector3D(0, height, depth);
            back[2] = new Vector3D(0, 0, depth);
            back[3] = new Vector3D(width, 0, depth);
            this.back = new Side(back);

            //left
            Vector3D[] left = new Vector3D[4];
            left[0] = new Vector3D(0, height, depth);
            left[1] = new Vector3D(0, 0, depth);
            left[2] = new Vector3D(0, 0, 0);
            left[3] = new Vector3D(0, height, 0);
            this.left = new Side(left);

            //right
            Vector3D[] right = new Vector3D[4];
            right[0] = new Vector3D(width, height, 0);
            right[1] = new Vector3D(width, 0, 0);
            right[2] = new Vector3D(width, 0, depth);
            right[3] = new Vector3D(width, height, depth);
            this.right = new Side(right);

            //top
            Vector3D[] top = new Vector3D[4];
            top[0] = new Vector3D(width, height, depth);
            top[1] = new Vector3D(0, height, depth);
            top[2] = new Vector3D(0, height, 0);
            top[3] = new Vector3D(width, height, 0);
            this.top = new Side(top);

            //bottom
            Vector3D[] bottom = new Vector3D[4];
            bottom[0] = new Vector3D(width, 0, depth);
            bottom[1] = new Vector3D(0, 0, depth);
            bottom[2] = new Vector3D(0, 0, 0);
            bottom[3] = new Vector3D(width, 0, 0);
            this.bottom = new Side(bottom);
        }

        public void count2D(Camera camera, float zoom, PointF drawCenter)
        {

            //fornt
            for (int i = 0; i < 4; i++)
            {
                float zValue = -front.tops3d[i].z - camera.position.z;
                front.tops2d[i].X = ((camera.position.x - front.tops3d[i].x) / zValue * zoom) + drawCenter.X;
                front.tops2d[i].Y = ((camera.position.y - front.tops3d[i].y) / zValue * zoom) + drawCenter.Y;
            }

            //back
            for (int i = 0; i < 4; i++)
            {
                float zValue = -back.tops3d[i].z - camera.position.z;
                back.tops2d[i].X = ((camera.position.x - back.tops3d[i].x) / zValue * zoom) + drawCenter.X;
                back.tops2d[i].Y = ((camera.position.y - back.tops3d[i].y) / zValue * zoom) + drawCenter.Y;
            }

            //left
            for (int i = 0; i < 4; i++)
            {
                float zValue = -left.tops3d[i].z - camera.position.z;
                left.tops2d[i].X = ((camera.position.x - left.tops3d[i].x) / zValue * zoom) + drawCenter.X;
                left.tops2d[i].Y = ((camera.position.y - left.tops3d[i].y) / zValue * zoom) + drawCenter.Y;
            }

            //right
            for (int i = 0; i < 4; i++)
            {
                float zValue = -right.tops3d[i].z - camera.position.z;
                right.tops2d[i].X = ((camera.position.x - right.tops3d[i].x) / zValue * zoom) + drawCenter.X;
                right.tops2d[i].Y = ((camera.position.y - right.tops3d[i].y) / zValue * zoom) + drawCenter.Y;
            }

            //top
            for (int i = 0; i < 4; i++)
            {
                float zValue = -top.tops3d[i].z - camera.position.z;
                top.tops2d[i].X = ((camera.position.x - top.tops3d[i].x) / zValue * zoom) + drawCenter.X;
                top.tops2d[i].Y = ((camera.position.y - top.tops3d[i].y) / zValue * zoom) + drawCenter.Y;
            }

            //bottom
            for (int i = 0; i < 4; i++)
            {
                float zValue = -bottom.tops3d[i].z - camera.position.z;
                bottom.tops2d[i].X = ((camera.position.x - bottom.tops3d[i].x) / zValue * zoom) + drawCenter.X;
                bottom.tops2d[i].Y = ((camera.position.y - bottom.tops3d[i].y) / zValue * zoom) + drawCenter.Y;
            }
        }

        public void xRotation(float degrees)
        {
            float cDegrees = degrees * (float)(Math.PI / 180.0);
            float cosDegrees = (float)Math.Cos(cDegrees);
            float sinDegrees = (float)Math.Sin(cDegrees);
            float temp;

            //front
            for (int i = 0; i < 4; i++)
            {
                temp = front.tops3d[i].y;
                front.tops3d[i].y = (front.tops3d[i].y * cosDegrees) + (front.tops3d[i].z * sinDegrees);
                front.tops3d[i].z = (temp * -sinDegrees) + (front.tops3d[i].z * cosDegrees);
            }

            //back
            for (int i = 0; i < 4; i++)
            {
                temp = back.tops3d[i].y;
                back.tops3d[i].y = (back.tops3d[i].y * cosDegrees) + (back.tops3d[i].z * sinDegrees);
                back.tops3d[i].z = (temp * -sinDegrees) + (back.tops3d[i].z * cosDegrees);
            }

            //left
            for (int i = 0; i < 4; i++)
            {
                temp = left.tops3d[i].y;
                left.tops3d[i].y = (left.tops3d[i].y * cosDegrees) + (left.tops3d[i].z * sinDegrees);
                left.tops3d[i].z = (temp * -sinDegrees) + (left.tops3d[i].z * cosDegrees);
            }

            //right
            for (int i = 0; i < 4; i++)
            {
                temp = right.tops3d[i].y;
                right.tops3d[i].y = (right.tops3d[i].y * cosDegrees) + (right.tops3d[i].z * sinDegrees);
                right.tops3d[i].z = (temp * -sinDegrees) + (right.tops3d[i].z * cosDegrees);
            }

            //top
            for (int i = 0; i < 4; i++)
            {
                temp = top.tops3d[i].y;
                top.tops3d[i].y = (top.tops3d[i].y * cosDegrees) + (top.tops3d[i].z * sinDegrees);
                top.tops3d[i].z = (temp * -sinDegrees) + (top.tops3d[i].z * cosDegrees);
            }

            //bottom
            for (int i = 0; i < 4; i++)
            {
                temp = bottom.tops3d[i].y;
                bottom.tops3d[i].y = (bottom.tops3d[i].y * cosDegrees) + (bottom.tops3d[i].z * sinDegrees);
                bottom.tops3d[i].z = (temp * -sinDegrees) + (bottom.tops3d[i].z * cosDegrees);
            }

        }

        public void yRotation(float degrees)
        {
            float cDegrees = degrees * (float)(Math.PI / 180.0);
            float cosDegrees = (float)Math.Cos(cDegrees);
            float sinDegrees = (float)Math.Sin(cDegrees);
            float temp;

            //front
            for (int i = 0; i < 4; i++)
            {
                temp = front.tops3d[i].x;
                front.tops3d[i].x = (front.tops3d[i].x * cosDegrees) + (front.tops3d[i].z * sinDegrees);
                front.tops3d[i].z = (temp * -sinDegrees) + (front.tops3d[i].z * cosDegrees);
            }

            //back
            for (int i = 0; i < 4; i++)
            {
                temp = back.tops3d[i].x;
                back.tops3d[i].x = (back.tops3d[i].x * cosDegrees) + (back.tops3d[i].z * sinDegrees);
                back.tops3d[i].z = (temp * -sinDegrees) + (back.tops3d[i].z * cosDegrees);
            }

            //left
            for (int i = 0; i < 4; i++)
            {
                temp = left.tops3d[i].x;
                left.tops3d[i].x = (left.tops3d[i].x * cosDegrees) + (left.tops3d[i].z * sinDegrees);
                left.tops3d[i].z = (temp * -sinDegrees) + (left.tops3d[i].z * cosDegrees);
            }

            //right
            for (int i = 0; i < 4; i++)
            {
                temp = right.tops3d[i].x;
                right.tops3d[i].x = (right.tops3d[i].x * cosDegrees) + (right.tops3d[i].z * sinDegrees);
                right.tops3d[i].z = (temp * -sinDegrees) + (right.tops3d[i].z * cosDegrees);
            }

            //top
            for (int i = 0; i < 4; i++)
            {
                temp = top.tops3d[i].x;
                top.tops3d[i].x = (top.tops3d[i].x * cosDegrees) + (top.tops3d[i].z * sinDegrees);
                top.tops3d[i].z = (temp * -sinDegrees) + (top.tops3d[i].z * cosDegrees);
            }

            //bottom
            for (int i = 0; i < 4; i++)
            {
                temp = bottom.tops3d[i].x;
                bottom.tops3d[i].x = (bottom.tops3d[i].x * cosDegrees) + (bottom.tops3d[i].z * sinDegrees);
                bottom.tops3d[i].z = (temp * -sinDegrees) + (bottom.tops3d[i].z * cosDegrees);
            }

        }

        public void zRotation(float degrees)
        {
            float cDegrees = degrees * (float)(Math.PI / 180.0);
            float cosDegrees = (float)Math.Cos(cDegrees);
            float sinDegrees = (float)Math.Sin(cDegrees);
            float temp;

            //front
            for (int i = 0; i < 4; i++)
            {
                temp = front.tops3d[i].x;
                front.tops3d[i].x = (front.tops3d[i].x * cosDegrees) + (front.tops3d[i].y * sinDegrees);
                front.tops3d[i].y = (temp * -sinDegrees) + (front.tops3d[i].y * cosDegrees);
            }

            //back
            for (int i = 0; i < 4; i++)
            {
                temp = back.tops3d[i].x;
                back.tops3d[i].x = (back.tops3d[i].x * cosDegrees) + (back.tops3d[i].y * sinDegrees);
                back.tops3d[i].y = (temp * -sinDegrees) + (back.tops3d[i].y * cosDegrees);
            }

            //left
            for (int i = 0; i < 4; i++)
            {
                temp = left.tops3d[i].x;
                left.tops3d[i].x = (left.tops3d[i].x * cosDegrees) + (left.tops3d[i].y * sinDegrees);
                left.tops3d[i].y = (temp * -sinDegrees) + (left.tops3d[i].y * cosDegrees);
            }

            //right
            for (int i = 0; i < 4; i++)
            {
                temp = right.tops3d[i].x;
                right.tops3d[i].x = (right.tops3d[i].x * cosDegrees) + (right.tops3d[i].y * sinDegrees);
                right.tops3d[i].y = (temp * -sinDegrees) + (right.tops3d[i].y * cosDegrees);
            }

            //top
            for (int i = 0; i < 4; i++)
            {
                temp = top.tops3d[i].x;
                top.tops3d[i].x = (top.tops3d[i].x * cosDegrees) + (top.tops3d[i].y * sinDegrees);
                top.tops3d[i].y = (temp * -sinDegrees) + (top.tops3d[i].y * cosDegrees);
            }

            //bottom
            for (int i = 0; i < 4; i++)
            {
                temp = bottom.tops3d[i].x;
                bottom.tops3d[i].x = (bottom.tops3d[i].x * cosDegrees) + (bottom.tops3d[i].y * sinDegrees);
                bottom.tops3d[i].y = (temp * -sinDegrees) + (bottom.tops3d[i].y * cosDegrees);
            }

        }
    }
}
