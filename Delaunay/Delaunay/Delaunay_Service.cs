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
        public static List<Triangle> BowyerWatsonAlgorithm(List<PointF> list)
        {
            //list of triangles
            List<Triangle> triangleList = new List<Triangle>();

            //find super triangle and add it to list
            Triangle superTriangle = Geometry_Service.superTriangle(list);
            triangleList.Add(superTriangle);

            //checking each point in list
            for (int i = 0; i < list.Count; i++)
            {
                //list to store all edges of triangles
                List<Edge> edgeList = new List<Edge>();

                //check if point is inside the circumscribed circle on given triangle
                for (int j = 0; j < triangleList.Count; j++)
                {
                    if (Geometry_Service.isInsideCircle(list[i], triangleList[j]) == true)
                    {
                        //add three edges of triangle which has point inside and remove it from list of triangles
                        edgeList.Add(new Edge(triangleList[j].p1, triangleList[j].p2));
                        edgeList.Add(new Edge(triangleList[j].p2, triangleList[j].p3));
                        edgeList.Add(new Edge(triangleList[j].p3, triangleList[j].p1));
                        triangleList.RemoveAt(j);
                        j--;
                    }
                }

                //remove repeating edges from list
                for (int j = edgeList.Count - 2; j >= 0; j--)
                {
                    for (int k = edgeList.Count - 1; k >= j + 1; k--)
                    {
                        if (edgeList[j].Equals(edgeList[k]))
                        {
                            edgeList.RemoveAt(j);
                            edgeList.RemoveAt(k);
                            k--;
                            continue;
                        }
                    }
                }

                //create new triangle for every edge
                for (int j = 0; j < edgeList.Count; j++)
                {
                    //new triangle with points of edge and checking point
                    triangleList.Add(new Triangle(edgeList[j].p1, edgeList[j].p2, list[i]));
                }
                //clear edge list
                edgeList.Clear();
                edgeList = null;
            }

            return triangleList;
        }
    }
}
