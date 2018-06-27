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
    /// Class enabling calculation of perspective projection from 3D to 2D
    /// </summary>
    class Perspective : Projection
    {
        // Perspective Matrix (values change in translate!)
        double[,] matrix =
                {
                    { 1 ,0 ,0 ,0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 1 }
                };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public override List<Point> Translate(Point3D[] points)
        {
            // init result list
            List<Point> result = new List<Point>();

            // for all 3D points project to 2D points
            foreach (Point3D p in points)
            {
                // calculate denominator and S(z)
                double denom = 1 + p.z / Math.Sqrt(Math.Pow(0 - center.x, 2) + Math.Pow(0 - center.y, 2) + Math.Pow(0 - center.z, 2));
                double s = 1 / denom;

                // update matrix for current translation
                matrix[0, 0] = matrix[1,1] = s;

                // create vector for multiplication
                double[,] vec = { { p.x, p.y, 1, 1 } };

                // Execute matrix multiplication
                double [,] result_vec = Transformation.MultiplyMatrix(vec, matrix);

                // Add projected point to result list
                result.Add(new Point(Convert.ToInt32(result_vec[0, 0]), Convert.ToInt32(result_vec[0, 1])));
            }
            return result;
        }
    }
}
