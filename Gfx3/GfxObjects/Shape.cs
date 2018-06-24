using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gfx3.GfxObjects
{
    abstract class Shape
    {
        Point3D pivot;


        public double Scale { get; set; }
        public virtual double GetXc => throw new NotImplementedException();
        public virtual double GetYc => throw new NotImplementedException();
        public virtual double GetZc => throw new NotImplementedException();
    }
}
