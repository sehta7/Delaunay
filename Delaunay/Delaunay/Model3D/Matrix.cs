using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay.Model3D
{
    class Matrix
    {
        public static double countMatrix4x4(double a11, double a12, double a13, double a14,
                                    double a21, double a22, double a23, double a24,
                                    double a31, double a32, double a33, double a34,
                                    double a41, double a42, double a43, double a44)
        {
            double result = 0;

            result = a11 * ((a22 * a33 * a44) + (a32 * a43 * a24) + (a42 * a23 * a34) - (a24 * a33 * a42) - (a34 * a43 * a22) - (a44 * a23 * a32))
                    - a21 * ((a12 * a33 * a44) + (a32 * a43 * a14) + (a42 * a13 * a34) - (a14 * a33 * a42) - (a34 * a43 * a12) - (a44 * a13 * a32))
                    + a31 * ((a12 * a23 * a44) + (a22 * a43 * a14) + (a42 * a13 * a24) - (a14 * a23 * a42) - (a24 * a43 * a12) - (a44 * a13 * a22))
                    - a41 * ((a12 * a23 * a34) + (a22 * a33 * a14) + (a32 * a13 * a24) - (a14 * a23 * a32) - (a24 * a33 * a12) - (a34 * a13 * a22));

            return result;
        }
    }
}
