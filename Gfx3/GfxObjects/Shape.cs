using System.Collections.Generic;

/**
 * Made By:
 *  Yftah Livny - 066633744
 *  Edan Hauon - 305249187
 */

namespace Gfx3.GfxObjects
{
    /// <summary>
    /// Base class for shapes
    /// </summary>
    abstract class Shape
    {
        // Pivot (center) of a shape
        public Point3D Pivot { get; set; }

        // Scale of a single shape
        public double Scale { get; set; } = 1;

        // Return points of a shape
        abstract public List<Point3D> GetPoints();

        // return polygons of a shape
        abstract public List<Polygon3D> GetPolygons();
    }
}
