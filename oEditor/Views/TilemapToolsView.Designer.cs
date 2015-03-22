namespace oEditor.Views
{
    partial class TilemapToolsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilemapToolsView));
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.toolboxTilesets = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radPageView = new Telerik.WinControls.UI.RadPageView();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnAddTileset = new Telerik.WinControls.UI.CommandBarButton();
            this.btnDeleteTileset = new Telerik.WinControls.UI.CommandBarButton();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.toolboxLayers = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radCommandBar2 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnAddLayer = new Telerik.WinControls.UI.CommandBarButton();
            this.btnDeleteLayer = new Telerik.WinControls.UI.CommandBarButton();
            this.btnMoveLayerUp = new Telerik.WinControls.UI.CommandBarButton();
            this.btnMoveLayerDown = new Telerik.WinControls.UI.CommandBarButton();
            this.toolboxProperties = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            this.toolboxTilesets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            this.toolboxLayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar2)).BeginInit();
            this.toolboxProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radDock1
            // 
            this.radDock1.ActiveWindow = this.toolboxTilesets;
            this.radDock1.Controls.Add(this.documentContainer1);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 0);
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            this.radDock1.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock1.Size = new System.Drawing.Size(391, 439);
            this.radDock1.SplitterWidth = 2;
            this.radDock1.TabIndex = 0;
            this.radDock1.TabStop = false;
            this.radDock1.Text = "radDock1";
            this.radDock1.ThemeName = "VisualStudio2012Dark";
            // 
            // toolboxTilesets
            // 
            this.toolboxTilesets.Controls.Add(this.radPageView);
            this.toolboxTilesets.Controls.Add(this.radCommandBar1);
            this.toolboxTilesets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxTilesets.Location = new System.Drawing.Point(4, 29);
            this.toolboxTilesets.Name = "toolboxTilesets";
            this.toolboxTilesets.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxTilesets.Size = new System.Drawing.Size(383, 406);
            this.toolboxTilesets.Text = "Tilesets";
            // 
            // radPageView
            // 
            this.radPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView.Location = new System.Drawing.Point(0, 30);
            this.radPageView.Name = "radPageView";
            this.radPageView.Size = new System.Drawing.Size(383, 376);
            this.radPageView.TabIndex = 1;
            this.radPageView.ThemeName = "VisualStudio2012Dark";
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(383, 30);
            this.radCommandBar1.TabIndex = 0;
            this.radCommandBar1.Text = "radCommandBar1";
            this.radCommandBar1.ThemeName = "VisualStudio2012Dark";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnAddTileset,
            this.btnDeleteTileset});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // btnAddTileset
            // 
            this.btnAddTileset.DisplayName = "commandBarButton1";
            this.btnAddTileset.Image = global::oEditor.Properties.Resources.AddControl_371;
            this.btnAddTileset.Name = "btnAddTileset";
            this.btnAddTileset.Text = "";
            this.btnAddTileset.ToolTipText = "Add Tileset";
            this.btnAddTileset.Click += new System.EventHandler(this.btnAddTileset_Click);
            // 
            // btnDeleteTileset
            // 
            this.btnDeleteTileset.DisplayName = "commandBarButton2";
            this.btnDeleteTileset.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteTileset.Image")));
            this.btnDeleteTileset.Name = "btnDeleteTileset";
            this.btnDeleteTileset.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnDeleteTileset.Text = "";
            this.btnDeleteTileset.ToolTipText = "Delete Tileset";
            this.btnDeleteTileset.Click += new System.EventHandler(this.btnDeleteTileset_Click);
            // 
            // documentContainer1
            // 
            this.documentContainer1.Controls.Add(this.documentTabStrip1);
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SplitterWidth = 2;
            this.documentContainer1.ThemeName = "VisualStudio2012Dark";
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.Controls.Add(this.toolboxTilesets);
            this.documentTabStrip1.Controls.Add(this.toolboxLayers);
            this.documentTabStrip1.Controls.Add(this.toolboxProperties);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(391, 439);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.ThemeName = "VisualStudio2012Dark";
            // 
            // toolboxLayers
            // 
            this.toolboxLayers.Controls.Add(this.radCommandBar2);
            this.toolboxLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxLayers.Location = new System.Drawing.Point(4, 29);
            this.toolboxLayers.Name = "toolboxLayers";
            this.toolboxLayers.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxLayers.Size = new System.Drawing.Size(383, 406);
            this.toolboxLayers.Text = "Layers";
            // 
            // radCommandBar2
            // 
            this.radCommandBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar2.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar2.Name = "radCommandBar2";
            this.radCommandBar2.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement2});
            this.radCommandBar2.Size = new System.Drawing.Size(383, 30);
            this.radCommandBar2.TabIndex = 0;
            this.radCommandBar2.Text = "radCommandBar2";
            this.radCommandBar2.ThemeName = "VisualStudio2012Dark";
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement2.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement2});
            // 
            // commandBarStripElement2
            // 
            this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
            this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnAddLayer,
            this.btnDeleteLayer,
            this.btnMoveLayerUp,
            this.btnMoveLayerDown});
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            // 
            // btnAddLayer
            // 
            this.btnAddLayer.DisplayName = "commandBarButton1";
            this.btnAddLayer.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLayer.Image")));
            this.btnAddLayer.Name = "btnAddLayer";
            this.btnAddLayer.Text = "";
            this.btnAddLayer.Click += new System.EventHandler(this.btnAddLayer_Click);
            // 
            // btnDeleteLayer
            // 
            this.btnDeleteLayer.DisplayName = "commandBarButton1";
            this.btnDeleteLayer.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteLayer.Image")));
            this.btnDeleteLayer.Name = "btnDeleteLayer";
            this.btnDeleteLayer.Text = "";
            this.btnDeleteLayer.Click += new System.EventHandler(this.btnDeleteLayer_Click);
            // 
            // btnMoveLayerUp
            // 
            this.btnMoveLayerUp.DisplayName = "commandBarButton1";
            this.btnMoveLayerUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveLayerUp.Image")));
            this.btnMoveLayerUp.Name = "btnMoveLayerUp";
            this.btnMoveLayerUp.Text = "";
            this.btnMoveLayerUp.Click += new System.EventHandler(this.btnMoveLayerUp_Click);
            // 
            // btnMoveLayerDown
            // 
            this.btnMoveLayerDown.DisplayName = "commandBarButton1";
            this.btnMoveLayerDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveLayerDown.Image")));
            this.btnMoveLayerDown.Name = "btnMoveLayerDown";
            this.btnMoveLayerDown.Text = "";
            this.btnMoveLayerDown.Click += new System.EventHandler(this.btnMoveLayerDown_Click);
            // 
            // toolboxProperties
            // 
            this.toolboxProperties.Controls.Add(this.radLabel1);
            this.toolboxProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxProperties.Location = new System.Drawing.Point(4, 29);
            this.toolboxProperties.Name = "toolboxProperties";
            this.toolboxProperties.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxProperties.Size = new System.Drawing.Size(383, 406);
            this.toolboxProperties.Tag = "";
            this.toolboxProperties.Text = "Properties";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(8, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(2, 2);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.ThemeName = "VisualStudio2012Dark";
            // 
            // TilemapToolsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 439);
            this.Controls.Add(this.radDock1);
            this.Name = "TilemapToolsView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Toolbox";
            this.ThemeName = "VisualStudio2012Dark";
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            this.toolboxTilesets.ResumeLayout(false);
            this.toolboxTilesets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            this.toolboxLayers.ResumeLayout(false);
            this.toolboxLayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar2)).EndInit();
            this.toolboxProperties.ResumeLayout(false);
            this.toolboxProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.Docking.RadDock radDock1;
        private Telerik.WinControls.UI.Docking.DocumentWindow toolboxTilesets;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.Docking.DocumentWindow toolboxLayers;
        private Telerik.WinControls.UI.Docking.DocumentWindow toolboxProperties;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarButton btnAddTileset;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar2;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.CommandBarButton btnDeleteTileset;
        private Telerik.WinControls.UI.RadPageView radPageView;
        private Telerik.WinControls.UI.CommandBarButton btnAddLayer;
        private Telerik.WinControls.UI.CommandBarButton btnDeleteLayer;
        private Telerik.WinControls.UI.CommandBarButton btnMoveLayerUp;
        private Telerik.WinControls.UI.CommandBarButton btnMoveLayerDown;
    }
}
