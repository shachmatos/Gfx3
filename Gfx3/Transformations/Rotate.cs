using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gfx3.GfxObjects;

namespace Gfx3.Transformations
{
    class Rotate : Transformation
    {
        public override Shape Transform(Shape shape, Point3D transformVector)
        {
            List<Point3D> points = shape.GetPoints();

            transformVector.x *= Math.PI / 180;
            transformVector.y *= Math.PI / 180;
            transformVector.z *= Math.PI / 180;

            double cosX = Math.Cos(transformVector.x);
            double sinX = Math.Sin(transformVector.x);
            double cosY = Math.Cos(transformVector.y);
            double sinY = Math.Sin(transformVector.y);
            double cosZ = Math.Cos(transformVector.z);
            double sinZ = Math.Sin(transformVector.z);

            double[,] matrixX =
            {
                {1, 0, 0, 0},
                {0, cosX, sinX, 0},
                {0, -sinX, cosX, 0},
                {0, 0, 0, 1}
            };

            double[,] matrixY =
            {
                {cosY, 0, -sinY, 0},
                {0, 1, 0, 0},
                {sinY, 0, cosY, 0},
                {0, 0, 0, 1}
            };

            double[,] matrixZ =
            {
                {cosZ, sinZ, 0, 0},
                {-sinZ, cosZ, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            };

            foreach (Point3D p in points)
            {
                p.x -= shape.Pivot.x;
                p.y -= shape.Pivot.y;
                p.z -= shape.Pivot.z;

                double[,] vec = { { p.x, p.y, p.z, 1 } };
                double[,] rotated_x = transformVector.x == 0 ? vec : MultiplyMatrix(vec, matrixX);
                double[,] rotated_y = transformVector.y == 0 ? rotated_x : MultiplyMatrix(rotated_x, matrixY);
                double[,] rotated_z = transformVector.z == 0 ? rotated_y : MultiplyMatrix(rotated_y, matrixZ);


                p.x = rotated_z[0, 0] + shape.Pivot.x;
                p.y = rotated_z[0, 1] + shape.Pivot.y;
                p.z = rotated_z[0, 2] + shape.Pivot.z;

            }

            return shape;
        }
    }
}
