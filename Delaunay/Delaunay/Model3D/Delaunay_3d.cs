using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay.Model3D
{
    class Delaunay_3d
    {
        public static List<Tetrahedra> BowyerWatsonAlgorithm(List<Vector3D> list)
        {
            //list of Tetrahedras
            List<Tetrahedra> TetrahedraList = new List<Tetrahedra>();

            //find super Tetrahedra and add it to list
            Tetrahedra superTetrahedra = Geometry.superTetrahedra(list);
            TetrahedraList.Add(superTetrahedra);
            list.Add(superTetrahedra.p1);
            list.Add(superTetrahedra.p2);
            list.Add(superTetrahedra.p3);
            list.Add(superTetrahedra.p4);

            //checking each point in list
            for (int i = 0; i < list.Count; i++)
            {
                //list to store all edges of Tetrahedras
                List<Triangle_3d> triangleList = new List<Triangle_3d>();

                //check if point is inside the circumscribed circle on given Tetrahedra
                for (int j = 0; j < TetrahedraList.Count; j++)
                {
                    if (Geometry.inSphere(TetrahedraList[j].p1, TetrahedraList[j].p2, TetrahedraList[j].p3, TetrahedraList[j].p4, list[i]))
                    {
                        //add edges of Tetrahedra which has point inside and remove it from list of Tetrahedras
                        triangleList.Add(new Triangle_3d(TetrahedraList[j].p1, TetrahedraList[j].p2, TetrahedraList[j].p3));
                        triangleList.Add(new Triangle_3d(TetrahedraList[j].p2, TetrahedraList[j].p3, TetrahedraList[j].p4));
                        triangleList.Add(new Triangle_3d(TetrahedraList[j].p4, TetrahedraList[j].p3, TetrahedraList[j].p1));
                        triangleList.Add(new Triangle_3d(TetrahedraList[j].p4, TetrahedraList[j].p2, TetrahedraList[j].p1));
                        TetrahedraList.RemoveAt(j);
                        j--;
                    }
                }
                if (i >= list.Count) continue;

                //remove repeating edges from list
                for (int j = triangleList.Count - 2; j >= 0; j--)
                {
                    for (int k = triangleList.Count - 1; k >= j + 1; k--)
                    {
                        if (Triangle_3d.areTheSame(triangleList[j], triangleList[k]))
                        {
                            triangleList.RemoveAt(k);
                            triangleList.RemoveAt(j);
                            k--;
                            continue;
                        }
                    }
                }

                //create new Tetrahedra for every edge
                for (int j = 0; j < triangleList.Count; j++)
                {
                    //new Tetrahedra with points of edge and checking point
                    TetrahedraList.Add(new Tetrahedra(triangleList[j].p1, triangleList[j].p2, triangleList[j].p3, list[i]));
                }
                //clear edge list
                triangleList.Clear();
                triangleList = null;
            }

            //remove Tetrahedras with vertices of super Tetrahedra
            for (int i = TetrahedraList.Count - 1; i >= 0; i--)
            {
                if (Tetrahedra.belongsToSuperTetrahedra(superTetrahedra, TetrahedraList[i]) == true)
                {
                    TetrahedraList.RemoveAt(i);
                }
            }

            return TetrahedraList;
        }
    }
}
