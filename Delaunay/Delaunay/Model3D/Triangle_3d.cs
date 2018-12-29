using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay.Model3D
{
    class Triangle_3d
    {
        public Vector3D p1;
        public Vector3D p2;
        public Vector3D p3;

        public Triangle_3d()
        {

        }

        public Triangle_3d(Vector3D p1, Vector3D p2, Vector3D p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public static bool areTheSame(Triangle_3d p1, Triangle_3d p2)
        {
            bool same = false;

            if (p1.p1 == p2.p1)
            {
                if(p1.p2 == p2.p2)
                {
                    if (p1.p3 == p2.p3)
                    {
                        same = true;
                    }
                } else if(p1.p2 == p2.p3)
                {
                    if(p1.p3 == p2.p2)
                    {
                        same = true;
                    }
                }
            } else if(p1.p1 == p2.p2)
            {
                if (p1.p2 == p2.p1)
                {
                    if (p1.p3 == p2.p3)
                    {
                        same = true;
                    }
                } else if(p1.p2 == p2.p3)
                {
                    if(p1.p3 == p2.p1)
                    {
                        same = true;
                    }
                }
            } else if(p1.p1 == p2.p3)
            {
                if (p1.p2 == p2.p2)
                {
                    if (p1.p3 == p2.p1)
                    {
                        same = true;
                    }
                } else if(p1.p2 == p2.p1)
                {
                    if (p1.p3 == p2.p2)
                    {
                        same = true;
                    }
                }
            }

            return same;
        }
    }
}
