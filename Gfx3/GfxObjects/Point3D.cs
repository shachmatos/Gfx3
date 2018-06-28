/**
 * Made By:
 *  Yftah Livny - 066633744
 *  Edan Hauon - 305249187
 */

namespace Gfx3.GfxObjects
{
    /// <summary>
    /// Class representing a 3D point
    /// </summary>
    class Point3D
    {
        // x coordinate property
        public double x { get; set; }

        // y coordinate property
        public double y { get; set; }

        // z coordinate property
        public double z { get; set; }

        /// <summary>
        /// Constructor - receives 3D coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Calcaulate cross product (required for normal vector calculation in Polygon3D)
        /// </summary>
        /// <param name="p1">Point 1</param>
        /// <param name="p2">Point 2</param>
        /// <returns>Cross product between Point 1 and 2</returns>
        public static Point3D CrossProduct(Point3D p1, Point3D p2)
        {
            double x, y, z;
            x = p1.y * p2.z - p2.y * p1.z;
            y = (p1.x * p2.z - p2.x * p1.z) * -1;
            z = p1.x * p2.y - p2.x * p1.y;

            return new Point3D(x, y, z);
        }

        /// <summary>
        /// Operator overload for easy addition
        /// </summary>
        /// <param name="a">Point 1</param>
        /// <param name="b">Point 2</param>
        /// <returns>Point addition</returns>
        public static Point3D operator +(Point3D a, Point3D b)
        {
            return new Point3D(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        /// <summary>
        /// Operator overload for easy subtraction
        /// </summary>
        /// <param name="a">Point 1</param>
        /// <param name="b">Point 2</param>
        /// <returns>Point subtraction</returns>
        public static Point3D operator -(Point3D a, Point3D b)
        {
            return new Point3D(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        /// <summary>
        /// Operator overload for easy negation
        /// </summary>
        /// <param name="pt">Point to negate</param>
        /// <returns>Negated point</returns>
        public static Point3D operator -(Point3D pt)
        {
            return new Point3D(-pt.x, -pt.y, -pt.z);
        }

        /// <summary>
        /// Operator overload for easy Dot Product
        /// </summary>
        /// <param name="a">Point 1</param>
        /// <param name="b">Point 2</param>
        /// <returns>Cross product between Point 1 and 2</returns>
        public static double operator *(Point3D a, Point3D b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }
}
