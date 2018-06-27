using Gfx3.GfxObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/**
 * Made By:
 *  Yftah Livny - 066633744
 *  Edan Hauon - 305249187
 */

namespace Gfx3.Projections
{
    /// <summary>
    /// Base class for Projections
    /// </summary>
    abstract class Projection
    {
        // point representing the center of the projection (default (0,0,-10))
        public Point3D center { get; set; } = new Point3D(0, 0, -10);

        /// <summary>
        /// Receive a list of 3d points and return screen projection
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public abstract List<Point> Translate(Point3D[] points);
    }
}
