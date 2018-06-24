using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gfx3.GfxObjects
{
    abstract class Shape
    {
        public Point3D Pivot { get; set; }

        public double Scale { get; set; }
        public virtual double GetXc => throw new NotImplementedException();
        public virtual double GetYc => throw new NotImplementedException();
        public virtual double GetZc => throw new NotImplementedException();

        abstract public List<Point3D> GetPoints();
        abstract public List<Polygon3D> GetPolygons();
    }
}
