
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 773);
            this.Controls.Add(this.controlDebugInformation1);
            this.Controls.Add(this.cmdResume);
            this.Controls.Add(this.crlTacticalMap);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdResume;
        private UI.Controls.ControlDebugInformation controlDebugInformation1;
        private UI.Controls.ControlTacticalMap crlTacticalMap;
    }
}

