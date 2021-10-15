
namespace OutlandSpaceClient.UI.Controls
{
    partial class TacticalMap
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
            this.txtTurn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTurn
            // 
            this.txtTurn.AutoSize = true;
            this.txtTurn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTurn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtTurn.Location = new System.Drawing.Point(0, 135);
            this.txtTurn.Name = "txtTurn";
            this.txtTurn.Size = new System.Drawing.Size(38, 15);
            this.txtTurn.TabIndex = 0;
            this.txtTurn.Text = "label1";
            // 
            // TacticalMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.txtTurn);
            this.DoubleBuffered = true;
            this.Name = "TacticalMap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtTurn;
    }
}
