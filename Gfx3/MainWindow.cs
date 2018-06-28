using Gfx3.GfxObjects;
using Gfx3.Projections;
using Gfx3.Transformations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/**
 * Made By:
 *  Yftah Livny - 066633744
 *  Edan Hauon - 305249187
 */

namespace Gfx3
{
    /// <summary>
    /// Pointer to a transformation function to enable user to swap the current function
    /// </summary>
    /// <param name="amount">value for transformation function</param>
    delegate void TransformFn(double amount);

    /// <summary>
    /// Main window class - contains controls and canvas for drawing shapes
    /// </summary>
    public partial class MainWindow : Form
    {
        // Default scene center
        Point3D DefaultCenter { get; set; } = new Point3D(0, 0, 0);

        // Relative center for shapes
        Point3D ShapeCenter { get; set; } = new Point3D(0, 0, 0);

        // Current active projection
        Projection Proj { get; set; } = new Perspective();

        // Last mousedown event
        MouseEventArgs lastDown = null;

        // Transformation delegate
        TransformFn transformFn = null;

        // Current active transformation
        Transformation transformation = null;

        // List of shapes
        List<Shape> shapes = new List<Shape>();

        // List of transformation buttons (for highlighting)
        List<ToolStripButton> transformButtons = new List<ToolStripButton>();

        // Is mousedown even on canvas
        bool canvasMouseDown = false;

        // transformation flag (minimize transformations with mouse events)
        bool working = false;

        // wireframe flag - when true the polygons would only be drawn with lines
        bool wireframe = false;

        // Constructor
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Redraws the shapes on the canvas
        /// </summary>
        private void DrawShapes()
        {
            // create blank canvas / viewport
            Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);

            // create list to hold polygons
            List<Polygon3D> polygons = new List<Polygon3D>();

            // add polygons of each shape to the polygon list
            foreach (Shape shape in shapes)
            {
                polygons.AddRange(shape.GetPolygons());
            }

            // order by z index
            polygons = polygons.OrderBy(o => o.GetMaxZ()).ToList();

            // translate (project) points according to selected projection method and draw polygons on canvas
            foreach (Polygon3D pg in polygons)
            {
                

                // Project points
                List<Point> pts = Proj.Translate(pg.Points);

                // Determine visible polygons based on projection results
                Point3D pt1 = new Point3D(pg.Points[0].x, pg.Points[0].y, pg.Points[0].z);
                Point3D pt2 = new Point3D(pg.Points[1].x, pg.Points[1].y, pg.Points[1].z);
                Point3D pt3 = new Point3D(pg.Points[2].x, pg.Points[2].y, pg.Points[2].z);
                pg.Points[0].x = pts[0].X;
                pg.Points[0].y = pts[0].Y;
                pg.Points[1].x = pts[1].X;
                pg.Points[1].y = pts[1].Y;
                pg.Points[2].x = pts[2].X;
                pg.Points[2].y = pts[2].Y;

                // multiply normal with a generic view vector
                pg.Visible = pg.GetNormal() * new Point3D(0, 0, 1) < 0;

                // fix the original coordinates
                pg.Points[0].x = pt1.x;
                pg.Points[0].y = pt1.y;
                pg.Points[1].x = pt2.x;
                pg.Points[1].y = pt2.y;
                pg.Points[2].x = pt3.x;
                pg.Points[2].y = pt3.y;

                // check visibility
                if (!pg.Visible) continue;

                // Draw polygons
                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    // do not fill if wireframe is toggled
                    if (!wireframe)
                        gfx.FillPolygon(new SolidBrush(pg.FillColor), pts.ToArray());

                    // Draw polygon lines
                    gfx.DrawPolygon(new Pen(pg.LineColor), pts.ToArray());
                }

            }

            // replace old canvas
            canvas.Image?.Dispose();
            canvas.Image = bmp;
        }

        /// <summary>
        /// Revert shapes to their initial state (clears and recreates shapes)
        /// </summary>
        private void ResetShapes()
        {
            // clear old shapes
            shapes.Clear();

            // Add Shapes
            shapes.Add(new Box(new Point3D(canvas.Width / 2 - 100, canvas.Height / 2, 0), 100, 100, 100, 45, 10, 74));
            shapes.Add(new Pyramid(new Point3D(canvas.Width / 2 + 100, canvas.Height / 2, 0), 100, 100, 100));
        }

        /// <summary>
        /// Window load initializer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Set Default Projection Center
            DefaultCenter.x = canvas.Width / 2;
            DefaultCenter.y = canvas.Height / 2;
            DefaultCenter.z = -500;
            Proj.center = DefaultCenter;

            // List all transform buttons for easy resetting
            transformButtons.Add(RotateXBtn);
            transformButtons.Add(RotateYBtn);
            transformButtons.Add(RotateZBtn);
            transformButtons.Add(ScaleBtn);

            // Init Shapes
            ResetShapes();

            // Set Shape Center (for center of transformations)
            ShapeCenter.x = canvas.Width / 2;
            ShapeCenter.y = canvas.Height / 2;
            ShapeCenter.z = 0;

            // Draw initial shapes
            DrawShapes();

        }

        // Uncheck Projection Buttons (UI)
        private void UncheckButtons()
        {
            ProjectionObliqueBtn.Checked = false;
            ProjectionPerspectiveBtn.Checked = false;
            ProjectionParallelBtn.Checked = false;
        }

        // Uncheck Transformation Buttons (UI)
        private void UncheckTransformButtons()
        {
            foreach (ToolStripButton btn in transformButtons)
            {
                btn.Checked = false;
            }
            
        }

        // Oblique button callback
        private void ProjectionObliqueBtn_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            Proj = new Oblique();
            Proj.center = DefaultCenter;
            DrawShapes();
            ProjectionObliqueBtn.Checked = true;
        }

        // Perspective button callback
        private void ProjectionPerspectiveBtn_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            Proj = new Perspective();
            Proj.center = DefaultCenter;
            DrawShapes();
            ProjectionPerspectiveBtn.Checked = true;
        }

        // Parallel Orthographic button callback
        private void ProjectionParallelBtn_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            Proj = new Orthographic();
            Proj.center = DefaultCenter;
            DrawShapes();
            ProjectionParallelBtn.Checked = true;
        }

        // Rotation button callback (x)
        private void RotateXBtn_Click(object sender, EventArgs e)
        {
            UncheckTransformButtons();
            RotateXBtn.Checked = true;
            transformation = new Rotate();
            transformFn  = RotateXAxis;
        }

        // Rotation button callback (Y)
        private void RotateYBtn_Click(object sender, EventArgs e)
        {
            UncheckTransformButtons();
            RotateYBtn.Checked = true;
            transformation = new Rotate();
            transformFn = RotateYAxis;
        }

        // Rotation button callback (Z)
        private void RotateZBtn_Click(object sender, EventArgs e)
        {
            UncheckTransformButtons();
            RotateZBtn.Checked = true;
            transformation = new Rotate();
            transformFn = RotateZAxis;
        }

        // Canvas mousedown callback
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            canvasMouseDown = true;
            lastDown = e;
        }

        // Canvas mouseup callback
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            canvasMouseDown = false;
            lastDown = null;
        }

        // Canvas mousemove callback
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (canvasMouseDown && lastDown != null && !working)
            {
                working = true;
                if (transformFn != null)
                {
                    bool isScale = transformation.GetType() == typeof(Scale);
                    double distance = isScale && lastDown.X > 0 ? (Convert.ToDouble(e.X) / Convert.ToDouble(lastDown.X) + Convert.ToDouble(lastDown.Y) / Convert.ToDouble(e.Y)) / 2 : lastDown.X - e.X;
                    transformFn(Math.Min(distance, 5));
                    lastDown = false ? lastDown : e;
                    DrawShapes();
                }
                working = false;
            }
        }


        // Rotate X axis
        private void RotateXAxis(double amount)
        {
            foreach (Shape shape in shapes)
            {
                transformation.Transform(shape, new Point3D(amount, 0, 0), ShapeCenter);
            }
        }

        // Rotate Y axis
        private void RotateYAxis(double amount)
        {
            foreach (Shape shape in shapes)
            {
                transformation.Transform(shape, new Point3D(0, amount, 0), ShapeCenter);
            }
        }

        // Rotate Z axis
        private void RotateZAxis(double amount)
        {
            foreach (Shape shape in shapes)
            {
                transformation.Transform(shape, new Point3D(0, 0, amount), ShapeCenter);
            }
        }

        // Scale button callback
        private void ScaleBtn_Click(object sender, EventArgs e)
        {
            UncheckTransformButtons();
            ScaleBtn.Checked = true;
            transformation = new Scale();
            transformFn = ScaleScene;
        }

        // Scale scene
        private void ScaleScene(double amount)
        {
            foreach (Shape shape in shapes)
            {
                transformation.Transform(shape, new Point3D(amount, amount, amount), ShapeCenter);
            }
        }

        // Reset shapes button callback
        private void ResetShapesBtn_Click(object sender, EventArgs e)
        {
            ResetShapes();
            DrawShapes();
        }

        // Toggle wireframe view
        private void toggleWireframeBtn_Click(object sender, EventArgs e)
        {
            wireframe = !wireframe;
            toggleWireframeBtn.Checked = wireframe;
            DrawShapes();
        }
    }
}
