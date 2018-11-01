using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay.Model3D
{
    class Camera
    {
        public Vector3D position;

        public Camera(float x, float y, float z)
        {
            position = new Vector3D(x, y, z);
        }
    }
}
