namespace FractalLockBits
{
    partial class Form1
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
            this.btnShowPalatte = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.btnDrawOriginal = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.lblZoom = new System.Windows.Forms.Label();
            this.btnFullscreen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoxColoringMethods = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnShowControls = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowPalatte
            // 
            this.btnShowPalatte.Location = new System.Drawing.Point(115, 619);
            this.btnShowPalatte.Name = "btnShowPalatte";
            this.btnShowPalatte.Size = new System.Drawing.Size(96, 40);
            this.btnShowPalatte.TabIndex = 0;
            this.btnShowPalatte.Text = "Draw color palatte";
            this.btnShowPalatte.UseVisualStyleBackColor = true;
            this.btnShowPalatte.Click += new System.EventHandler(this.btnShowPalatte_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.AutoSize = true;
            this.lblCoordinates.Location = new System.Drawing.Point(541, 624);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(137, 65);
            this.lblCoordinates.TabIndex = 2;
            this.lblCoordinates.Text = "Screen coordinates\r\nX = 0  |  Y = 0\r\n\r\nComplex  plane coordinates\r\nX = 0  |  Im =" +
                " 0";
            // 
            // btnDrawOriginal
            // 
            this.btnDrawOriginal.Location = new System.Drawing.Point(12, 619);
            this.btnDrawOriginal.Name = "btnDrawOriginal";
            this.btnDrawOriginal.Size = new System.Drawing.Size(97, 40);
            this.btnDrawOriginal.TabIndex = 3;
            this.btnDrawOriginal.Text = "Genrate Madelbrot set";
            this.btnDrawOriginal.UseVisualStyleBackColor = true;
            this.btnDrawOriginal.Click += new System.EventHandler(this.btnDrawOriginal_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(115, 665);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 40);
            this.btnUndo.TabIndex = 4;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(541, 689);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(46, 13);
            this.lblZoom.TabIndex = 5;
            this.lblZoom.Text = "Zoom = ";
            // 
            // btnFullscreen
            // 
            this.btnFullscreen.Location = new System.Drawing.Point(13, 665);
            this.btnFullscreen.Name = "btnFullscreen";
            this.btnFullscreen.Size = new System.Drawing.Size(96, 40);
            this.btnFullscreen.TabIndex = 6;
            this.btnFullscreen.Text = "Fullscreen";
            this.btnFullscreen.UseVisualStyleBackColor = true;
            this.btnFullscreen.Click += new System.EventHandler(this.btnFullscreen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 619);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Coloring method";
            // 
            // cmbBoxColoringMethods
            // 
            this.cmbBoxColoringMethods.FormattingEnabled = true;
            this.cmbBoxColoringMethods.Items.AddRange(new object[] {
            "Iterations With Smoothing",
            "Red Stripes"});
            this.cmbBoxColoringMethods.Location = new System.Drawing.Point(319, 635);
            this.cmbBoxColoringMethods.Name = "cmbBoxColoringMethods";
            this.cmbBoxColoringMethods.Size = new System.Drawing.Size(146, 21);
            this.cmbBoxColoringMethods.TabIndex = 8;
            this.cmbBoxColoringMethods.Text = "Iterations with smoothing";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(217, 619);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 40);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnShowControls
            // 
            this.btnShowControls.Location = new System.Drawing.Point(217, 665);
            this.btnShowControls.Name = "btnShowControls";
            this.btnShowControls.Size = new System.Drawing.Size(96, 40);
            this.btnShowControls.TabIndex = 10;
            this.btnShowControls.Text = "Show Keyboard Controls";
            this.btnShowControls.UseVisualStyleBackColor = true;
            this.btnShowControls.Click += new System.EventHandler(this.btnShowControls_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 709);
            this.Controls.Add(this.btnShowControls);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbBoxColoringMethods);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFullscreen);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnDrawOriginal);
            this.Controls.Add(this.lblCoordinates);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnShowPalatte);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Madelbort Set";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowPalatte;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.Button btnDrawOriginal;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Button btnFullscreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoxColoringMethods;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnShowControls;
    }
}

