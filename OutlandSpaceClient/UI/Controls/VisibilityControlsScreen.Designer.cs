
namespace OutlandSpaceClient.UI.Controls
{
    partial class VisibilityControlsScreen
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
            this.controlActiveCelestialObject1 = new OutlandSpaceClient.UI.Controls.ControlActiveCelestialObject();
            this.SuspendLayout();
            // 
            // controlActiveCelestialObject1
            // 
            this.controlActiveCelestialObject1.Location = new System.Drawing.Point(443, 218);
            this.controlActiveCelestialObject1.Name = "controlActiveCelestialObject1";
            this.controlActiveCelestialObject1.Size = new System.Drawing.Size(235, 167);
            this.controlActiveCelestialObject1.TabIndex = 0;
            // 
            // VisibilityControlsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.controlActiveCelestialObject1);
            this.Name = "VisibilityControlsScreen";
            this.Text = "VisibilityControlsScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlActiveCelestialObject controlActiveCelestialObject1;
    }
}