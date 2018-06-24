using Gfx3.GfxObjects;
using Gfx3.Projections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gfx3
{
    public partial class MainWindow : Form
    {
        Point3D DefaultCenter { get; set; } = new Point3D(0, 0, 0);
        Projection Proj { get; set; } = new Perspective();
        List<Shape> shapes = new List<Shape>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawShapes()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            foreach (Shape shape in shapes)
            {
                List<Polygon3D> polygons = shape.GetPolygons();
                foreach (Polygon3D pg in polygons)
                {
                    List<Point> pts = Proj.Translate(pg.Points);
                    using (Graphics gfx = Graphics.FromImage(bmp))
                    {
                        gfx.FillPolygon(new SolidBrush(pg.FillColor), pts.ToArray());
                        gfx.DrawPolygon(new Pen(pg.LineColor), pts.ToArray());
                    }

                }
            }

            pictureBox1.Image?.Dispose();
            pictureBox1.Image = bmp;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            DefaultCenter.x = pictureBox1.Width / 2;
            DefaultCenter.y = pictureBox1.Height / 2;
            DefaultCenter.z = -2000;
            Proj.center = DefaultCenter;
            
            shapes.Add(new Box(new Point3D(pictureBox1.Width / 2 - 100, pictureBox1.Height / 2, 100), 100, 100, 100, 45, 10, 74));
            shapes.Add(new Pyramid(new Point3D(pictureBox1.Width / 2 + 100, pictureBox1.Height / 2, 100), 100, 100, 100));

            DrawShapes();



            //using (Graphics gfx = Graphics.FromImage(bmp))
            //{
            //    double scale = 5;
            //    Point[] pts = new Point[3];
            //    Point[] pts2 = new Point[3];
            //    pts[0] = new Point(Convert.ToInt32(0 * scale), Convert.ToInt32(0 * scale));
            //    pts[1] = new Point(Convert.ToInt32(0 * scale), Convert.ToInt32(50 * scale));
            //    pts[2] = new Point(Convert.ToInt32(50 * scale), Convert.ToInt32(50 * scale));
            //    pts2[0] = pts[0];
            //    pts2[1] = pts[2];
            //    pts2[2] = new Point(Convert.ToInt32(50 * scale), Convert.ToInt32(0 * scale));
            //    gfx.FillPolygon(new SolidBrush(Color.Red), pts);
            //    gfx.FillPolygon(new SolidBrush(Color.Red), pts2);
            //    gfx.DrawPolygon(new Pen(Color.White, 2), pts);
            //    gfx.DrawPolygon(new Pen(Color.White, 2), pts2);
            //    pictureBox1.Image?.Dispose();
            //    pictureBox1.Image = bmp;
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void UncheckButtons()
        {
            ProjectionObliqueBtn.Checked = false;
            ProjectionPerspectiveBtn.Checked = false;
            ProjectionParallelBtn.Checked = false;
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
    }
}
