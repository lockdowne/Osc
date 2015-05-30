namespace oEditor.Views
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
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtTilemapWidth = new System.Windows.Forms.NumericUpDown();
            this.txtTilemapHeight = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapHeight)).BeginInit();
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
            // 
            // txtTilemapName
            // 
            this.txtTilemapName.Location = new System.Drawing.Point(152, 12);
            this.txtTilemapName.MaxLength = 100;
            this.txtTilemapName.Name = "txtTilemapName";
            this.txtTilemapName.Size = new System.Drawing.Size(226, 20);
            this.txtTilemapName.TabIndex = 1;
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
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(13, 39);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(66, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Description:";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(13, 190);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(39, 18);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Width:";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(13, 216);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(42, 18);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "Height:";
            // 
            // txtTilemapWidth
            // 
            this.txtTilemapWidth.Location = new System.Drawing.Point(152, 190);
            this.txtTilemapWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTilemapWidth.Name = "txtTilemapWidth";
            this.txtTilemapWidth.Size = new System.Drawing.Size(226, 20);
            this.txtTilemapWidth.TabIndex = 7;
            this.txtTilemapWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTilemapHeight
            // 
            this.txtTilemapHeight.Location = new System.Drawing.Point(152, 216);
            this.txtTilemapHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTilemapHeight.Name = "txtTilemapHeight";
            this.txtTilemapHeight.Size = new System.Drawing.Size(226, 20);
            this.txtTilemapHeight.TabIndex = 8;
            this.txtTilemapHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(152, 255);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 24);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Submit";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(268, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TilemapPropertiesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 294);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTilemapHeight);
            this.Controls.Add(this.txtTilemapWidth);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.txtTilemapDescription);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtTilemapName);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapHeight)).EndInit();
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
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private System.Windows.Forms.NumericUpDown txtTilemapWidth;
        private System.Windows.Forms.NumericUpDown txtTilemapHeight;
        private Telerik.WinControls.UI.RadButton btnOK;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
