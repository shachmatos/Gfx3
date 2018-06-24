using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gfx3.GfxObjects
{
    class Pyramid : Shape
    {
        private int width;
        private int height;
        private int depth;
        private Point3D rotation;
        private Dictionary<string, Point3D> points;
        private List<Polygon3D> polygons;

        public Pyramid(Point3D center, int width, int height, int depth, double rotationX = 0, double rotationY = 0, double rotationZ = 0)
        {
            Pivot = center;
            this.width = width;
            this.height = height;
            this.depth = depth;
            points = new Dictionary<string, Point3D>();

            points.Add("top", new Point3D(0, -height / 2, 0));
            points.Add("bbl", new Point3D(-width / 2, height / 2, depth / 2));
            points.Add("bbr", new Point3D(width / 2, height / 2, depth / 2));
            points.Add("bfc", new Point3D(0, height / 2, -depth / 2));

            rotation = new Point3D(rotationX, rotationY, rotationZ);
            UpdatePolygons();
        }

        public void UpdatePolygons()
        {
            if (polygons == null)
                polygons = new List<Polygon3D>();
            polygons.Clear();

            Point3D[] pts = points.Values.ToArray().Clone() as Point3D[];
            Scale = 1;
            foreach (Point3D p in pts)
            {
                p.x *= Scale;
                p.y *= Scale;
                p.z *= Scale;
                p.x += Pivot.x;
                p.y += Pivot.y;
                p.z += Pivot.z;
            }

            Point3D[] top1 = { points["top"], points["bbl"], points["bfc"] };
            Point3D[] top2 = { points["top"], points["bbr"], points["bbl"] };
            Point3D[] top3 = { points["top"], points["bfc"], points["bbr"] };
            Point3D[] base1 = { points["bfc"], points["bbl"], points["bbr"] };



            Transformations.Transformation x = new Transformations.Rotate();
            x.Transform(this, new Point3D(rotation.x, rotation.y, rotation.z));

            polygons.Add(new Polygon3D(top1, System.Drawing.Color.Black, System.Drawing.Color.Red));
            polygons.Add(new Polygon3D(top2, System.Drawing.Color.Black, System.Drawing.Color.DarkSlateGray));
            polygons.Add(new Polygon3D(top3, System.Drawing.Color.Black, System.Drawing.Color.DarkViolet));
            polygons.Add(new Polygon3D(base1, System.Drawing.Color.Black, System.Drawing.Color.DarkGreen));

            polygons.OrderByDescending(o => o.getMaxZ());
        }

        public override List<Polygon3D> GetPolygons()
        {
            return polygons;
        }

        public override List<Point3D> GetPoints()
        {
            return points.Values.ToList();
        }
    }
}
