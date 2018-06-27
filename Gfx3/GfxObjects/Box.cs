using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Made By:
 *  Yftah Livny - 066633744
 *  Edan Hauon - 305249187
 */

namespace Gfx3.GfxObjects
{
    /// <summary>
    /// Simple Box class - creates points around a center point representing a rectangular box and creates Polygons to represent said box.
    /// </summary>
    class Box : Shape
    {
        // Box Width
        private int width;

        // Box Height
        private int height;

        // Box Depth
        private int depth;

        // Box Rotation (point represents angle vector)
        private Point3D rotation;

        // Point Dictionary
        private Dictionary<string, Point3D> points;

        // Polygon List
        private List<Polygon3D> polygons;

        /// <summary>
        /// Constructor - creates all points and polygons according to parameters
        /// </summary>
        /// <param name="center"> Center Point - all other points will be created in relation to this point</param>
        /// <param name="width"> the width of the box </param>
        /// <param name="height"> the height of the box </param>
        /// <param name="depth"> the depth of the box </param>
        /// <param name="rotationX"> X rotation (default 0) </param>
        /// <param name="rotationY"> Y rotation (default 0) </param>
        /// <param name="rotationZ"> Z rotation (default 0) </param>
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

        /// <summary>
        /// Update polygons from the given points. (happens once)
        /// </summary>
        public void UpdatePolygons()
        {
            // Init list if required
            if (polygons == null)
                polygons = new List<Polygon3D>();

            // reset list
            polygons.Clear();

            
            // Add center and scale to all points
            foreach (Point3D p in points.Values)
            {
                p.x *= Scale;
                p.y *= Scale;
                p.z *= Scale;
                p.x += Pivot.x;
                p.y += Pivot.y;
                p.z += Pivot.z;
            }

            // Create triangular polygons for each face of the box
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

            // Apply box rotation
            Transformations.Transformation x = new Transformations.Rotate();
            x.Transform(this, new Point3D(rotation.x, rotation.y, rotation.z));

            // Create polygons and add to list
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
        }


        /// <summary>
        /// Get Polygon List
        /// </summary>
        /// <returns>a list of polygons</returns>
        public override List<Polygon3D> GetPolygons()
        {
            return polygons;
        }

        /// <summary>
        /// Get Point List
        /// </summary>
        /// <returns>a list of all the points in the point dictionary</returns>
        public override List<Point3D> GetPoints()
        {
            return points.Values.ToList();
        }
    }
}
