using Gfx3.GfxObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gfx3.Projections
{
    abstract class Projection
    {

        private int centerOfProjection;


        /// <summary>
        /// Receive a list of 3d points and return screen projection
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public abstract Point[] translate(Point3D[] points);
    }
}
