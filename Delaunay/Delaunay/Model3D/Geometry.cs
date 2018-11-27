using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay.Model3D
{
    class Geometry
    {
        public static bool inSphere(Vector3D a, Vector3D b, Vector3D c, Vector3D d, Vector3D pointToCheck)
        {
            bool inside = false;

            float t1 = countSquares(a.x, a.y, a.z);
            float t2 = countSquares(b.x, b.y, b.z);
            float t3 = countSquares(c.x, c.y, c.z);
            float t4 = countSquares(d.x, d.y, d.z);

            float T = Convert.ToSingle(Matrix.countMatrix4x4(a.x, a.y, a.z, 1,
                                                            b.x, b.y, b.z, 1,
                                                            c.x, c.y, c.z, 1,
                                                            d.x, d.y, d.z, 1));
            float D = Convert.ToSingle(Matrix.countMatrix4x4(t1, a.y, a.z, 1,
                                                            t2, b.y, b.z, 1,
                                                            t3, c.y, c.z, 1,
                                                            t4, d.y, d.z, 1)) / T;
            float E = Convert.ToSingle(Matrix.countMatrix4x4(a.x, t1, a.z, 1,
                                                            b.x, t2, b.z, 1,
                                                            c.x, t3, c.z, 1,
                                                            d.x, t4, d.z, 1)) / T;
            float F = Convert.ToSingle(Matrix.countMatrix4x4(a.x, a.y, t1, 1,
                                                            b.x, b.y, t2, 1,
                                                            c.x, c.y, t3, 1,
                                                            d.x, d.y, t4, 1)) / T;
            float G = Convert.ToSingle(Matrix.countMatrix4x4(a.x, a.y, a.z, t1,
                                                            b.x, b.y, b.z, t2,
                                                            c.x, c.y, c.z, t3,
                                                            d.x, d.y, d.z, t4)) / T;
            Vector3D center = countCenter(D, E, F);
            float r = Radius(D, E, F, G);

            double pointCenterLength = countLength(center, pointToCheck);

            if (pointCenterLength < r)
            {
                inside = true;
            }

            return inside;
        }

        private static double countLength(Vector3D p1, Vector3D p2)
        {
            return Math.Sqrt(Math.Pow((p1.x - p2.x), 2) + Math.Pow((p1.y - p2.y), 2) + Math.Pow((p1.z - p2.z), 2));
        }

        private static Vector3D countCenter(float D, float E, float F)
        {
            return new Vector3D((-D / 2), (-E / 2), (-F / 2));
        }

        private static float Radius(float D, float E, float F, float G)
        {
            return Convert.ToSingle((Math.Sqrt(Math.Pow(D, 2) + Math.Pow(E, 2) + Math.Pow(F, 2) - 4 * G)) / 2);
        }

        private static float countSquares(float a, float b, float c)
        {
            return Convert.ToSingle(-(Math.Pow(a, 2) + Math.Pow(b, 2) + Math.Pow(c, 2)));
        }
    }
}
