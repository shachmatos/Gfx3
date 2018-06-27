using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

/**
 * Made By:
 *  Yftah Livny - 066633744
 *  Edan Hauon - 305249187
 */

namespace Gfx3.GfxObjects
{
    /// <summary>
    /// A Class representing a 3D Polygon
    /// </summary>
    class Polygon3D
    {
        /// <summary>
        /// Writeframe Color
        /// </summary>
        public Color LineColor { get; set; } = Color.White;

        /// <summary>
        /// Fill Color
        /// </summary>
        public Color FillColor { get; set; } = Color.LightYellow;

        /// <summary>
        /// Array of 3D Points (assuming counter-clockwise build)
        /// </summary>
        public Point3D[] Points { get; set; }

        /// <summary>
        /// Constructor - without color specifications (defaults apply)
        /// </summary>
        /// <param name="pts">Array of 3D points</param>
        public Polygon3D(Point3D[] pts)
        {
            // Allow only triangular polygons
            if (pts.Length != 3) throw new ArgumentException();
            Points = pts;
        }

        /// <summary>
        /// Constructor - with color specification
        /// </summary>
        /// <param name="pts">Array of 3D points</param>
        /// <param name="lineColor">Color for wireframe</param>
        /// <param name="fillColor">Color for polygon fill</param>
        public Polygon3D(Point3D[] pts, Color lineColor, Color fillColor) : this(pts)
        {
            LineColor = lineColor;
            FillColor = fillColor;
        }

        /// <summary>
        /// Returns a 3D Point representing the normal vector.
        /// </summary>
        /// <returns>The Normal Vector</returns>
        public Point3D GetNormal()
        {
            Point3D a, b;
            a = Points[0] - Points[1];
            b = Points[0] - Points[2];
            return Point3D.CrossProduct(a, b);
        }

        /// <summary>
        /// Get the max Z value of this polygon
        /// </summary>
        /// <returns>Max Z Point</returns>
        public double GetMaxZ()
        {
            return (from p in Points select p.z).Max();
        }

        /// <summary>
        /// Get the min Z value of this polygon
        /// </summary>
        /// <returns>Min Z Point</returns>
        public double GetMinZ()
        {
            return (from p in Points select p.z).Min();
        }

        /// <summary>
        /// Get the max X value of this polygon
        /// </summary>
        /// <returns>Max X Point</returns>
        public double GetMaxX()
        {
            return (from p in Points select p.x).Max();
        }

        /// <summary>
        /// Get the min X value of this polygon
        /// </summary>
        /// <returns>Min X Point</returns>
        public double GetMinX()
        {
            return (from p in Points select p.x).Min();
        }

        /// <summary>
        /// Get the max Y value of this polygon
        /// </summary>
        /// <returns>Max Y Point</returns>
        public double GetMaxY()
        {
            return (from p in Points select p.y).Max();
        }

        /// <summary>
        /// Get the min Y value of this polygon
        /// </summary>
        /// <returns>Min Y Point</returns>
        public double GetMinY()
        {
            return (from p in Points select p.y).Min();
        }

    }
}
