using Gfx3.GfxObjects;
using Gfx3.Transformations;
using System;
using System.Collections.Generic;
using System.Drawing;

/**
 * Made By:
 *  Yftah Livny - 066633744
 *  Edan Hauon - 305249187
 */

namespace Gfx3.Projections
{
    /// <summary>
    /// Class for Parallel Orthographic Projections
    /// </summary>
    class Orthographic : Projection
    {
        // Parallel orthographic matrix (static)
        double[,] matrix = 
            {
                    { 1 ,0 ,0 ,0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 1 }
            };
        public override List<Point> Translate(Point3D[] points)
        {
            // init result list
            List<Point> result = new List<Point>();

            // for all 3D points project to 2D points
            foreach (Point3D p in points)
            {
                // create vector for multiplication
                double[,] vec = { { p.x, p.y, 0, 1 } };

                // multiply vector with matrix
                double[,] result_vec = Transformation.MultiplyMatrix(vec, matrix);

                // add 2D point to the result list
                result.Add(new Point(Convert.ToInt32(result_vec[0, 0]), Convert.ToInt32(result_vec[0, 1])));
            }
            return result;
        }
    }
}
