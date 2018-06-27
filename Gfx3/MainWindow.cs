using Gfx3.GfxObjects;
using Gfx3.Projections;
using Gfx3.Transformations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gfx3
{
    delegate void TransformFn(double amount);

    public partial class MainWindow : Form
    {
        Point3D DefaultCenter { get; set; } = new Point3D(0, 0, 0);
        Point3D ShapeCenter { get; set; } = new Point3D(0, 0, 0);
        Projection Proj { get; set; } = new Perspective();
        MouseEventArgs lastDown = null;

        TransformFn transformFn = null;

        Transformation transformation = null;

        List<Shape> shapes = new List<Shape>();

        List<ToolStripButton> transformButtons = new List<ToolStripButton>();

        bool canvasMouseDown = false;
        bool working = false;
        bool wireframe = false;

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
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            // create list to hold polygons
            List<Polygon3D> polygons = new List<Polygon3D>();

            // add polygons of each shape to the polygon list
            foreach (Shape shape in shapes)
            {
                polygons.AddRange(shape.GetPolygons());
            }

            // order by z index
            polygons = polygons.OrderBy(o => o.GetMaxZ()).ToList();

            foreach (Polygon3D s in polygons)
            {
                foreach (Polygon3D p in polygons)
                {
                    if (s == p) continue;
                    if (s.GetMinZ() <= p.GetMaxZ())
                    {
                        
                    }
                }
            }

            // translate (project) points according to selected projection method and draw polygons on canvas
            foreach (Polygon3D pg in polygons)
            {
                List<Point> pts = Proj.Translate(pg.Points);
                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    if (!wireframe)
                        gfx.FillPolygon(new SolidBrush(pg.FillColor), pts.ToArray());
                    gfx.DrawPolygon(new Pen(pg.LineColor), pts.ToArray());
                }

            }

            // replace old canvas
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = bmp;
        }

        private void ResetShapes()
        {
            // clear old shapes
            shapes.Clear();

            // Add Shapes
            shapes.Add(new Box(new Point3D(pictureBox1.Width / 2 - 100, pictureBox1.Height / 2, 0), 100, 100, 100, 45, 10, 74));
            shapes.Add(new Pyramid(new Point3D(pictureBox1.Width / 2 + 100, pictureBox1.Height / 2, 0), 100, 100, 100));
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Set Default Projection Center
            DefaultCenter.x = pictureBox1.Width / 2;
            DefaultCenter.y = pictureBox1.Height / 2;
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
            ShapeCenter.x = pictureBox1.Width / 2;
            ShapeCenter.y = pictureBox1.Height / 2;
            ShapeCenter.z = 0;

            // Draw initial shapes
            DrawShapes();

        }

        private void UncheckButtons()
        {
            ProjectionObliqueBtn.Checked = false;
            ProjectionPerspectiveBtn.Checked = false;
            ProjectionParallelBtn.Checked = false;
        }

        private void UncheckTransformButtons()
        {
            foreach (ToolStripButton btn in transformButtons)
            {
                btn.Checked = false;
            }
            
        }

        private void ProjectionObliqueBtn_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            Proj = new Oblique();
            Proj.center = DefaultCenter;
            DrawShapes();
            ProjectionObliqueBtn.Checked = true;
        }

        private void ProjectionPerspectiveBtn_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            Proj = new Perspective();
            Proj.center = DefaultCenter;
            DrawShapes();
            ProjectionPerspectiveBtn.Checked = true;
        }

        private void ProjectionParallelBtn_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            Proj = new Orthographic();
            Proj.center = DefaultCenter;
            DrawShapes();
            ProjectionParallelBtn.Checked = true;
        }

        private void RotateXBtn_Click(object sender, EventArgs e)
        {
            UncheckTransformButtons();
            RotateXBtn.Checked = true;
            transformation = new Rotate();
            transformFn  = RotateXAxis;
        }

        private void RotateYBtn_Click(object sender, EventArgs e)
        {
            UncheckTransformButtons();
            RotateYBtn.Checked = true;
            transformation = new Rotate();
            transformFn = RotateYAxis;
        }

        private void RotateZBtn_Click(object sender, EventArgs e)
        {
            UncheckTransformButtons();
            RotateZBtn.Checked = true;
            transformation = new Rotate();
            transformFn = RotateZAxis;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            canvasMouseDown = true;
            lastDown = e;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            canvasMouseDown = false;
            lastDown = null;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
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

        private void RotateXAxis(double amount)
        {
            foreach (Shape shape in shapes)
            {
                transformation.Transform(shape, new Point3D(amount, 0, 0), ShapeCenter);
            }
        }

        private void RotateYAxis(double amount)
        {
            foreach (Shape shape in shapes)
            {
                transformation.Transform(shape, new Point3D(0, amount, 0), ShapeCenter);
            }
        }

        private void RotateZAxis(double amount)
        {
            foreach (Shape shape in shapes)
            {
                transformation.Transform(shape, new Point3D(0, 0, amount), ShapeCenter);
            }
        }

        private void ScaleBtn_Click(object sender, EventArgs e)
        {
            UncheckTransformButtons();
            ScaleBtn.Checked = true;
            transformation = new Scale();
            transformFn = ScaleScene;
        }


        private void ScaleScene(double amount)
        {
            foreach (Shape shape in shapes)
            {
                transformation.Transform(shape, new Point3D(amount, amount, amount), ShapeCenter);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ResetShapes();
            DrawShapes();
        }
    }
}
