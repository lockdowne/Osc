namespace Osc.Rotch.Editor.Views
{
    partial class TilemapPropertiesView
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtTilemapName = new Telerik.WinControls.UI.RadTextBox();
            this.txtTilemapDescription = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(13, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(39, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Name:";
            this.radLabel1.Click += new System.EventHandler(this.radLabel1_Click);
            // 
            // txtTilemapName
            // 
            this.txtTilemapName.Location = new System.Drawing.Point(152, 12);
            this.txtTilemapName.MaxLength = 100;
            this.txtTilemapName.Name = "txtTilemapName";
            this.txtTilemapName.Size = new System.Drawing.Size(226, 20);
            this.txtTilemapName.TabIndex = 1;
            this.txtTilemapName.TextChanged += new System.EventHandler(this.txtTilemapName_TextChanged);
            // 
            // txtTilemapDescription
            // 
            this.txtTilemapDescription.AutoSize = false;
            this.txtTilemapDescription.Location = new System.Drawing.Point(152, 38);
            this.txtTilemapDescription.MaxLength = 1000;
            this.txtTilemapDescription.Multiline = true;
            this.txtTilemapDescription.Name = "txtTilemapDescription";
            this.txtTilemapDescription.Size = new System.Drawing.Size(226, 145);
            this.txtTilemapDescription.TabIndex = 3;
            this.txtTilemapDescription.TextChanged += new System.EventHandler(this.txtTilemapDescription_TextChanged);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(13, 39);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(66, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Description:";
            this.radLabel2.Click += new System.EventHandler(this.radLabel2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(155, 189);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 24);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Submit";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(271, 189);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TilemapPropertiesView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(393, 227);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTilemapDescription);
            this.Controls.Add(this.txtTilemapName);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TilemapPropertiesView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Tilemap Properties";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtTilemapName;
        private Telerik.WinControls.UI.RadTextBox txtTilemapDescription;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnOK;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
