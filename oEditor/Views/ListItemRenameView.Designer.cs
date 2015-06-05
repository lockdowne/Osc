namespace oEditor.Views
{
    partial class ListItemRenameView
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
            this.txtRenameLayer = new Telerik.WinControls.UI.RadTextBox();
            this.btnTilemapLayerOK = new Telerik.WinControls.UI.RadButton();
            this.btnTilemapLayerCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtRenameLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTilemapLayerOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTilemapLayerCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRenameLayer
            // 
            this.txtRenameLayer.Location = new System.Drawing.Point(12, 12);
            this.txtRenameLayer.Name = "txtRenameLayer";
            this.txtRenameLayer.Size = new System.Drawing.Size(225, 20);
            this.txtRenameLayer.TabIndex = 0;
            // 
            // btnTilemapLayerOK
            // 
            this.btnTilemapLayerOK.Location = new System.Drawing.Point(12, 38);
            this.btnTilemapLayerOK.Name = "btnTilemapLayerOK";
            this.btnTilemapLayerOK.Size = new System.Drawing.Size(110, 24);
            this.btnTilemapLayerOK.TabIndex = 1;
            this.btnTilemapLayerOK.Text = "OK";
            // 
            // btnTilemapLayerCancel
            // 
            this.btnTilemapLayerCancel.Location = new System.Drawing.Point(127, 38);
            this.btnTilemapLayerCancel.Name = "btnTilemapLayerCancel";
            this.btnTilemapLayerCancel.Size = new System.Drawing.Size(110, 24);
            this.btnTilemapLayerCancel.TabIndex = 2;
            this.btnTilemapLayerCancel.Text = "Cancel";
            // 
            // ListItemRenameView
            // 
            this.AcceptButton = this.btnTilemapLayerOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 71);
            this.Controls.Add(this.btnTilemapLayerCancel);
            this.Controls.Add(this.btnTilemapLayerOK);
            this.Controls.Add(this.txtRenameLayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ListItemRenameView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Rename Layer";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.txtRenameLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTilemapLayerOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTilemapLayerCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtRenameLayer;
        private Telerik.WinControls.UI.RadButton btnTilemapLayerOK;
        private Telerik.WinControls.UI.RadButton btnTilemapLayerCancel;
    }
}
