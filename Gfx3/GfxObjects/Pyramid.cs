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
    /// Simple Pyramid class - creates points around a center point representing a Pyramid and creates its Polygons.
    /// </summary>
    class Pyramid : Shape
    {
        // Pyramid base width
        private int width;

        // Pyramid height
        private int height;

        // Pyramid base depth
        private int depth;

        // Pyramid rotation vector
        private Point3D rotation;

        // Point Dictionary 
        private Dictionary<string, Point3D> points;

        // Polygon list
        private List<Polygon3D> polygons;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="center">center point</param>
        /// <param name="width">base width</param>
        /// <param name="height">height</param>
        /// <param name="depth">base depth</param>
        /// <param name="rotationX">rotation x</param>
        /// <param name="rotationY">rotation y</param>
        /// <param name="rotationZ">rotation z</param>
        public Pyramid(Point3D center, int width, int height, int depth, double rotationX = 0, double rotationY = 0, double rotationZ = 0)
        {
            // set center and dimentions
            Pivot = center;
            this.width = width;
            this.height = height;
            this.depth = depth;

            // init point dictionary
            points = new Dictionary<string, Point3D>
            {
                { "top", new Point3D(0, -height / 2, 0) },
                { "bbl", new Point3D(-width / 2, height / 2, depth / 2) },
                { "bbr", new Point3D(width / 2, height / 2, depth / 2) },
                { "bfc", new Point3D(0, height / 2, -depth / 2) }
            };

            // create a rotation vector
            rotation = new Point3D(rotationX, rotationY, rotationZ);

            // create polygons
            UpdatePolygons();
        }

        /// <summary>
        /// Creates polygons for the pyramid
        /// </summary>
        public void UpdatePolygons()
        {
            // init polygon list if required
            if (polygons == null)
                polygons = new List<Polygon3D>();

            // clear list
            polygons.Clear();

            // Apply scale and center to points
            foreach (Point3D p in points.Values)
            {
                p.x *= Scale;
                p.y *= Scale;
                p.z *= Scale;
                p.x += Pivot.x;
                p.y += Pivot.y;
                p.z += Pivot.z;
            }

            // Create point arrays for triangular polygons
            Point3D[] top1 = { points["top"], points["bbl"], points["bfc"] };
            Point3D[] top2 = { points["top"], points["bbr"], points["bbl"] };
            Point3D[] top3 = { points["top"], points["bfc"], points["bbr"] };
            Point3D[] base1 = { points["bfc"], points["bbl"], points["bbr"] };


            // apply shape rotation
            Transformations.Transformation x = new Transformations.Rotate();
            x.Transform(this, new Point3D(rotation.x, rotation.y, rotation.z));

            // create and save polygons in list
            polygons.Add(new Polygon3D(top1, System.Drawing.Color.Black, System.Drawing.Color.Red));
            polygons.Add(new Polygon3D(top2, System.Drawing.Color.Black, System.Drawing.Color.DarkSlateGray));
            polygons.Add(new Polygon3D(top3, System.Drawing.Color.Black, System.Drawing.Color.DarkViolet));
            polygons.Add(new Polygon3D(base1, System.Drawing.Color.Black, System.Drawing.Color.DarkGreen));
        }

        // returns polygons of a shape
        public override List<Polygon3D> GetPolygons()
        {
            return polygons;
        }

        // returns points of a shape
        public override List<Point3D> GetPoints()
        {
            return points.Values.ToList();
        }
    }
}
