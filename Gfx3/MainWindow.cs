using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace Gfx3
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
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
            ProjectionObliqueBtn.Checked = true;
        }

        private void ProjectionPerspectiveBtn_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            ProjectionPerspectiveBtn.Checked = true;
        }

        private void ProjectionParallelBtn_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            ProjectionParallelBtn.Checked = true;
        }
    }
}
