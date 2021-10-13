
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmdResume = new System.Windows.Forms.Button();
            this.txtTurn = new System.Windows.Forms.Label();
            this.txtMode = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdResume
            // 
            this.cmdResume.Location = new System.Drawing.Point(713, 415);
            this.cmdResume.Name = "cmdResume";
            this.cmdResume.Size = new System.Drawing.Size(75, 23);
            this.cmdResume.TabIndex = 1;
            this.cmdResume.Text = "Resume";
            this.cmdResume.UseVisualStyleBackColor = true;
            this.cmdResume.Click += new System.EventHandler(this.cmdResume_Click);
            // 
            // txtTurn
            // 
            this.txtTurn.AutoSize = true;
            this.txtTurn.Location = new System.Drawing.Point(229, 34);
            this.txtTurn.Name = "txtTurn";
            this.txtTurn.Size = new System.Drawing.Size(38, 15);
            this.txtTurn.TabIndex = 2;
            this.txtTurn.Text = "label1";
            // 
            // txtMode
            // 
            this.txtMode.AutoSize = true;
            this.txtMode.Location = new System.Drawing.Point(229, 60);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(38, 15);
            this.txtMode.TabIndex = 2;
            this.txtMode.Text = "label1";
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Location = new System.Drawing.Point(229, 85);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(38, 15);
            this.txtId.TabIndex = 2;
            this.txtId.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtMode);
            this.Controls.Add(this.txtTurn);
            this.Controls.Add(this.cmdResume);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdResume;
        private System.Windows.Forms.Label txtTurn;
        private System.Windows.Forms.Label txtMode;
        private System.Windows.Forms.Label txtId;
    }
}

