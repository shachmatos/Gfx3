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
    class Oblique : Projection
    {

        public double Angle { get; set; } = 22.5 * Math.PI / 108;

        public override List<Point> Translate(Point3D[] points)
        {
            List<Point> result = new List<Point>();
            foreach (Point3D p in points)
            {
                double cos = Math.Cos(Angle);
                double sin = Math.Sin(Angle);
                double[,] vec = { { p.x, p.y, p.z, 1 } };
                double[,] matrix =
                {
                    { 1 , 0 ,0 ,0},
                    { 0, 1, 0, 0 },
                    { 0.5 * cos, 0.5 * sin, 0, 0 },
                    { 0, 0, 0, 1 }
                };

                double[,] result_vec = Transformation.MultiplyMatrix(vec, matrix);
                result.Add(new Point(Convert.ToInt32(result_vec[0, 0]), Convert.ToInt32(result_vec[0, 1])));
            }
            return result;
        }
    }
}
