
namespace OutlandSpaceClient.UI.Controls
{
    partial class ControlActiveCelestialObject
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblExitScreen = new System.Windows.Forms.Label();
            this.lblCelestialObjectClass = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCelestialObjectAngle = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCelestialObjectName = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblCelestialObjecVelocity = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 182);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblExitScreen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 24);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Inconsolata", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Celestial Object Telemetry";
            // 
            // lblExitScreen
            // 
            this.lblExitScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExitScreen.Font = new System.Drawing.Font("Inconsolata", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblExitScreen.ForeColor = System.Drawing.Color.Silver;
            this.lblExitScreen.Location = new System.Drawing.Point(211, 3);
            this.lblExitScreen.Name = "lblExitScreen";
            this.lblExitScreen.Size = new System.Drawing.Size(16, 18);
            this.lblExitScreen.TabIndex = 2;
            this.lblExitScreen.Text = "x";
            this.lblExitScreen.Click += new System.EventHandler(this.lblExitScreen_Click);
            this.lblExitScreen.MouseEnter += new System.EventHandler(this.lblExitScreen_MouseEnter);
            this.lblExitScreen.MouseLeave += new System.EventHandler(this.lblExitScreen_MouseLeave);
            // 
            // lblCelestialObjectClass
            // 
            this.lblCelestialObjectClass.BackColor = System.Drawing.Color.Transparent;
            this.lblCelestialObjectClass.Font = new System.Drawing.Font("Inconsolata", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCelestialObjectClass.ForeColor = System.Drawing.Color.Maroon;
            this.lblCelestialObjectClass.Location = new System.Drawing.Point(88, 100);
            this.lblCelestialObjectClass.Name = "lblCelestialObjectClass";
            this.lblCelestialObjectClass.Size = new System.Drawing.Size(142, 14);
            this.lblCelestialObjectClass.TabIndex = 20;
            this.lblCelestialObjectClass.Text = "label1";
            this.lblCelestialObjectClass.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DimGray;
            this.panel6.Location = new System.Drawing.Point(6, 114);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(224, 6);
            this.panel6.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Inconsolata", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 14);
            this.label8.TabIndex = 21;
            this.label8.Text = "Class:";
            // 
            // lblCelestialObjectAngle
            // 
            this.lblCelestialObjectAngle.BackColor = System.Drawing.Color.Transparent;
            this.lblCelestialObjectAngle.Font = new System.Drawing.Font("Inconsolata", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCelestialObjectAngle.ForeColor = System.Drawing.Color.Maroon;
            this.lblCelestialObjectAngle.Location = new System.Drawing.Point(88, 70);
            this.lblCelestialObjectAngle.Name = "lblCelestialObjectAngle";
            this.lblCelestialObjectAngle.Size = new System.Drawing.Size(142, 14);
            this.lblCelestialObjectAngle.TabIndex = 14;
            this.lblCelestialObjectAngle.Text = "label1";
            this.lblCelestialObjectAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Location = new System.Drawing.Point(6, 84);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(224, 6);
            this.panel5.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Inconsolata", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "Angle:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Location = new System.Drawing.Point(6, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 6);
            this.panel4.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Inconsolata", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "Velocity:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(6, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(224, 6);
            this.panel3.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Inconsolata", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name:";
            // 
            // lblCelestialObjectName
            // 
            this.lblCelestialObjectName.BackColor = System.Drawing.Color.Transparent;
            this.lblCelestialObjectName.Font = new System.Drawing.Font("Inconsolata", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCelestialObjectName.ForeColor = System.Drawing.Color.Maroon;
            this.lblCelestialObjectName.Location = new System.Drawing.Point(88, 6);
            this.lblCelestialObjectName.Name = "lblCelestialObjectName";
            this.lblCelestialObjectName.Size = new System.Drawing.Size(142, 14);
            this.lblCelestialObjectName.TabIndex = 11;
            this.lblCelestialObjectName.Text = "label1";
            this.lblCelestialObjectName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel7
            // 
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel7.Controls.Add(this.lblCelestialObjecVelocity);
            this.panel7.Controls.Add(this.panel3);
            this.panel7.Controls.Add(this.lblCelestialObjectClass);
            this.panel7.Controls.Add(this.lblCelestialObjectName);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.lblCelestialObjectAngle);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.panel5);
            this.panel7.Controls.Add(this.panel4);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Location = new System.Drawing.Point(-1, 23);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(234, 158);
            this.panel7.TabIndex = 23;
            // 
            // lblCelestialObjecVelocity
            // 
            this.lblCelestialObjecVelocity.BackColor = System.Drawing.Color.Transparent;
            this.lblCelestialObjecVelocity.Font = new System.Drawing.Font("Inconsolata", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCelestialObjecVelocity.ForeColor = System.Drawing.Color.Maroon;
            this.lblCelestialObjecVelocity.Location = new System.Drawing.Point(89, 40);
            this.lblCelestialObjecVelocity.Name = "lblCelestialObjecVelocity";
            this.lblCelestialObjecVelocity.Size = new System.Drawing.Size(142, 14);
            this.lblCelestialObjecVelocity.TabIndex = 16;
            this.lblCelestialObjecVelocity.Text = "label1";
            this.lblCelestialObjecVelocity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ControlActiveCelestialObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "ControlActiveCelestialObject";
            this.Size = new System.Drawing.Size(236, 182);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Event_Paint);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblExitScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCelestialObjectClass;
        private System.Windows.Forms.Label lblCelestialObjectName;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCelestialObjectAngle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCelestialObjecVelocity;
    }
}
