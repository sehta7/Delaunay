using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay
{
    class Delaunay_Service
    {
        //algorithm of Bowyer-Watson to make Delaunay triangulation
        public void BowyerWatsonAlgorithm(List<PointF> list)
        {
            //list of triangles
            List<Triangle> triangleList = new List<Triangle>();

            //find super triangle and add it to list
            Triangle superTriangle = Geometry_Service.superTriangle(list);
            triangleList.Add(superTriangle);
        }
    }
}
