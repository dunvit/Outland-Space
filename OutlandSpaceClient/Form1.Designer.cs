
namespace OutlandSpaceClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdResume = new System.Windows.Forms.Button();
            this.controlDebugInformation1 = new OutlandSpaceClient.UI.Controls.ControlDebugInformation();
            this.crlTacticalMap = new OutlandSpaceClient.UI.Controls.ControlTacticalMap();
            this.controlActiveCelestialObject = new OutlandSpaceClient.UI.Controls.ControlActiveCelestialObject();
            this.crlDebugCommands = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.crlDebugCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdResume
            // 
            this.cmdResume.Location = new System.Drawing.Point(12, 12);
            this.cmdResume.Name = "cmdResume";
            this.cmdResume.Size = new System.Drawing.Size(75, 23);
            this.cmdResume.TabIndex = 1;
            this.cmdResume.Text = "Resume";
            this.cmdResume.UseVisualStyleBackColor = true;
            this.cmdResume.Click += new System.EventHandler(this.cmdResume_Click);
            // 
            // controlDebugInformation1
            // 
            this.controlDebugInformation1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.controlDebugInformation1.Location = new System.Drawing.Point(1039, 604);
            this.controlDebugInformation1.Name = "controlDebugInformation1";
            this.controlDebugInformation1.Size = new System.Drawing.Size(251, 157);
            this.controlDebugInformation1.TabIndex = 7;
            // 
            // crlTacticalMap
            // 
            this.crlTacticalMap.BackColor = System.Drawing.Color.Black;
            this.crlTacticalMap.Location = new System.Drawing.Point(436, 161);
            this.crlTacticalMap.Name = "crlTacticalMap";
            this.crlTacticalMap.Size = new System.Drawing.Size(150, 150);
            this.crlTacticalMap.TabIndex = 8;
            // 
            // controlActiveCelestialObject
            // 
            this.controlActiveCelestialObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlActiveCelestialObject.Location = new System.Drawing.Point(1056, 12);
            this.controlActiveCelestialObject.Name = "controlActiveCelestialObject";
            this.controlActiveCelestialObject.Size = new System.Drawing.Size(234, 172);
            this.controlActiveCelestialObject.TabIndex = 9;
            this.controlActiveCelestialObject.Visible = false;
            // 
            // crlDebugCommands
            // 
            this.crlDebugCommands.BackColor = System.Drawing.Color.Black;
            this.crlDebugCommands.Controls.Add(this.button1);
            this.crlDebugCommands.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.crlDebugCommands.ForeColor = System.Drawing.Color.DarkOrange;
            this.crlDebugCommands.Location = new System.Drawing.Point(22, 83);
            this.crlDebugCommands.Name = "crlDebugCommands";
            this.crlDebugCommands.Size = new System.Drawing.Size(183, 157);
            this.crlDebugCommands.TabIndex = 10;
            this.crlDebugCommands.TabStop = false;
            this.crlDebugCommands.Text = "Debug Commands";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Linen;
            this.button1.Location = new System.Drawing.Point(6, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Object Found";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 773);
            this.Controls.Add(this.crlDebugCommands);
            this.Controls.Add(this.controlActiveCelestialObject);
            this.Controls.Add(this.controlDebugInformation1);
            this.Controls.Add(this.cmdResume);
            this.Controls.Add(this.crlTacticalMap);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.crlDebugCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdResume;
        private UI.Controls.ControlDebugInformation controlDebugInformation1;
        private UI.Controls.ControlTacticalMap crlTacticalMap;
        private UI.Controls.ControlActiveCelestialObject controlActiveCelestialObject;
        private System.Windows.Forms.GroupBox crlDebugCommands;
        private System.Windows.Forms.Button button1;
    }
}

