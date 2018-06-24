using Gfx3.GfxObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gfx3.Projections
{
    abstract class Projection
    {

        public Point3D center { get; set; } = new Point3D(0, 0, -10);


        /// <summary>
        /// Receive a list of 3d points and return screen projection
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public abstract List<Point> Translate(Point3D[] points);
    }
}
