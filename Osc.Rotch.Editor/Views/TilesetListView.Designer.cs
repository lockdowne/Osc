namespace Osc.Rotch.Editor.Views
{
    partial class TilesetListView
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
            this.radListControl = new Telerik.WinControls.UI.RadListControl();
            this.btnAddTilesetImage = new Telerik.WinControls.UI.RadButton();
            this.btnSelectTileset = new Telerik.WinControls.UI.RadButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddTilesetImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectTileset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radListControl
            // 
            this.radListControl.Location = new System.Drawing.Point(12, 12);
            this.radListControl.Name = "radListControl";
            this.radListControl.Size = new System.Drawing.Size(226, 291);
            this.radListControl.TabIndex = 0;
            this.radListControl.Text = "radListControl1";
            // 
            // btnAddTilesetImage
            // 
            this.btnAddTilesetImage.Location = new System.Drawing.Point(12, 309);
            this.btnAddTilesetImage.Name = "btnAddTilesetImage";
            this.btnAddTilesetImage.Size = new System.Drawing.Size(110, 24);
            this.btnAddTilesetImage.TabIndex = 1;
            this.btnAddTilesetImage.Text = "Add Tileset";
            this.btnAddTilesetImage.Click += new System.EventHandler(this.btnAddTilesetImage_Click);
            // 
            // btnSelectTileset
            // 
            this.btnSelectTileset.Location = new System.Drawing.Point(128, 309);
            this.btnSelectTileset.Name = "btnSelectTileset";
            this.btnSelectTileset.Size = new System.Drawing.Size(110, 24);
            this.btnSelectTileset.TabIndex = 2;
            this.btnSelectTileset.Text = "Select Tileset";
            this.btnSelectTileset.Click += new System.EventHandler(this.btnTilesetSelectTexture_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(245, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(290, 290);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // TilesetListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 341);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnSelectTileset);
            this.Controls.Add(this.btnAddTilesetImage);
            this.Controls.Add(this.radListControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TilesetListView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Tileset Textures";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radListControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddTilesetImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectTileset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadListControl radListControl;
        private Telerik.WinControls.UI.RadButton btnAddTilesetImage;
        private Telerik.WinControls.UI.RadButton btnSelectTileset;
        private System.Windows.Forms.PictureBox pictureBox;

    }
}
