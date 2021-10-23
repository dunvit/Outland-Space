
namespace OutlandSpaceClient.UI.Controls
{
    partial class ControlTacticalMap
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
            this.imageTacticalMap = new System.Windows.Forms.PictureBox();
            this.lblFps = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageTacticalMap)).BeginInit();
            this.SuspendLayout();
            // 
            // imageTacticalMap
            // 
            this.imageTacticalMap.BackColor = System.Drawing.Color.Black;
            this.imageTacticalMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageTacticalMap.Location = new System.Drawing.Point(33, 24);
            this.imageTacticalMap.Name = "imageTacticalMap";
            this.imageTacticalMap.Size = new System.Drawing.Size(83, 74);
            this.imageTacticalMap.TabIndex = 0;
            this.imageTacticalMap.TabStop = false;
            // 
            // lblFps
            // 
            this.lblFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFps.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblFps.Location = new System.Drawing.Point(5, 131);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(65, 15);
            this.lblFps.TabIndex = 1;
            this.lblFps.Text = "label1";
            // 
            // ControlTacticalMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lblFps);
            this.Controls.Add(this.imageTacticalMap);
            this.Name = "ControlTacticalMap";
            ((System.ComponentModel.ISupportInitialize)(this.imageTacticalMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageTacticalMap;
        private System.Windows.Forms.Label lblFps;
    }
}
