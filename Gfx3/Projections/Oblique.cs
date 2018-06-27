using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Gfx3.GfxObjects;
using Gfx3.Transformations;

/**
 * Made By:
 *  Yftah Livny - 066633744
 *  Edan Hauon - 305249187
 */

namespace Gfx3.Projections
{
    /// <summary>
    /// Class for Parallel Oblique projection
    /// </summary>
    class Oblique : Projection
    {

        // arbitrary oblique angle
        public double Angle { get; set; } = 22.5 * Math.PI / 108;

        // Projection matrix (values change in translate!)
        double[,] matrix =
                {
                    { 1, 0 ,0 ,0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 1 }
                };

        /// <summary>
        /// Translates 3D points to 2D points
        /// </summary>
        /// <param name="points"></param>
        /// <returns>a list of 2D points</returns>
        public override List<Point> Translate(Point3D[] points)
        {
            // init result list
            List<Point> result = new List<Point>();
            
            // Calculate cosine and sine of Angle
            double cos = Math.Cos(Angle);
            double sin = Math.Sin(Angle);

            // update matrix to match angle
            matrix[2, 0] = 0.5 * cos;
            matrix[2, 1] = 0.5 * sin;

            // project all 3D points to 2D points
            foreach (Point3D p in points)
            {

                // create vector to multiply
                double[,] vec = { { p.x, p.y, p.z, 1 } };

                // multiply vector with matrix
                double[,] result_vec = Transformation.MultiplyMatrix(vec, matrix);

                // add 2D point to result list
                result.Add(new Point(Convert.ToInt32(result_vec[0, 0]), Convert.ToInt32(result_vec[0, 1])));
            }
            return result;
        }
    }
}
