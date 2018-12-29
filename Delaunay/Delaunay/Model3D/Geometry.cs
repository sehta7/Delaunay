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

        public static Tetrahedra superTetrahedra(List<Vector3D> list)
        {
            float xmin = list[0].x;
            float ymin = list[0].y;
            float zmin = list[0].z;
            float xmax = xmin;
            float ymax = ymin;
            float zmax = zmin;

            for (int i = 0; i < list.Count; i++)
            {
                if (xmin > list[i].x)
                {
                    xmin = list[i].x;
                }

                if (ymin > list[i].y)
                {
                    ymin = list[i].y;
                }

                if (zmin > list[i].z)
                {
                    zmin = list[i].z;
                }

                if (xmax < list[i].x)
                {
                    xmax = list[i].x;
                }

                if (ymax < list[i].y)
                {
                    ymax = list[i].y;
                }

                if (zmax < list[i].z)
                {
                    zmax = list[i].z;
                }
            }

            float xd = xmax - xmin;
            float yd = ymax - ymin;
            float zd = zmax - zmin;
            float maxd;
            if (xd > yd)
            {
                if (xd > zd)
                {
                    maxd = xd;
                }
                else
                {
                    maxd = zd;
                }
            }
            else
            {
                if (yd > zd)
                {
                    maxd = yd;
                }
                else
                {
                    maxd = zd;
                }
            }

            float xmid = (xmin + xmax) * 0.5f;
            float ymid = (ymin + ymax) * 0.5f;
            float zmid = (zmin + zmax) * 0.5f;

            Vector3D p1 = new Vector3D((xmid - 2 * maxd), (ymid - maxd), (zmid - 2 * maxd));
            Vector3D p2 = new Vector3D(xmid, (ymid + 2 * maxd), zmid);
            Vector3D p3 = new Vector3D((xmid + 2 * maxd), (ymid - maxd), (zmid - 2 * maxd));
            Vector3D p4 = new Vector3D((p1.x + p3.x) / 2, (ymid - maxd), (zmid + 2 * maxd));

            Tetrahedra superTetrahedra = new Tetrahedra(p1, p2, p3, p4);

            return superTetrahedra;
        }
    }
}
