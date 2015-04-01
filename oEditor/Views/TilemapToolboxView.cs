using oEditor.Aggregators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public class TilemapToolboxView : RadForm, ITilemapToolboxView
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
        private RadCommandBar btnAddTilemapLayer;
        private CommandBarRowElement commandBarRowElement2;
        private CommandBarStripElement commandBarStripElement2;
        private RadGroupBox radGroupBox1;
        private RadLabel radLabel5;
        private RadLabel radLabel4;
        private RadLabel radLabel3;
        private RadLabel radLabel2;
        private RadLabel radLabel1;
        private RadTextBox txtTilemapID;
        private RadTextBox txtTilemapDescription;
        private RadTextBox txtTilemapName;
        private DocumentWindow toolboxProperties;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.ComponentModel.IContainer components;
        private RadSpinEditor txtTilemapHeight;
        private RadSpinEditor txtTilemapWidth;
        private CommandBarButton btnAddTileset;
        private CommandBarButton btnRemoveTileset;
        private CommandBarButton commandBarButton1;
        private CommandBarButton btnRemoveTilemapLayer;
        private CommandBarButton btnMoveTilemapLayerUp;
        private CommandBarButton btnMoveTilemapLayerDown;
        private CommandBarButton btnMergeTilemapLayer;
        private RadGroupBox radGroupBox2;
        private RadRadioButton radioPassable;
        private RadRadioButton radioImpassable;

        private readonly IEventAggregator eventAggregator;

        public Guid ID
        {
            get { return Guid.Parse(txtTilemapID.Text); }
            set { txtTilemapID.Text = value.ToString(); }
        }

        public string TilemapName
        {
            get { return txtTilemapName.Text; }
            set { txtTilemapName.Text = value; }
        }

        public string TilemapDescription
        {
            get { return txtTilemapDescription.Text; }
            set { txtTilemapDescription.Text = value; }
        }

        public int TilemapWidth
        {
            get { return (int)txtTilemapWidth.Value; }
            set { txtTilemapWidth.Value = value; }
        }

        public int TilemapHeight
        {
            get { return (int)txtTilemapHeight.Value; }
            set { txtTilemapHeight.Value = value; }
        }
        
        public TilemapToolboxView(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            InitializeComponent();

            this.txtTilemapID.Text = ID.ToString();

            // Dont let tabbed windows be closed
            this.radDock.DockWindowClosing += (sender, e) =>
            {
                e.Cancel = false;
            };      

            txtTilemapName.Validated += (sender, e) =>
            {              
                eventAggregator.Publish(new OnTilemapNameChanged() { Name = txtTilemapName.Text });
            };

            txtTilemapDescription.Validated += (sender, e) =>
            {
                eventAggregator.Publish(new OnTilemapDescriptionChanged() { Description = txtTilemapDescription.Text });               
            };

            txtTilemapWidth.Validated += (sender, e) =>
            {
                eventAggregator.Publish(new OnTilemapWidthChanged() { Width = (int)txtTilemapWidth.Value });
            };

            txtTilemapHeight.Validated += (sender, e) =>
            {
                eventAggregator.Publish(new OnTilemapHeightChanged() { Height = (int)txtTilemapHeight.Value });
            };
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.toolboxTilemapLayers = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radCheckedListBoxTilemapLayers = new Telerik.WinControls.UI.RadCheckedListBox();
            this.btnAddTilemapLayer = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
            this.btnRemoveTilemapLayer = new Telerik.WinControls.UI.CommandBarButton();
            this.btnMoveTilemapLayerUp = new Telerik.WinControls.UI.CommandBarButton();
            this.btnMoveTilemapLayerDown = new Telerik.WinControls.UI.CommandBarButton();
            this.btnMergeTilemapLayer = new Telerik.WinControls.UI.CommandBarButton();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.toolboxTilesets = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radPageViewTilesets = new Telerik.WinControls.UI.RadPageView();
            this.radCommandBarTilesets = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnAddTileset = new Telerik.WinControls.UI.CommandBarButton();
            this.btnRemoveTileset = new Telerik.WinControls.UI.CommandBarButton();
            this.toolboxCollisionLayer = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.toolboxProperties = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtTilemapHeight = new Telerik.WinControls.UI.RadSpinEditor();
            this.txtTilemapWidth = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtTilemapID = new Telerik.WinControls.UI.RadTextBox();
            this.txtTilemapDescription = new Telerik.WinControls.UI.RadTextBox();
            this.txtTilemapName = new Telerik.WinControls.UI.RadTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radioImpassable = new Telerik.WinControls.UI.RadRadioButton();
            this.radioPassable = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).BeginInit();
            this.radDock.SuspendLayout();
            this.toolboxTilemapLayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBoxTilemapLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddTilemapLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            this.toolboxTilesets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewTilesets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBarTilesets)).BeginInit();
            this.toolboxCollisionLayer.SuspendLayout();
            this.toolboxProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioImpassable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioPassable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radDock
            // 
            this.radDock.ActiveWindow = this.toolboxCollisionLayer;
            this.radDock.Controls.Add(this.documentContainer1);
            this.radDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock.IsCleanUpTarget = true;
            this.radDock.Location = new System.Drawing.Point(0, 0);
            this.radDock.MainDocumentContainer = this.documentContainer1;
            this.radDock.Name = "radDock";
            // 
            // 
            // 
            this.radDock.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radDock.Size = new System.Drawing.Size(540, 475);
            this.radDock.TabIndex = 0;
            this.radDock.TabStop = false;
            this.radDock.Text = "radDock1";
            this.radDock.Click += new System.EventHandler(this.radDock_Click);
            // 
            // toolboxTilemapLayers
            // 
            this.toolboxTilemapLayers.Controls.Add(this.radCheckedListBoxTilemapLayers);
            this.toolboxTilemapLayers.Controls.Add(this.btnAddTilemapLayer);
            this.toolboxTilemapLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxTilemapLayers.Location = new System.Drawing.Point(6, 29);
            this.toolboxTilemapLayers.Name = "toolboxTilemapLayers";
            this.toolboxTilemapLayers.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxTilemapLayers.Size = new System.Drawing.Size(518, 430);
            this.toolboxTilemapLayers.Text = "Tilemap Layers";
            // 
            // radCheckedListBoxTilemapLayers
            // 
            this.radCheckedListBoxTilemapLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radCheckedListBoxTilemapLayers.Location = new System.Drawing.Point(0, 30);
            this.radCheckedListBoxTilemapLayers.Name = "radCheckedListBoxTilemapLayers";
            this.radCheckedListBoxTilemapLayers.Size = new System.Drawing.Size(518, 400);
            this.radCheckedListBoxTilemapLayers.TabIndex = 1;
            this.radCheckedListBoxTilemapLayers.Text = "radCheckedListBox1";
            // 
            // btnAddTilemapLayer
            // 
            this.btnAddTilemapLayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddTilemapLayer.Location = new System.Drawing.Point(0, 0);
            this.btnAddTilemapLayer.Name = "btnAddTilemapLayer";
            this.btnAddTilemapLayer.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement2});
            this.btnAddTilemapLayer.Size = new System.Drawing.Size(518, 30);
            this.btnAddTilemapLayer.TabIndex = 0;
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
            this.commandBarButton1,
            this.btnRemoveTilemapLayer,
            this.btnMoveTilemapLayerUp,
            this.btnMoveTilemapLayerDown,
            this.btnMergeTilemapLayer});
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            // 
            // commandBarButton1
            // 
            this.commandBarButton1.AccessibleDescription = "commandBarButton1";
            this.commandBarButton1.AccessibleName = "commandBarButton1";
            this.commandBarButton1.DisplayName = "commandBarButton1";
            this.commandBarButton1.Image = global::oEditor.Properties.Resources.AddMark_10580;
            this.commandBarButton1.Name = "commandBarButton1";
            this.commandBarButton1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.commandBarButton1.Text = "commandBarButton1";
            this.commandBarButton1.ToolTipText = "Add Layer";
            this.commandBarButton1.Click += new System.EventHandler(this.btnAddTilemapLayer_Click);
            // 
            // btnRemoveTilemapLayer
            // 
            this.btnRemoveTilemapLayer.AccessibleDescription = "commandBarButton2";
            this.btnRemoveTilemapLayer.AccessibleName = "commandBarButton2";
            this.btnRemoveTilemapLayer.DisplayName = "commandBarButton2";
            this.btnRemoveTilemapLayer.Image = global::oEditor.Properties.Resources.Clearallrequests_8816;
            this.btnRemoveTilemapLayer.Name = "btnRemoveTilemapLayer";
            this.btnRemoveTilemapLayer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRemoveTilemapLayer.Text = "commandBarButton2";
            this.btnRemoveTilemapLayer.ToolTipText = "Remove Layer";
            this.btnRemoveTilemapLayer.Click += new System.EventHandler(this.btnRemoveTilemapLayer_Click);
            // 
            // btnMoveTilemapLayerUp
            // 
            this.btnMoveTilemapLayerUp.AccessibleDescription = "commandBarButton3";
            this.btnMoveTilemapLayerUp.AccessibleName = "commandBarButton3";
            this.btnMoveTilemapLayerUp.DisplayName = "commandBarButton3";
            this.btnMoveTilemapLayerUp.Image = global::oEditor.Properties.Resources.arrow_Up_16xLG;
            this.btnMoveTilemapLayerUp.Name = "btnMoveTilemapLayerUp";
            this.btnMoveTilemapLayerUp.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnMoveTilemapLayerUp.Text = "commandBarButton3";
            this.btnMoveTilemapLayerUp.ToolTipText = "Move Layer Up";
            this.btnMoveTilemapLayerUp.Click += new System.EventHandler(this.btnMoveTilemapLayerUp_Click);
            // 
            // btnMoveTilemapLayerDown
            // 
            this.btnMoveTilemapLayerDown.AccessibleDescription = "commandBarButton4";
            this.btnMoveTilemapLayerDown.AccessibleName = "commandBarButton4";
            this.btnMoveTilemapLayerDown.DisplayName = "commandBarButton4";
            this.btnMoveTilemapLayerDown.Image = global::oEditor.Properties.Resources.arrow_Down_16xLG;
            this.btnMoveTilemapLayerDown.Name = "btnMoveTilemapLayerDown";
            this.btnMoveTilemapLayerDown.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnMoveTilemapLayerDown.Text = "commandBarButton4";
            this.btnMoveTilemapLayerDown.ToolTipText = "Move Layer Down";
            this.btnMoveTilemapLayerDown.Click += new System.EventHandler(this.btnMoveTilemapLayerDown_Click);
            // 
            // btnMergeTilemapLayer
            // 
            this.btnMergeTilemapLayer.AccessibleDescription = "commandBarButton5";
            this.btnMergeTilemapLayer.AccessibleName = "commandBarButton5";
            this.btnMergeTilemapLayer.DisplayName = "commandBarButton5";
            this.btnMergeTilemapLayer.Image = global::oEditor.Properties.Resources.Merge_13256;
            this.btnMergeTilemapLayer.Name = "btnMergeTilemapLayer";
            this.btnMergeTilemapLayer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnMergeTilemapLayer.Text = "commandBarButton5";
            this.btnMergeTilemapLayer.ToolTipText = "Merge Layer";
            this.btnMergeTilemapLayer.Click += new System.EventHandler(this.btnMergeTilemapLayer_Click);
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
            this.documentTabStrip1.SelectedIndex = 2;
            this.documentTabStrip1.Size = new System.Drawing.Size(530, 465);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            // 
            // toolboxTilesets
            // 
            this.toolboxTilesets.Controls.Add(this.radPageViewTilesets);
            this.toolboxTilesets.Controls.Add(this.radCommandBarTilesets);
            this.toolboxTilesets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxTilesets.Location = new System.Drawing.Point(6, 29);
            this.toolboxTilesets.Name = "toolboxTilesets";
            this.toolboxTilesets.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxTilesets.Size = new System.Drawing.Size(518, 430);
            this.toolboxTilesets.Text = "Tilesets";
            // 
            // radPageViewTilesets
            // 
            this.radPageViewTilesets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageViewTilesets.Location = new System.Drawing.Point(0, 30);
            this.radPageViewTilesets.Name = "radPageViewTilesets";
            this.radPageViewTilesets.Size = new System.Drawing.Size(518, 400);
            this.radPageViewTilesets.TabIndex = 2;
            this.radPageViewTilesets.Text = "radPageView1";
            // 
            // radCommandBarTilesets
            // 
            this.radCommandBarTilesets.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBarTilesets.Location = new System.Drawing.Point(0, 0);
            this.radCommandBarTilesets.Name = "radCommandBarTilesets";
            this.radCommandBarTilesets.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBarTilesets.Size = new System.Drawing.Size(518, 30);
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
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnAddTileset,
            this.btnRemoveTileset});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // btnAddTileset
            // 
            this.btnAddTileset.AccessibleDescription = "commandBarButton1";
            this.btnAddTileset.AccessibleName = "commandBarButton1";
            this.btnAddTileset.DisplayName = "commandBarButton1";
            this.btnAddTileset.Image = global::oEditor.Properties.Resources.AddMark_10580;
            this.btnAddTileset.Name = "btnAddTileset";
            this.btnAddTileset.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAddTileset.Text = "commandBarButton1";
            this.btnAddTileset.ToolTipText = "Add Tileset";
            this.btnAddTileset.Click += new System.EventHandler(this.btnAddTileset_Click);
            // 
            // btnRemoveTileset
            // 
            this.btnRemoveTileset.AccessibleDescription = "commandBarButton2";
            this.btnRemoveTileset.AccessibleName = "commandBarButton2";
            this.btnRemoveTileset.DisplayName = "commandBarButton2";
            this.btnRemoveTileset.Image = global::oEditor.Properties.Resources.Clearallrequests_8816;
            this.btnRemoveTileset.Name = "btnRemoveTileset";
            this.btnRemoveTileset.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRemoveTileset.Text = "commandBarButton2";
            this.btnRemoveTileset.ToolTipText = "Remove Tileset";
            this.btnRemoveTileset.Click += new System.EventHandler(this.btnRemoveTileset_Click);
            // 
            // toolboxCollisionLayer
            // 
            this.toolboxCollisionLayer.Controls.Add(this.radGroupBox2);
            this.toolboxCollisionLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxCollisionLayer.Location = new System.Drawing.Point(6, 29);
            this.toolboxCollisionLayer.Name = "toolboxCollisionLayer";
            this.toolboxCollisionLayer.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxCollisionLayer.Size = new System.Drawing.Size(518, 430);
            this.toolboxCollisionLayer.Text = "Collision Layer";
            // 
            // toolboxProperties
            // 
            this.toolboxProperties.Controls.Add(this.radGroupBox1);
            this.toolboxProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxProperties.Location = new System.Drawing.Point(6, 29);
            this.toolboxProperties.Name = "toolboxProperties";
            this.toolboxProperties.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxProperties.Size = new System.Drawing.Size(518, 430);
            this.toolboxProperties.Text = "Properties";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.txtTilemapHeight);
            this.radGroupBox1.Controls.Add(this.txtTilemapWidth);
            this.radGroupBox1.Controls.Add(this.radLabel5);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtTilemapID);
            this.radGroupBox1.Controls.Add(this.txtTilemapDescription);
            this.radGroupBox1.Controls.Add(this.txtTilemapName);
            this.radGroupBox1.HeaderText = "Tilemap Properties";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(434, 394);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Tilemap Properties";
            // 
            // txtTilemapHeight
            // 
            this.txtTilemapHeight.Location = new System.Drawing.Point(108, 215);
            this.txtTilemapHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTilemapHeight.Name = "txtTilemapHeight";
            this.txtTilemapHeight.Size = new System.Drawing.Size(218, 20);
            this.txtTilemapHeight.TabIndex = 14;
            this.txtTilemapHeight.TabStop = false;
            this.txtTilemapHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTilemapWidth
            // 
            this.txtTilemapWidth.Location = new System.Drawing.Point(108, 189);
            this.txtTilemapWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTilemapWidth.Name = "txtTilemapWidth";
            this.txtTilemapWidth.Size = new System.Drawing.Size(218, 20);
            this.txtTilemapWidth.TabIndex = 13;
            this.txtTilemapWidth.TabStop = false;
            this.txtTilemapWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.radioPassable);
            this.radGroupBox2.Controls.Add(this.radioImpassable);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox2.HeaderText = "Collision";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(518, 430);
            this.radGroupBox2.TabIndex = 0;
            this.radGroupBox2.Text = "Collision";
            // 
            // radioImpassable
            // 
            this.radioImpassable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioImpassable.Location = new System.Drawing.Point(30, 31);
            this.radioImpassable.Name = "radioImpassable";
            this.radioImpassable.Size = new System.Drawing.Size(76, 18);
            this.radioImpassable.TabIndex = 0;
            this.radioImpassable.Text = "Impassable";
            this.radioImpassable.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.radioImpassable.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radioImpassable_ToggleStateChanged);
            // 
            // radioPassable
            // 
            this.radioPassable.Location = new System.Drawing.Point(30, 55);
            this.radioPassable.Name = "radioPassable";
            this.radioPassable.Size = new System.Drawing.Size(63, 18);
            this.radioPassable.TabIndex = 1;
            this.radioPassable.Text = "Passable";
            this.radioPassable.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radioPassable_ToggleStateChanged);
            // 
            // TilemapToolboxView
            // 
            this.ClientSize = new System.Drawing.Size(540, 475);
            this.Controls.Add(this.radDock);
            this.Name = "TilemapToolboxView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Toolbox";
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).EndInit();
            this.radDock.ResumeLayout(false);
            this.toolboxTilemapLayers.ResumeLayout(false);
            this.toolboxTilemapLayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBoxTilemapLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddTilemapLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            this.toolboxTilesets.ResumeLayout(false);
            this.toolboxTilesets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewTilesets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBarTilesets)).EndInit();
            this.toolboxCollisionLayer.ResumeLayout(false);
            this.toolboxProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioImpassable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioPassable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void radDock_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTileset_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveTileset_Click(object sender, EventArgs e)
        {

        }


        private void btnRemoveTilemapLayer_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTilemapLayer_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveTilemapLayerUp_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveTilemapLayerDown_Click(object sender, EventArgs e)
        {

        }

        private void btnMergeTilemapLayer_Click(object sender, EventArgs e)
        {

        }

        private void radioImpassable_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }

        private void radioPassable_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }
    }
}
