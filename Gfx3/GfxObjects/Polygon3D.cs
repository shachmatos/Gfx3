using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Gfx3.GfxObjects
{
    class Polygon3D
    {
        public Color LineColor { get; set; } = Color.White;
        public Color FillColor { get; set; } = Color.LightYellow;
        public Point3D[] Points { get; set; }

        public Polygon3D(Point3D[] pts)
        {
            if (pts.Length != 3) throw new ArgumentException();
            Points = pts;
        }

        public Polygon3D(Point3D[] pts, Color lineColor, Color fillColor) : this(pts)
        {
            LineColor = lineColor;
            FillColor = fillColor;
        }

        public Point3D GetNormal()
        {
            Point3D a, b;
            a = Points[0] - Points[1];
            b = Points[0] - Points[2];
            return Point3D.CrossProduct(a, b);
        }

        public double getMaxZ()
        {
            return (from p in Points select p.z).Max();
        }
    }
}
