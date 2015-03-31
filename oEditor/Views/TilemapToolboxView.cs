using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public class TilemapToolboxView : RadForm
    {
        private RadDock radDock;
        private DocumentWindow toolboxTilesets;
        private DocumentContainer documentContainer1;
        private DocumentTabStrip documentTabStrip1;
        private DocumentWindow toolboxTilemapLayers;
        private DocumentWindow toolboxCollisionLayer;
        private RadPageView radPageViewTilesets;
        private RadCommandBar radCommandBarTilesets;
        private CommandBarRowElement commandBarRowElement1;
        private CommandBarStripElement commandBarStripElement1;
        private RadCheckedListBox radCheckedListBoxTilemapLayers;
        private RadCommandBar radCommandBarTilemapLayers;
        private CommandBarRowElement commandBarRowElement2;
        private CommandBarStripElement commandBarStripElement2;
        private RadGroupBox radGroupBox1;
        private RadLabel radLabel5;
        private RadLabel radLabel4;
        private RadLabel radLabel3;
        private RadLabel radLabel2;
        private RadLabel radLabel1;
        private RadTextBox txtTilemapID;
        private RadTextBox txtTilemapHeight;
        private RadTextBox txtTilemapWidth;
        private RadTextBox txtTilemapDescription;
        private RadTextBox txtTilemapName;
        private DocumentWindow toolboxProperties;
        
        public TilemapToolboxView()
        {
            InitializeComponent();

            // Dont let tabbed windows be closed
            this.radDock.DockWindowClosing += (sender, e) =>
            {
                e.Cancel = false;
            };

            txtTilemapName.TextChanged += (sender, e) =>
            {
                
            };

            txtTilemapName.MouseLeave += (sender, e) =>
            {
                Console.WriteLine(txtTilemapName.Text);
            };
        }

        private void InitializeComponent()
        {
            this.radDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.toolboxProperties = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.toolboxCollisionLayer = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.toolboxTilemapLayers = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.toolboxTilesets = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radCommandBarTilesets = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.radPageViewTilesets = new Telerik.WinControls.UI.RadPageView();
            this.radCommandBarTilemapLayers = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.radCheckedListBoxTilemapLayers = new Telerik.WinControls.UI.RadCheckedListBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtTilemapName = new Telerik.WinControls.UI.RadTextBox();
            this.txtTilemapDescription = new Telerik.WinControls.UI.RadTextBox();
            this.txtTilemapWidth = new Telerik.WinControls.UI.RadTextBox();
            this.txtTilemapHeight = new Telerik.WinControls.UI.RadTextBox();
            this.txtTilemapID = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).BeginInit();
            this.radDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            this.toolboxProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            this.toolboxTilemapLayers.SuspendLayout();
            this.toolboxTilesets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBarTilesets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewTilesets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBarTilemapLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBoxTilemapLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radDock
            // 
            this.radDock.ActiveWindow = this.toolboxProperties;
            this.radDock.Controls.Add(this.documentContainer1);
            this.radDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock.Location = new System.Drawing.Point(0, 0);
            this.radDock.MainDocumentContainer = this.documentContainer1;
            this.radDock.Name = "radDock";
            // 
            // 
            // 
            this.radDock.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radDock.Size = new System.Drawing.Size(456, 439);
            this.radDock.TabIndex = 0;
            this.radDock.TabStop = false;
            this.radDock.Text = "radDock1";
            // 
            // documentContainer1
            // 
            this.documentContainer1.Controls.Add(this.documentTabStrip1);
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            // 
            // toolboxProperties
            // 
            this.toolboxProperties.Controls.Add(this.radGroupBox1);
            this.toolboxProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxProperties.Location = new System.Drawing.Point(6, 29);
            this.toolboxProperties.Name = "toolboxProperties";
            this.toolboxProperties.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxProperties.Size = new System.Drawing.Size(434, 394);
            this.toolboxProperties.Text = "Properties";
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.Controls.Add(this.toolboxTilesets);
            this.documentTabStrip1.Controls.Add(this.toolboxTilemapLayers);
            this.documentTabStrip1.Controls.Add(this.toolboxCollisionLayer);
            this.documentTabStrip1.Controls.Add(this.toolboxProperties);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip1.SelectedIndex = 3;
            this.documentTabStrip1.Size = new System.Drawing.Size(446, 429);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            // 
            // toolboxCollisionLayer
            // 
            this.toolboxCollisionLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxCollisionLayer.Location = new System.Drawing.Point(6, 29);
            this.toolboxCollisionLayer.Name = "toolboxCollisionLayer";
            this.toolboxCollisionLayer.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxCollisionLayer.Size = new System.Drawing.Size(434, 394);
            this.toolboxCollisionLayer.Text = "Collision Layer";
            // 
            // toolboxTilemapLayers
            // 
            this.toolboxTilemapLayers.Controls.Add(this.radCheckedListBoxTilemapLayers);
            this.toolboxTilemapLayers.Controls.Add(this.radCommandBarTilemapLayers);
            this.toolboxTilemapLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxTilemapLayers.Location = new System.Drawing.Point(6, 29);
            this.toolboxTilemapLayers.Name = "toolboxTilemapLayers";
            this.toolboxTilemapLayers.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxTilemapLayers.Size = new System.Drawing.Size(434, 394);
            this.toolboxTilemapLayers.Text = "Tilemap Layers";
            // 
            // toolboxTilesets
            // 
            this.toolboxTilesets.Controls.Add(this.radPageViewTilesets);
            this.toolboxTilesets.Controls.Add(this.radCommandBarTilesets);
            this.toolboxTilesets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxTilesets.Location = new System.Drawing.Point(6, 29);
            this.toolboxTilesets.Name = "toolboxTilesets";
            this.toolboxTilesets.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxTilesets.Size = new System.Drawing.Size(434, 394);
            this.toolboxTilesets.Text = "Tilesets";
            // 
            // radCommandBarTilesets
            // 
            this.radCommandBarTilesets.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBarTilesets.Location = new System.Drawing.Point(0, 0);
            this.radCommandBarTilesets.Name = "radCommandBarTilesets";
            this.radCommandBarTilesets.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBarTilesets.Size = new System.Drawing.Size(434, 30);
            this.radCommandBarTilesets.TabIndex = 1;
            this.radCommandBarTilesets.Text = "radCommandBar1";
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
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // radPageViewTilesets
            // 
            this.radPageViewTilesets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageViewTilesets.Location = new System.Drawing.Point(0, 30);
            this.radPageViewTilesets.Name = "radPageViewTilesets";
            this.radPageViewTilesets.Size = new System.Drawing.Size(434, 364);
            this.radPageViewTilesets.TabIndex = 2;
            this.radPageViewTilesets.Text = "radPageView1";
            // 
            // radCommandBarTilemapLayers
            // 
            this.radCommandBarTilemapLayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBarTilemapLayers.Location = new System.Drawing.Point(0, 0);
            this.radCommandBarTilemapLayers.Name = "radCommandBarTilemapLayers";
            this.radCommandBarTilemapLayers.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement2});
            this.radCommandBarTilemapLayers.Size = new System.Drawing.Size(434, 30);
            this.radCommandBarTilemapLayers.TabIndex = 0;
            this.radCommandBarTilemapLayers.Text = "radCommandBar1";
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
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            // 
            // radCheckedListBoxTilemapLayers
            // 
            this.radCheckedListBoxTilemapLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radCheckedListBoxTilemapLayers.Location = new System.Drawing.Point(0, 30);
            this.radCheckedListBoxTilemapLayers.Name = "radCheckedListBoxTilemapLayers";
            this.radCheckedListBoxTilemapLayers.Size = new System.Drawing.Size(434, 364);
            this.radCheckedListBoxTilemapLayers.TabIndex = 1;
            this.radCheckedListBoxTilemapLayers.Text = "radCheckedListBox1";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel5);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtTilemapID);
            this.radGroupBox1.Controls.Add(this.txtTilemapHeight);
            this.radGroupBox1.Controls.Add(this.txtTilemapWidth);
            this.radGroupBox1.Controls.Add(this.txtTilemapDescription);
            this.radGroupBox1.Controls.Add(this.txtTilemapName);
            this.radGroupBox1.HeaderText = "Tilemap Properties";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(434, 394);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Tilemap Properties";
            // 
            // txtTilemapName
            // 
            this.txtTilemapName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTilemapName.Location = new System.Drawing.Point(108, 47);
            this.txtTilemapName.Name = "txtTilemapName";
            // 
            // 
            // 
            this.txtTilemapName.RootElement.ToolTipText = "Sets the name of the tilemap";
            this.txtTilemapName.Size = new System.Drawing.Size(218, 20);
            this.txtTilemapName.TabIndex = 1;
            // 
            // txtTilemapDescription
            // 
            this.txtTilemapDescription.AutoSize = false;
            this.txtTilemapDescription.Location = new System.Drawing.Point(108, 73);
            this.txtTilemapDescription.Multiline = true;
            this.txtTilemapDescription.Name = "txtTilemapDescription";
            // 
            // 
            // 
            this.txtTilemapDescription.RootElement.ToolTipText = "Set the description of the tilemap that will be seen on the loading of the tilema" +
    "p";
            this.txtTilemapDescription.Size = new System.Drawing.Size(218, 110);
            this.txtTilemapDescription.TabIndex = 2;
            // 
            // txtTilemapWidth
            // 
            this.txtTilemapWidth.Location = new System.Drawing.Point(108, 190);
            this.txtTilemapWidth.Name = "txtTilemapWidth";
            // 
            // 
            // 
            this.txtTilemapWidth.RootElement.ToolTipText = "Sets the number of tiles horizontally on tilemap";
            this.txtTilemapWidth.Size = new System.Drawing.Size(218, 20);
            this.txtTilemapWidth.TabIndex = 4;
            // 
            // txtTilemapHeight
            // 
            this.txtTilemapHeight.Location = new System.Drawing.Point(108, 216);
            this.txtTilemapHeight.Name = "txtTilemapHeight";
            // 
            // 
            // 
            this.txtTilemapHeight.RootElement.ToolTipText = "Sets the number of tiles vertically on tilemap";
            this.txtTilemapHeight.Size = new System.Drawing.Size(218, 20);
            this.txtTilemapHeight.TabIndex = 5;
            // 
            // txtTilemapID
            // 
            this.txtTilemapID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTilemapID.Location = new System.Drawing.Point(108, 21);
            this.txtTilemapID.Name = "txtTilemapID";
            this.txtTilemapID.ReadOnly = true;
            // 
            // 
            // 
            this.txtTilemapID.RootElement.ToolTipText = "Unique identiciation number";
            this.txtTilemapID.Size = new System.Drawing.Size(218, 20);
            this.txtTilemapID.TabIndex = 6;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radLabel1.Location = new System.Drawing.Point(13, 21);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.ToolTipText = "Unique identification number";
            this.radLabel1.Size = new System.Drawing.Size(20, 18);
            this.radLabel1.TabIndex = 8;
            this.radLabel1.Text = "ID:";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radLabel2.Location = new System.Drawing.Point(13, 47);
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.ToolTipText = "Sets the name of the tilemap";
            this.radLabel2.Size = new System.Drawing.Size(39, 18);
            this.radLabel2.TabIndex = 9;
            this.radLabel2.Text = "Name:";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(13, 74);
            this.radLabel3.Name = "radLabel3";
            // 
            // 
            // 
            this.radLabel3.RootElement.ToolTipText = "Set the description of the tilemap that will be seen on the loading of the tilema" +
    "p";
            this.radLabel3.Size = new System.Drawing.Size(66, 18);
            this.radLabel3.TabIndex = 10;
            this.radLabel3.Text = "Description:";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(13, 190);
            this.radLabel4.Name = "radLabel4";
            // 
            // 
            // 
            this.radLabel4.RootElement.ToolTipText = "Sets the number of tiles horizontally on tilemap";
            this.radLabel4.Size = new System.Drawing.Size(39, 18);
            this.radLabel4.TabIndex = 11;
            this.radLabel4.Text = "Width:";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(13, 217);
            this.radLabel5.Name = "radLabel5";
            // 
            // 
            // 
            this.radLabel5.RootElement.ToolTipText = "Sets the number of tiles vertically on tilemap";
            this.radLabel5.Size = new System.Drawing.Size(42, 18);
            this.radLabel5.TabIndex = 12;
            this.radLabel5.Text = "Height:";
            // 
            // TilemapToolboxView
            // 
            this.ClientSize = new System.Drawing.Size(456, 439);
            this.Controls.Add(this.radDock);
            this.Name = "TilemapToolboxView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Toolbox";
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).EndInit();
            this.radDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            this.toolboxProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            this.toolboxTilemapLayers.ResumeLayout(false);
            this.toolboxTilemapLayers.PerformLayout();
            this.toolboxTilesets.ResumeLayout(false);
            this.toolboxTilesets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBarTilesets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewTilesets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBarTilemapLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBoxTilemapLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
