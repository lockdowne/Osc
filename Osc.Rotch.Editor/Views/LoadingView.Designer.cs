namespace Osc.Rotch.Editor.Views
{
    partial class LoadingView
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
            this.progressIndicator1 = new Osc.Rotch.Editor.Controls.ProgressIndicator();
            this.SuspendLayout();
            // 
            // progressIndicator1
            // 
            this.progressIndicator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressIndicator1.Location = new System.Drawing.Point(0, 0);
            this.progressIndicator1.Name = "progressIndicator1";
            this.progressIndicator1.Percentage = 0F;
            this.progressIndicator1.Size = new System.Drawing.Size(183, 183);
            this.progressIndicator1.TabIndex = 0;
            this.progressIndicator1.Text = "progressIndicator1";
            // 
            // LoadingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(183, 179);
            this.Controls.Add(this.progressIndicator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingView";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ProgressIndicator progressIndicator1;


    }
}
