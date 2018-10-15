namespace ShapeDrawingWF
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lbMousePos = new System.Windows.Forms.Label();
            this.groupShape = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHyperA = new System.Windows.Forms.TextBox();
            this.rbtHypebole = new System.Windows.Forms.RadioButton();
            this.rbtParabola = new System.Windows.Forms.RadioButton();
            this.rbtEllipse = new System.Windows.Forms.RadioButton();
            this.rbtCircle = new System.Windows.Forms.RadioButton();
            this.rbtLine = new System.Windows.Forms.RadioButton();
            this.groupAlgorithm = new System.Windows.Forms.GroupBox();
            this.rbtXiaolin = new System.Windows.Forms.RadioButton();
            this.rbtMidpoint = new System.Windows.Forms.RadioButton();
            this.rbtBresenham = new System.Windows.Forms.RadioButton();
            this.rbtDDA = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupShape.SuspendLayout();
            this.groupAlgorithm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(120, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(880, 600);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(0, 483);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(114, 30);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Clear Screen";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbMousePos
            // 
            this.lbMousePos.AutoSize = true;
            this.lbMousePos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbMousePos.Location = new System.Drawing.Point(40, 516);
            this.lbMousePos.Name = "lbMousePos";
            this.lbMousePos.Size = new System.Drawing.Size(29, 17);
            this.lbMousePos.TabIndex = 3;
            this.lbMousePos.Text = "x, y";
            // 
            // groupShape
            // 
            this.groupShape.Controls.Add(this.label1);
            this.groupShape.Controls.Add(this.tbHyperA);
            this.groupShape.Controls.Add(this.rbtHypebole);
            this.groupShape.Controls.Add(this.rbtParabola);
            this.groupShape.Controls.Add(this.rbtEllipse);
            this.groupShape.Controls.Add(this.rbtCircle);
            this.groupShape.Controls.Add(this.rbtLine);
            this.groupShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupShape.Location = new System.Drawing.Point(2, 12);
            this.groupShape.Name = "groupShape";
            this.groupShape.Size = new System.Drawing.Size(114, 248);
            this.groupShape.TabIndex = 4;
            this.groupShape.TabStop = false;
            this.groupShape.Text = "Shape";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(26, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "a:";
            // 
            // tbHyperA
            // 
            this.tbHyperA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbHyperA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbHyperA.Location = new System.Drawing.Point(51, 197);
            this.tbHyperA.Name = "tbHyperA";
            this.tbHyperA.Size = new System.Drawing.Size(48, 22);
            this.tbHyperA.TabIndex = 5;
            this.tbHyperA.Text = "10";
            // 
            // rbtHypebole
            // 
            this.rbtHypebole.AutoSize = true;
            this.rbtHypebole.Location = new System.Drawing.Point(7, 173);
            this.rbtHypebole.Name = "rbtHypebole";
            this.rbtHypebole.Size = new System.Drawing.Size(99, 20);
            this.rbtHypebole.TabIndex = 4;
            this.rbtHypebole.TabStop = true;
            this.rbtHypebole.Text = "Hyperbole";
            this.rbtHypebole.UseVisualStyleBackColor = true;
            this.rbtHypebole.CheckedChanged += new System.EventHandler(this.rbtHypebole_CheckedChanged);
            // 
            // rbtParabola
            // 
            this.rbtParabola.AutoSize = true;
            this.rbtParabola.Location = new System.Drawing.Point(7, 134);
            this.rbtParabola.Name = "rbtParabola";
            this.rbtParabola.Size = new System.Drawing.Size(90, 20);
            this.rbtParabola.TabIndex = 3;
            this.rbtParabola.TabStop = true;
            this.rbtParabola.Text = "Parabola";
            this.rbtParabola.UseVisualStyleBackColor = true;
            this.rbtParabola.CheckedChanged += new System.EventHandler(this.rbtParabola_CheckedChanged);
            // 
            // rbtEllipse
            // 
            this.rbtEllipse.AutoSize = true;
            this.rbtEllipse.Location = new System.Drawing.Point(7, 98);
            this.rbtEllipse.Name = "rbtEllipse";
            this.rbtEllipse.Size = new System.Drawing.Size(74, 20);
            this.rbtEllipse.TabIndex = 2;
            this.rbtEllipse.TabStop = true;
            this.rbtEllipse.Text = "Ellipse";
            this.rbtEllipse.UseVisualStyleBackColor = true;
            this.rbtEllipse.CheckedChanged += new System.EventHandler(this.rbtEllipse_CheckedChanged);
            // 
            // rbtCircle
            // 
            this.rbtCircle.AutoSize = true;
            this.rbtCircle.Location = new System.Drawing.Point(7, 65);
            this.rbtCircle.Name = "rbtCircle";
            this.rbtCircle.Size = new System.Drawing.Size(66, 20);
            this.rbtCircle.TabIndex = 1;
            this.rbtCircle.TabStop = true;
            this.rbtCircle.Text = "Circle";
            this.rbtCircle.UseVisualStyleBackColor = true;
            this.rbtCircle.CheckedChanged += new System.EventHandler(this.rbtCircle_CheckedChanged);
            // 
            // rbtLine
            // 
            this.rbtLine.AutoSize = true;
            this.rbtLine.Location = new System.Drawing.Point(7, 31);
            this.rbtLine.Name = "rbtLine";
            this.rbtLine.Size = new System.Drawing.Size(55, 20);
            this.rbtLine.TabIndex = 0;
            this.rbtLine.TabStop = true;
            this.rbtLine.Text = "Line";
            this.rbtLine.UseVisualStyleBackColor = true;
            this.rbtLine.CheckedChanged += new System.EventHandler(this.rbtLine_CheckedChanged);
            // 
            // groupAlgorithm
            // 
            this.groupAlgorithm.Controls.Add(this.rbtXiaolin);
            this.groupAlgorithm.Controls.Add(this.rbtMidpoint);
            this.groupAlgorithm.Controls.Add(this.rbtBresenham);
            this.groupAlgorithm.Controls.Add(this.rbtDDA);
            this.groupAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAlgorithm.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupAlgorithm.Location = new System.Drawing.Point(2, 266);
            this.groupAlgorithm.Name = "groupAlgorithm";
            this.groupAlgorithm.Size = new System.Drawing.Size(114, 194);
            this.groupAlgorithm.TabIndex = 5;
            this.groupAlgorithm.TabStop = false;
            this.groupAlgorithm.Text = "Algorithm";
            // 
            // rbtXiaolin
            // 
            this.rbtXiaolin.AutoSize = true;
            this.rbtXiaolin.Location = new System.Drawing.Point(7, 128);
            this.rbtXiaolin.Name = "rbtXiaolin";
            this.rbtXiaolin.Size = new System.Drawing.Size(99, 20);
            this.rbtXiaolin.TabIndex = 3;
            this.rbtXiaolin.TabStop = true;
            this.rbtXiaolin.Text = "Xiaolin Wu";
            this.rbtXiaolin.UseVisualStyleBackColor = true;
            this.rbtXiaolin.CheckedChanged += new System.EventHandler(this.rbtXiaolin_CheckedChanged);
            // 
            // rbtMidpoint
            // 
            this.rbtMidpoint.AutoSize = true;
            this.rbtMidpoint.Location = new System.Drawing.Point(7, 100);
            this.rbtMidpoint.Name = "rbtMidpoint";
            this.rbtMidpoint.Size = new System.Drawing.Size(86, 20);
            this.rbtMidpoint.TabIndex = 2;
            this.rbtMidpoint.TabStop = true;
            this.rbtMidpoint.Text = "MidPoint";
            this.rbtMidpoint.UseVisualStyleBackColor = true;
            this.rbtMidpoint.CheckedChanged += new System.EventHandler(this.rbtMidpoint_CheckedChanged);
            // 
            // rbtBresenham
            // 
            this.rbtBresenham.AutoSize = true;
            this.rbtBresenham.Location = new System.Drawing.Point(7, 68);
            this.rbtBresenham.Name = "rbtBresenham";
            this.rbtBresenham.Size = new System.Drawing.Size(104, 20);
            this.rbtBresenham.TabIndex = 1;
            this.rbtBresenham.TabStop = true;
            this.rbtBresenham.Text = "Bresenham";
            this.rbtBresenham.UseVisualStyleBackColor = true;
            this.rbtBresenham.CheckedChanged += new System.EventHandler(this.rbtBresenham_CheckedChanged);
            // 
            // rbtDDA
            // 
            this.rbtDDA.AutoSize = true;
            this.rbtDDA.Location = new System.Drawing.Point(7, 36);
            this.rbtDDA.Name = "rbtDDA";
            this.rbtDDA.Size = new System.Drawing.Size(58, 20);
            this.rbtDDA.TabIndex = 0;
            this.rbtDDA.TabStop = true;
            this.rbtDDA.Text = "DDA";
            this.rbtDDA.UseVisualStyleBackColor = true;
            this.rbtDDA.CheckedChanged += new System.EventHandler(this.rbtDDA_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.groupAlgorithm);
            this.Controls.Add(this.groupShape);
            this.Controls.Add(this.lbMousePos);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chienfx";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupShape.ResumeLayout(false);
            this.groupShape.PerformLayout();
            this.groupAlgorithm.ResumeLayout(false);
            this.groupAlgorithm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lbMousePos;
        private System.Windows.Forms.GroupBox groupShape;
        private System.Windows.Forms.RadioButton rbtHypebole;
        private System.Windows.Forms.RadioButton rbtParabola;
        private System.Windows.Forms.RadioButton rbtEllipse;
        private System.Windows.Forms.RadioButton rbtCircle;
        private System.Windows.Forms.RadioButton rbtLine;
        private System.Windows.Forms.GroupBox groupAlgorithm;
        private System.Windows.Forms.RadioButton rbtXiaolin;
        private System.Windows.Forms.RadioButton rbtMidpoint;
        private System.Windows.Forms.RadioButton rbtBresenham;
        private System.Windows.Forms.RadioButton rbtDDA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHyperA;
    }
}

