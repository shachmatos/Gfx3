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
    /// <summary>
    /// Class for rotation transformations
    /// </summary>
    class Rotate : Transformation
    {
        // X rotation matrix (updated in transform)
        double[,] matrixX =
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 1}
            };

        // Y rotation matrix (updated in runtime)
        double[,] matrixY =
            {
                {0, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 1}
            };

        // Z rotation matrix (updated in runtime)
        double[,] matrixZ =
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            };

        /// <summary>
        /// Rotate individual shape around its own center
        /// </summary>
        /// <param name="shape">shape to be rotated</param>
        /// <param name="transformVector">rotation vector (x,y,z) </param>
        /// <returns></returns>
        public override Shape Transform(Shape shape, Point3D transformVector)
        {
            // get shape points
            List<Point3D> points = shape.GetPoints();

            // convert to radians
            transformVector.x *= Math.PI / 180;
            transformVector.y *= Math.PI / 180;
            transformVector.z *= Math.PI / 180;

            // calculate all required cosines and sines
            double cosX = Math.Cos(transformVector.x);
            double sinX = Math.Sin(transformVector.x);
            double cosY = Math.Cos(transformVector.y);
            double sinY = Math.Sin(transformVector.y);
            double cosZ = Math.Cos(transformVector.z);
            double sinZ = Math.Sin(transformVector.z);

            // update matrices
            matrixX[1, 1] = cosX;
            matrixX[1, 2] = sinX;
            matrixX[2, 1] = -sinX;
            matrixX[2, 2] = cosX;

            matrixY[0, 0] = cosY;
            matrixY[0, 2] = -sinY;
            matrixY[2, 0] = sinY;
            matrixY[2, 2] = cosY;

            matrixZ[0, 0] = cosZ;
            matrixZ[0, 1] = sinZ;
            matrixZ[1, 0] = -sinZ;
            matrixZ[1, 1] = cosZ;

            // transform all shape points
            foreach (Point3D p in points)
            {
                // move to shape center
                p.x -= shape.Pivot.x;
                p.y -= shape.Pivot.y;
                p.z -= shape.Pivot.z;

                // create transformation vector
                double[,] vec = { { p.x, p.y, p.z, 1 } };

                // if angle is 0 do not multiply else mutliply by corresponding rotation matrix - do this for each axis
                double[,] rotated_x = transformVector.x == 0 ? vec : MultiplyMatrix(vec, matrixX);
                double[,] rotated_y = transformVector.y == 0 ? rotated_x : MultiplyMatrix(rotated_x, matrixY);
                double[,] rotated_z = transformVector.z == 0 ? rotated_y : MultiplyMatrix(rotated_y, matrixZ);

                // update point and move back to shape center
                p.x = rotated_z[0, 0] + shape.Pivot.x;
                p.y = rotated_z[0, 1] + shape.Pivot.y;
                p.z = rotated_z[0, 2] + shape.Pivot.z;

            }

            return shape;
        }

        /// <summary>
        /// Rotate shape around an alternative axis
        /// </summary>
        /// <param name="shape"> shape to be rotated</param>
        /// <param name="transformVector"> rotation vector (x,y,z) angles</param>
        /// <param name="transformCenter"> center of transformation </param>
        /// <returns></returns>
        public override Shape Transform(Shape shape, Point3D transformVector, Point3D transformCenter)
        {
            // get shape points
            List<Point3D> points = shape.GetPoints();

            // convert to radians
            transformVector.x *= Math.PI / 180;
            transformVector.y *= Math.PI / 180;
            transformVector.z *= Math.PI / 180;

            // calculate all required sines and cosines
            double cosX = Math.Cos(transformVector.x);
            double sinX = Math.Sin(transformVector.x);
            double cosY = Math.Cos(transformVector.y);
            double sinY = Math.Sin(transformVector.y);
            double cosZ = Math.Cos(transformVector.z);
            double sinZ = Math.Sin(transformVector.z);

            // update matrices
            matrixX[1, 1] = cosX;
            matrixX[1, 2] = sinX;
            matrixX[2, 1] = -sinX;
            matrixX[2, 2] = cosX;

            matrixY[0, 0] = cosY;
            matrixY[0, 2] = -sinY;
            matrixY[2, 0] = sinY;
            matrixY[2, 2] = cosY;

            matrixZ[0, 0] = cosZ;
            matrixZ[0, 1] = sinZ;
            matrixZ[1, 0] = -sinZ;
            matrixZ[1, 1] = cosZ;

            // rotate center around transform center
            double[,] center_vec = { { shape.Pivot.x - transformCenter.x, shape.Pivot.y - transformCenter.y, shape.Pivot.z - transformCenter.z, 1 } };
            double[,] center_rotated_x = transformVector.x == 0 ? center_vec : MultiplyMatrix(center_vec, matrixX);
            double[,] center_rotated_y = transformVector.y == 0 ? center_rotated_x : MultiplyMatrix(center_rotated_x, matrixY);
            double[,] center_rotated_z = transformVector.z == 0 ? center_rotated_y : MultiplyMatrix(center_rotated_y, matrixZ);

            // update shape center
            shape.Pivot.x = center_rotated_z[0,0] + transformCenter.x;
            shape.Pivot.y = center_rotated_z[0, 1] + transformCenter.y;
            shape.Pivot.z = center_rotated_z[0, 2] + transformCenter.z;

            // transform all points
            foreach (Point3D p in points)
            {
                // move to relative origin
                p.x -= transformCenter.x;
                p.y -= transformCenter.y;
                p.z -= transformCenter.z;

                // create and multiply for each axis (if required)
                double[,] vec = { { p.x, p.y, p.z, 1 } };
                double[,] rotated_x = transformVector.x == 0 ? vec : MultiplyMatrix(vec, matrixX);
                double[,] rotated_y = transformVector.y == 0 ? rotated_x : MultiplyMatrix(rotated_x, matrixY);
                double[,] rotated_z = transformVector.z == 0 ? rotated_y : MultiplyMatrix(rotated_y, matrixZ);

                // update point and move back to relative center
                p.x = rotated_z[0, 0] + transformCenter.x;
                p.y = rotated_z[0, 1] + transformCenter.y;
                p.z = rotated_z[0, 2] + transformCenter.z;
            }

            return shape;
        }
    }
}
