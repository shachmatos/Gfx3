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
            this.ProjectionLabel = new System.Windows.Forms.ToolStripLabel();
            this.ProjectionPerspectiveBtn = new System.Windows.Forms.ToolStripButton();
            this.ProjectionParallelBtn = new System.Windows.Forms.ToolStripButton();
            this.ProjectionObliqueBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rotationLabel = new System.Windows.Forms.ToolStripLabel();
            this.RotateXBtn = new System.Windows.Forms.ToolStripButton();
            this.RotateYBtn = new System.Windows.Forms.ToolStripButton();
            this.RotateZBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ScaleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ResetShapesBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleWireframeBtn = new System.Windows.Forms.ToolStripButton();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.toolChain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
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
            this.rotationLabel,
            this.RotateXBtn,
            this.RotateYBtn,
            this.RotateZBtn,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.ScaleBtn,
            this.toolStripSeparator3,
            this.ResetShapesBtn,
            this.toolStripSeparator4,
            this.toggleWireframeBtn});
            this.toolChain.Location = new System.Drawing.Point(0, 0);
            this.toolChain.Name = "toolChain";
            this.toolChain.Size = new System.Drawing.Size(1264, 29);
            this.toolChain.TabIndex = 0;
            this.toolChain.Text = "toolStrip1";
            // 
            // ProjectionLabel
            // 
            this.ProjectionLabel.Margin = new System.Windows.Forms.Padding(5);
            this.ProjectionLabel.Name = "ProjectionLabel";
            this.ProjectionLabel.Size = new System.Drawing.Size(64, 19);
            this.ProjectionLabel.Text = "Projection:";
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
            this.ProjectionPerspectiveBtn.ToolTipText = "Perspective";
            this.ProjectionPerspectiveBtn.Click += new System.EventHandler(this.ProjectionPerspectiveBtn_Click);
            // 
            // ProjectionParallelBtn
            // 
            this.ProjectionParallelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ProjectionParallelBtn.Image = ((System.Drawing.Image)(resources.GetObject("ProjectionParallelBtn.Image")));
            this.ProjectionParallelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProjectionParallelBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ProjectionParallelBtn.Name = "ProjectionParallelBtn";
            this.ProjectionParallelBtn.Size = new System.Drawing.Size(82, 19);
            this.ProjectionParallelBtn.Text = "Orthographic";
            this.ProjectionParallelBtn.ToolTipText = "Parallel Orthographic";
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
            this.ProjectionObliqueBtn.ToolTipText = "Parallel Oblique";
            this.ProjectionObliqueBtn.Click += new System.EventHandler(this.ProjectionObliqueBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // rotationLabel
            // 
            this.rotationLabel.Margin = new System.Windows.Forms.Padding(5);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(174, 19);
            this.rotationLabel.Text = "Rotate (drag mouse on canvas):";
            // 
            // RotateXBtn
            // 
            this.RotateXBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RotateXBtn.Image = ((System.Drawing.Image)(resources.GetObject("RotateXBtn.Image")));
            this.RotateXBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RotateXBtn.Margin = new System.Windows.Forms.Padding(5);
            this.RotateXBtn.Name = "RotateXBtn";
            this.RotateXBtn.Size = new System.Drawing.Size(42, 19);
            this.RotateXBtn.Text = "X Axis";
            this.RotateXBtn.ToolTipText = "Rotate X Axis";
            this.RotateXBtn.Click += new System.EventHandler(this.RotateXBtn_Click);
            // 
            // RotateYBtn
            // 
            this.RotateYBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RotateYBtn.Image = ((System.Drawing.Image)(resources.GetObject("RotateYBtn.Image")));
            this.RotateYBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RotateYBtn.Margin = new System.Windows.Forms.Padding(5);
            this.RotateYBtn.Name = "RotateYBtn";
            this.RotateYBtn.Size = new System.Drawing.Size(42, 19);
            this.RotateYBtn.Text = "Y Axis";
            this.RotateYBtn.ToolTipText = "Rotate Y Axis";
            this.RotateYBtn.Click += new System.EventHandler(this.RotateYBtn_Click);
            // 
            // RotateZBtn
            // 
            this.RotateZBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RotateZBtn.Image = ((System.Drawing.Image)(resources.GetObject("RotateZBtn.Image")));
            this.RotateZBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RotateZBtn.Margin = new System.Windows.Forms.Padding(5);
            this.RotateZBtn.Name = "RotateZBtn";
            this.RotateZBtn.Size = new System.Drawing.Size(42, 19);
            this.RotateZBtn.Text = "Z Axis";
            this.RotateZBtn.ToolTipText = "Rotate Z Axis";
            this.RotateZBtn.Click += new System.EventHandler(this.RotateZBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(167, 19);
            this.toolStripLabel1.Text = "Scale (drag mouse on canvas):";
            // 
            // ScaleBtn
            // 
            this.ScaleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ScaleBtn.Image = ((System.Drawing.Image)(resources.GetObject("ScaleBtn.Image")));
            this.ScaleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScaleBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ScaleBtn.Name = "ScaleBtn";
            this.ScaleBtn.Size = new System.Drawing.Size(38, 19);
            this.ScaleBtn.Text = "Scale";
            this.ScaleBtn.Click += new System.EventHandler(this.ScaleBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // ResetShapesBtn
            // 
            this.ResetShapesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ResetShapesBtn.Image = ((System.Drawing.Image)(resources.GetObject("ResetShapesBtn.Image")));
            this.ResetShapesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResetShapesBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ResetShapesBtn.Name = "ResetShapesBtn";
            this.ResetShapesBtn.Size = new System.Drawing.Size(79, 19);
            this.ResetShapesBtn.Text = "Reset Shapes";
            this.ResetShapesBtn.Click += new System.EventHandler(this.ResetShapesBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // toggleWireframeBtn
            // 
            this.toggleWireframeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toggleWireframeBtn.Image = ((System.Drawing.Image)(resources.GetObject("toggleWireframeBtn.Image")));
            this.toggleWireframeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleWireframeBtn.Margin = new System.Windows.Forms.Padding(5);
            this.toggleWireframeBtn.Name = "toggleWireframeBtn";
            this.toggleWireframeBtn.Size = new System.Drawing.Size(105, 19);
            this.toggleWireframeBtn.Text = "Toggle Wireframe";
            this.toggleWireframeBtn.Click += new System.EventHandler(this.toggleWireframeBtn_Click);
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(13, 29);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1239, 680);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 721);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.toolChain);
            this.Name = "MainWindow";
            this.Text = "Gfx Homework 3 - Yftah Livny 066633744 & Edan Hauon 305249187";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.toolChain.ResumeLayout(false);
            this.toolChain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolChain;
        private System.Windows.Forms.ToolStripButton ProjectionObliqueBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.ToolStripButton ProjectionParallelBtn;
        private System.Windows.Forms.ToolStripButton ProjectionPerspectiveBtn;
        private System.Windows.Forms.ToolStripLabel ProjectionLabel;
        private System.Windows.Forms.ToolStripLabel rotationLabel;
        private System.Windows.Forms.ToolStripButton RotateXBtn;
        private System.Windows.Forms.ToolStripButton RotateYBtn;
        private System.Windows.Forms.ToolStripButton RotateZBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ScaleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ResetShapesBtn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toggleWireframeBtn;
    }
}

