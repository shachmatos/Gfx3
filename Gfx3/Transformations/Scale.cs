using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gfx3.GfxObjects;

/**
 * Made By:
 *  Yftah Livny - 066633744
 *  Edan Hauon - 305249187
 */

namespace Gfx3.Transformations
{
    class Scale : Transformation
    {
        // Transformation matrix (updates at transform!)
        double[,] matrix =
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            };


        /// <summary>
        /// Scale individual shape (around its own center)
        /// </summary>
        /// <param name="shape">The shape to be transformed</param>
        /// <param name="transformVector">Scale paramters (in x y and z)</param>
        /// <returns>Transformmed shape</returns>
        public override Shape Transform(Shape shape, Point3D transformVector)
        {
            // get points from shape
            List<Point3D> points = shape.GetPoints();

            // update matrix
            matrix[0, 0] = transformVector.x;
            matrix[1, 1] = transformVector.y;
            matrix[2, 2] = transformVector.z;

            // transform all points in shape
            foreach (Point3D p in points)
            {
                // move to shape origin
                p.x -= shape.Pivot.x;
                p.y -= shape.Pivot.y;
                p.z -= shape.Pivot.z;

                // create vector for multiplication
                double[,] vec = { { p.x, p.y, p.z, 1 } };

                // multiply by scaling matrix
                double[,] new_vec = MultiplyMatrix(vec, matrix);

                // update point
                p.x = new_vec[0, 0];
                p.y = new_vec[0, 1];
                p.z = new_vec[0, 2];

                // move shape back to shape center
                p.x += shape.Pivot.x;
                p.y += shape.Pivot.y;
                p.z += shape.Pivot.z;

            }

            return shape;
        }

        /// <summary>
        /// Scale shape around an alternative center
        /// </summary>
        /// <param name="shape">Shape to be transformed</param>
        /// <param name="transformVector">Scaling parameters</param>
        /// <param name="transformCenter">The center / pivot of transformation</param>
        /// <returns>Transformmed shape</returns>
        public override Shape Transform(Shape shape, Point3D transformVector, Point3D transformCenter)
        {
            // get points from shape
            List<Point3D> points = shape.GetPoints();

            // update matrix
            matrix[0, 0] = transformVector.x;
            matrix[1, 1] = transformVector.y;
            matrix[2, 2] = transformVector.z;

            // transform center around transformCenter
            double[,] center_vec = { { shape.Pivot.x - transformCenter.x, shape.Pivot.y - transformCenter.y, shape.Pivot.z - transformCenter.z, 1 } };
            double[,] center_scaled = MultiplyMatrix(center_vec, matrix);
            shape.Pivot.x = center_scaled[0, 0];
            shape.Pivot.y = center_scaled[0, 1];
            shape.Pivot.z = center_scaled[0, 2];

            // transform all points in shape
            foreach (Point3D p in points)
            {
                // move to relative origin
                p.x -= transformCenter.x;
                p.y -= transformCenter.y;
                p.z -= transformCenter.z;

                // create vector and multiply by transformation matrix
                double[,] vec = { { p.x, p.y, p.z, 1 } };
                double[,] new_vec = MultiplyMatrix(vec, matrix);

                // update point
                p.x = new_vec[0, 0];
                p.y = new_vec[0, 1];
                p.z = new_vec[0, 2];

                // move back to relative center
                p.x += transformCenter.x;
                p.y += transformCenter.y;
                p.z += transformCenter.z;
            }

            return shape;
        }
    }
}
