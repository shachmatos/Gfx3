using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gfx3.GfxObjects
{
    class Box : Shape
    {
        private int width;
        private int height;
        private int depth;
        private Point3D rotation;
        private Dictionary<string, Point3D> points;
        private List<Polygon3D> polygons;

        public Box(Point3D center, int width, int height, int depth, double rotationX = 0, double rotationY = 0, double rotationZ = 0)
        {
            Pivot = center;
            this.width = width;
            this.height = height;
            this.depth = depth;
            points = new Dictionary<string, Point3D>();

            points.Add("tlb", new Point3D(-width / 2, -height / 2, -depth / 2));
            points.Add("tlf", new Point3D(-width / 2, -height / 2, depth / 2));
            points.Add("trf", new Point3D(width / 2, -height / 2, depth / 2));
            points.Add("trb", new Point3D(width / 2, -height / 2, -depth / 2));
            points.Add("blb", new Point3D(-width / 2, height / 2, -depth / 2));
            points.Add("blf", new Point3D(-width / 2, height / 2, depth / 2));
            points.Add("brf", new Point3D(width / 2, height / 2, depth / 2));
            points.Add("brb", new Point3D(width / 2, height / 2, -depth / 2));

            rotation = new Point3D(rotationX, rotationY, rotationZ);
            UpdatePolygons();
        }

        public void UpdatePolygons()
        {
            if (polygons == null)
                polygons = new List<Polygon3D>();
            polygons.Clear();

            Point3D[] pts = points.Values.ToArray().Clone() as Point3D [];
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

            Point3D[] top1 = { points["tlb"], points["tlf"], points["trf"] };
            Point3D[] top2 = { points["tlb"], points["trf"], points["trb"] };
            Point3D[] bot1 = { points["brb"], points["brf"], points["blf"] };
            Point3D[] bot2 = { points["brb"], points["blf"], points["blb"] };
            Point3D[] right1 = { points["trf"], points["brf"], points["brb"] };
            Point3D[] right2 = { points["trf"], points["brb"], points["trb"] };
            Point3D[] left1 = { points["tlb"], points["blb"], points["blf"] };
            Point3D[] left2 = { points["tlb"], points["blf"], points["tlf"] };
            Point3D[] front1 = { points["tlf"], points["blf"], points["brf"] };
            Point3D[] front2 = { points["tlf"], points["brf"], points["trf"] };
            Point3D[] back1 = { points["trb"], points["brb"], points["blb"] };
            Point3D[] back2 = { points["trb"], points["blb"], points["tlb"] };

            Transformations.Transformation x = new Transformations.Rotate();
            x.Transform(this, new Point3D(rotation.x, rotation.y, rotation.z));

            polygons.Add(new Polygon3D(top1, System.Drawing.Color.Black, System.Drawing.Color.Red));
            polygons.Add(new Polygon3D(top2, System.Drawing.Color.Black, System.Drawing.Color.Red));
            polygons.Add(new Polygon3D(bot1, System.Drawing.Color.Black, System.Drawing.Color.Blue));
            polygons.Add(new Polygon3D(bot2, System.Drawing.Color.Black, System.Drawing.Color.Blue));
            polygons.Add(new Polygon3D(right1, System.Drawing.Color.Black, System.Drawing.Color.DarkViolet));
            polygons.Add(new Polygon3D(right2, System.Drawing.Color.Black, System.Drawing.Color.DarkViolet));
            polygons.Add(new Polygon3D(left1, System.Drawing.Color.Black, System.Drawing.Color.Purple));
            polygons.Add(new Polygon3D(left2, System.Drawing.Color.Black, System.Drawing.Color.Purple));
            polygons.Add(new Polygon3D(front1, System.Drawing.Color.Black, System.Drawing.Color.Magenta));
            polygons.Add(new Polygon3D(front2, System.Drawing.Color.Black, System.Drawing.Color.Magenta));
            polygons.Add(new Polygon3D(back1, System.Drawing.Color.Black, System.Drawing.Color.Salmon));
            polygons.Add(new Polygon3D(back2, System.Drawing.Color.Black, System.Drawing.Color.Salmon));

            polygons.OrderByDescending(o => o.getMaxZ());
        }

        public override List<Polygon3D> GetPolygons()
        {
            polygons.OrderByDescending(o => o.getMaxZ());
            return polygons;
        }

        public override List<Point3D> GetPoints()
        {
            return points.Values.ToList();
        }
    }
}
