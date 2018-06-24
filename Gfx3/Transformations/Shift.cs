using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gfx3.GfxObjects;

namespace Gfx3.Transformations
{
    class Shift : Transformation
    {
        public override Shape Transform(Shape shape, Point3D transformVector)
        {
            List<Point3D> points = shape.GetPoints();
            double[,] matrix =
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {transformVector.x, transformVector.y, transformVector.z, 1}
            };

            foreach (Point3D p in points)
            {
                p.x -= shape.Pivot.x;
                p.y -= shape.Pivot.y;
                p.z -= shape.Pivot.z;
                double[,] vec = { { shape.Pivot.x, shape.Pivot.y, shape.Pivot.z, 1 } };
                double [,] new_vec = MultiplyMatrix(vec, matrix);

                shape.Pivot.x = new_vec[0,0];
                shape.Pivot.y = new_vec[0, 1];
                shape.Pivot.z = new_vec[0, 2];

                p.x += shape.Pivot.x;
                p.y += shape.Pivot.y;
                p.z += shape.Pivot.z;

            }

            return shape;
        }
    }
}
