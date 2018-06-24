using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Gfx3.GfxObjects;
using Gfx3.Transformations;

namespace Gfx3.Projections
{
    class Perspective : Projection
    {
        public int fov = 90;


        public override List<Point> Translate(Point3D[] points)
        {
            List<Point> result = new List<Point>();
            foreach (Point3D p in points)
            {
                double denom = 1 + p.z / Math.Sqrt(Math.Pow(p.x - center.x, 2) + Math.Pow(p.y - center.y, 2) + Math.Pow(p.z - center.z, 2));
                //double x = p.x / denom;
                //double y = p.y / denom;
                double s = 1 / denom;
                double[,] vec = { { p.x, p.y, 1, 1 } };
                double[,] matrix =
                {
                    { s , 0 ,0 ,0},
                    { 0, s, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 1 }
                };

                double [,] result_vec = Transformation.MultiplyMatrix(vec, matrix);
                result.Add(new Point(Convert.ToInt32(result_vec[0, 0]), Convert.ToInt32(result_vec[0, 1])));
            }
            return result;
        }
    }
}
