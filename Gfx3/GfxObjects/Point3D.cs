using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gfx3.GfxObjects
{
    class Point3D
    {
        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point3D CrossProduct(Point3D p1, Point3D p2)
        {
            double x, y, z;
            x = p1.y * p2.z - p2.y * p1.z;
            y = (p1.x * p2.z - p2.x * p1.z) * -1;
            z = p1.x * p2.y - p2.x * p1.y;

            return new Point3D(x, y, z);
        }

        public static Point3D operator +(Point3D a, Point3D b)
        {
            return new Point3D(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Point3D operator -(Point3D a, Point3D b)
        {
            return new Point3D(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Point3D operator -(Point3D pt)
        {
            return new Point3D(-pt.x, -pt.y, -pt.z);
        }

        public static Point3D operator *(Point3D a, Point3D b)
        {
            return CrossProduct(a,b);
        }


        public override string ToString()
        {
            return "(" + x + "," + y + "," + z + ")";
        }

        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }
}
