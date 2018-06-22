namespace Gfx3
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.toolChain = new System.Windows.Forms.ToolStrip();
            this.ProjectionPerspectiveBtn = new System.Windows.Forms.ToolStripButton();
            this.ProjectionParallelBtn = new System.Windows.Forms.ToolStripButton();
            this.ProjectionObliqueBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ProjectionLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.RotateXBtn = new System.Windows.Forms.ToolStripButton();
            this.RotateYBtn = new System.Windows.Forms.ToolStripButton();
            this.RotateZBtn = new System.Windows.Forms.ToolStripButton();
            this.toolChain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolChain
            // 
            this.toolChain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProjectionLabel,
            this.ProjectionPerspectiveBtn,
            this.ProjectionParallelBtn,
            this.ProjectionObliqueBtn,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.RotateXBtn,
            this.RotateYBtn,
            this.RotateZBtn});
            this.toolChain.Location = new System.Drawing.Point(0, 0);
            this.toolChain.Name = "toolChain";
            this.toolChain.Size = new System.Drawing.Size(1264, 29);
            this.toolChain.TabIndex = 0;
            this.toolChain.Text = "toolStrip1";
            // 
            // ProjectionPerspectiveBtn
            // 
            this.ProjectionPerspectiveBtn.BackColor = System.Drawing.SystemColors.Control;
            this.ProjectionPerspectiveBtn.Checked = true;
            this.ProjectionPerspectiveBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ProjectionPerspectiveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ProjectionPerspectiveBtn.Image = ((System.Drawing.Image)(resources.GetObject("ProjectionPerspectiveBtn.Image")));
            this.ProjectionPerspectiveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProjectionPerspectiveBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ProjectionPerspectiveBtn.Name = "ProjectionPerspectiveBtn";
            this.ProjectionPerspectiveBtn.Size = new System.Drawing.Size(71, 19);
            this.ProjectionPerspectiveBtn.Text = "Perspective";
            this.ProjectionPerspectiveBtn.ToolTipText = "Parallel Projection";
            this.ProjectionPerspectiveBtn.Click += new System.EventHandler(this.ProjectionPerspectiveBtn_Click);
            // 
            // ProjectionParallelBtn
            // 
            this.ProjectionParallelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ProjectionParallelBtn.Image = ((System.Drawing.Image)(resources.GetObject("ProjectionParallelBtn.Image")));
            this.ProjectionParallelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProjectionParallelBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ProjectionParallelBtn.Name = "ProjectionParallelBtn";
            this.ProjectionParallelBtn.Size = new System.Drawing.Size(49, 19);
            this.ProjectionParallelBtn.Text = "Parallel";
            this.ProjectionParallelBtn.ToolTipText = "Parallel Projection";
            this.ProjectionParallelBtn.Click += new System.EventHandler(this.ProjectionParallelBtn_Click);
            // 
            // ProjectionObliqueBtn
            // 
            this.ProjectionObliqueBtn.CheckOnClick = true;
            this.ProjectionObliqueBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ProjectionObliqueBtn.Image = ((System.Drawing.Image)(resources.GetObject("ProjectionObliqueBtn.Image")));
            this.ProjectionObliqueBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProjectionObliqueBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ProjectionObliqueBtn.Name = "ProjectionObliqueBtn";
            this.ProjectionObliqueBtn.Size = new System.Drawing.Size(53, 19);
            this.ProjectionObliqueBtn.Text = "Oblique";
            this.ProjectionObliqueBtn.ToolTipText = "Parallel Projection";
            this.ProjectionObliqueBtn.Click += new System.EventHandler(this.ProjectionObliqueBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(13, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1239, 680);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ProjectionLabel
            // 
            this.ProjectionLabel.Margin = new System.Windows.Forms.Padding(5);
            this.ProjectionLabel.Name = "ProjectionLabel";
            this.ProjectionLabel.Size = new System.Drawing.Size(64, 19);
            this.ProjectionLabel.Text = "Projection:";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 26);
            this.toolStripLabel1.Text = "Transformations:";
            // 
            // RotateXBtn
            // 
            this.RotateXBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RotateXBtn.Image = ((System.Drawing.Image)(resources.GetObject("RotateXBtn.Image")));
            this.RotateXBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RotateXBtn.Name = "RotateXBtn";
            this.RotateXBtn.Size = new System.Drawing.Size(23, 26);
            this.RotateXBtn.Text = "toolStripButton1";
            // 
            // RotateYBtn
            // 
            this.RotateYBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RotateYBtn.Image = ((System.Drawing.Image)(resources.GetObject("RotateYBtn.Image")));
            this.RotateYBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RotateYBtn.Name = "RotateYBtn";
            this.RotateYBtn.Size = new System.Drawing.Size(23, 26);
            this.RotateYBtn.Text = "toolStripButton1";
            // 
            // RotateZBtn
            // 
            this.RotateZBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RotateZBtn.Image = ((System.Drawing.Image)(resources.GetObject("RotateZBtn.Image")));
            this.RotateZBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RotateZBtn.Name = "RotateZBtn";
            this.RotateZBtn.Size = new System.Drawing.Size(23, 26);
            this.RotateZBtn.Text = "toolStripButton1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 721);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolChain);
            this.Name = "MainWindow";
            this.Text = "Gfx Homework 3 - Yftah Livny 066633744 & Edan Hauon 305249187";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.toolChain.ResumeLayout(false);
            this.toolChain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolChain;
        private System.Windows.Forms.ToolStripButton ProjectionObliqueBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton ProjectionParallelBtn;
        private System.Windows.Forms.ToolStripButton ProjectionPerspectiveBtn;
        private System.Windows.Forms.ToolStripLabel ProjectionLabel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton RotateXBtn;
        private System.Windows.Forms.ToolStripButton RotateYBtn;
        private System.Windows.Forms.ToolStripButton RotateZBtn;
    }
}

