using oEditor.Aggregators;
using oEditor.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public class TilemapToolboxView : ToolWindow, ITilemapToolboxView
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
        private RadCommandBar btnAddTilemapLayer;
        private CommandBarRowElement commandBarRowElement2;
        private CommandBarStripElement commandBarStripElement2;
        private CommandBarButton commandBarButton1;
        private CommandBarButton btnRemoveTilemapLayer;
        private CommandBarButton btnMoveTilemapLayerUp;
        private CommandBarButton btnMoveTilemapLayerDown;
        private CommandBarButton btnMergeTilemapLayer;
        private RadRadioButton radioPassable;
        private RadRadioButton radioImpassable;
        private CommandBarDropDownList dropDownTilesets;
        private CommandBarButton btnRenameTilemapLayer;

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

        public TilesetPage SelectedTilesetPage
        {
            get { return (TilesetPage)radPageViewTilesets.SelectedPage; }
        }

        public ListViewDataItem SelectedTilemapLayer
        {
            get { return radCheckedListBoxTilemapLayers.SelectedItem; }
        }

        public RadCheckedListBox TilemapLayersListBox
        {
            get { return radCheckedListBoxTilemapLayers; }
        }

        public RadPageView TilesetsPages
        {
            get { return radPageViewTilesets; }
        }

        public TilemapToolboxView(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            InitializeComponent();

            this.dropDownTilesets.SelectedIndex = 0;

           

            // Dont let tabbed windows be closed
            this.radDock.DockWindowClosing += (sender, e) =>
            {
                e.Cancel = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilemapToolboxView));
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
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
            this.btnRenameTilemapLayer = new Telerik.WinControls.UI.CommandBarButton();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.toolboxTilesets = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radPageViewTilesets = new Telerik.WinControls.UI.RadPageView();
            this.radCommandBarTilesets = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnAddTileset = new Telerik.WinControls.UI.CommandBarButton();
            this.btnRemoveTileset = new Telerik.WinControls.UI.CommandBarButton();
            this.dropDownTilesets = new Telerik.WinControls.UI.CommandBarDropDownList();
            this.toolboxCollisionLayer = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radioPassable = new Telerik.WinControls.UI.RadRadioButton();
            this.radioImpassable = new Telerik.WinControls.UI.RadRadioButton();
            this.toolboxProperties = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.txtTilemapHeight = new Telerik.WinControls.UI.RadSpinEditor();
            this.txtTilemapWidth = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtTilemapName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtTilemapDescription = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtTilemapID = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.radioPassable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioImpassable)).BeginInit();
            this.toolboxProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // radDock
            // 
            this.radDock.ActiveWindow = this.toolboxTilemapLayers;
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
            this.commandBarRowElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement2.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement2});
            this.commandBarRowElement2.Text = "";
            this.commandBarRowElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // commandBarStripElement2
            // 
            this.commandBarStripElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
            this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarButton1,
            this.btnRemoveTilemapLayer,
            this.btnMoveTilemapLayerUp,
            this.btnMoveTilemapLayerDown,
            this.btnMergeTilemapLayer,
            this.btnRenameTilemapLayer});
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            this.commandBarStripElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // commandBarButton1
            // 
            this.commandBarButton1.AccessibleDescription = "commandBarButton1";
            this.commandBarButton1.AccessibleName = "commandBarButton1";
            this.commandBarButton1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton1.DisplayName = "commandBarButton1";
            this.commandBarButton1.Image = global::oEditor.Properties.Resources.AddMark_10580;
            this.commandBarButton1.Name = "commandBarButton1";
            this.commandBarButton1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.commandBarButton1.Text = "commandBarButton1";
            this.commandBarButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton1.ToolTipText = "Add Layer";
            this.commandBarButton1.Click += new System.EventHandler(this.btnAddTilemapLayer_Click);
            // 
            // btnRemoveTilemapLayer
            // 
            this.btnRemoveTilemapLayer.AccessibleDescription = "commandBarButton2";
            this.btnRemoveTilemapLayer.AccessibleName = "commandBarButton2";
            this.btnRemoveTilemapLayer.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnRemoveTilemapLayer.DisplayName = "commandBarButton2";
            this.btnRemoveTilemapLayer.Image = global::oEditor.Properties.Resources.Clearallrequests_8816;
            this.btnRemoveTilemapLayer.Name = "btnRemoveTilemapLayer";
            this.btnRemoveTilemapLayer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRemoveTilemapLayer.Text = "commandBarButton2";
            this.btnRemoveTilemapLayer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnRemoveTilemapLayer.ToolTipText = "Remove Layer";
            this.btnRemoveTilemapLayer.Click += new System.EventHandler(this.btnRemoveTilemapLayer_Click);
            // 
            // btnMoveTilemapLayerUp
            // 
            this.btnMoveTilemapLayerUp.AccessibleDescription = "commandBarButton3";
            this.btnMoveTilemapLayerUp.AccessibleName = "commandBarButton3";
            this.btnMoveTilemapLayerUp.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnMoveTilemapLayerUp.DisplayName = "commandBarButton3";
            this.btnMoveTilemapLayerUp.Image = global::oEditor.Properties.Resources.arrow_Up_16xLG;
            this.btnMoveTilemapLayerUp.Name = "btnMoveTilemapLayerUp";
            this.btnMoveTilemapLayerUp.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnMoveTilemapLayerUp.Text = "commandBarButton3";
            this.btnMoveTilemapLayerUp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnMoveTilemapLayerUp.ToolTipText = "Move Layer Up";
            this.btnMoveTilemapLayerUp.Click += new System.EventHandler(this.btnMoveTilemapLayerUp_Click);
            // 
            // btnMoveTilemapLayerDown
            // 
            this.btnMoveTilemapLayerDown.AccessibleDescription = "commandBarButton4";
            this.btnMoveTilemapLayerDown.AccessibleName = "commandBarButton4";
            this.btnMoveTilemapLayerDown.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnMoveTilemapLayerDown.DisplayName = "commandBarButton4";
            this.btnMoveTilemapLayerDown.Image = global::oEditor.Properties.Resources.arrow_Down_16xLG;
            this.btnMoveTilemapLayerDown.Name = "btnMoveTilemapLayerDown";
            this.btnMoveTilemapLayerDown.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnMoveTilemapLayerDown.Text = "commandBarButton4";
            this.btnMoveTilemapLayerDown.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnMoveTilemapLayerDown.ToolTipText = "Move Layer Down";
            this.btnMoveTilemapLayerDown.Click += new System.EventHandler(this.btnMoveTilemapLayerDown_Click);
            // 
            // btnMergeTilemapLayer
            // 
            this.btnMergeTilemapLayer.AccessibleDescription = "commandBarButton5";
            this.btnMergeTilemapLayer.AccessibleName = "commandBarButton5";
            this.btnMergeTilemapLayer.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnMergeTilemapLayer.DisplayName = "commandBarButton5";
            this.btnMergeTilemapLayer.Image = global::oEditor.Properties.Resources.Merge_13256;
            this.btnMergeTilemapLayer.Name = "btnMergeTilemapLayer";
            this.btnMergeTilemapLayer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnMergeTilemapLayer.Text = "commandBarButton5";
            this.btnMergeTilemapLayer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnMergeTilemapLayer.ToolTipText = "Merge Layer";
            this.btnMergeTilemapLayer.Click += new System.EventHandler(this.btnMergeTilemapLayer_Click);
            // 
            // btnRenameTilemapLayer
            // 
            this.btnRenameTilemapLayer.AccessibleDescription = "commandBarButton2";
            this.btnRenameTilemapLayer.AccessibleName = "commandBarButton2";
            this.btnRenameTilemapLayer.DisplayName = "commandBarButton2";
            this.btnRenameTilemapLayer.Image = ((System.Drawing.Image)(resources.GetObject("btnRenameTilemapLayer.Image")));
            this.btnRenameTilemapLayer.Name = "btnRenameTilemapLayer";
            this.btnRenameTilemapLayer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRenameTilemapLayer.Text = "commandBarButton2";
            this.btnRenameTilemapLayer.ToolTipText = "Rename";
            this.btnRenameTilemapLayer.Click += new System.EventHandler(this.btnRenameTilemapLayer_Click);
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
            this.documentTabStrip1.SelectedIndex = 1;
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
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageViewTilesets.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.ItemList;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageViewTilesets.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Bottom;
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
            this.btnRemoveTileset,
            this.dropDownTilesets});
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
            // dropDownTilesets
            // 
            this.dropDownTilesets.DisplayName = "commandBarDropDownList1";
            this.dropDownTilesets.DropDownAnimationEnabled = true;
            this.dropDownTilesets.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Text = "Isometric";
            radListDataItem2.Text = "Orthogonal";
            this.dropDownTilesets.Items.Add(radListDataItem1);
            this.dropDownTilesets.Items.Add(radListDataItem2);
            this.dropDownTilesets.MaxDropDownItems = 0;
            this.dropDownTilesets.Name = "dropDownTilesets";
            this.dropDownTilesets.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dropDownTilesets.Text = "";
            // 
            // toolboxCollisionLayer
            // 
            this.toolboxCollisionLayer.Controls.Add(this.radioPassable);
            this.toolboxCollisionLayer.Controls.Add(this.radioImpassable);
            this.toolboxCollisionLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxCollisionLayer.Location = new System.Drawing.Point(6, 29);
            this.toolboxCollisionLayer.Name = "toolboxCollisionLayer";
            this.toolboxCollisionLayer.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxCollisionLayer.Size = new System.Drawing.Size(518, 430);
            this.toolboxCollisionLayer.Text = "Collision Layer";
            // 
            // radioPassable
            // 
            this.radioPassable.Location = new System.Drawing.Point(3, 27);
            this.radioPassable.Name = "radioPassable";
            this.radioPassable.Size = new System.Drawing.Size(63, 18);
            this.radioPassable.TabIndex = 3;
            this.radioPassable.Text = "Passable";
            // 
            // radioImpassable
            // 
            this.radioImpassable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioImpassable.Location = new System.Drawing.Point(3, 3);
            this.radioImpassable.Name = "radioImpassable";
            this.radioImpassable.Size = new System.Drawing.Size(76, 18);
            this.radioImpassable.TabIndex = 2;
            this.radioImpassable.Text = "Impassable";
            this.radioImpassable.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // toolboxProperties
            // 
            this.toolboxProperties.Controls.Add(this.txtTilemapHeight);
            this.toolboxProperties.Controls.Add(this.txtTilemapWidth);
            this.toolboxProperties.Controls.Add(this.radLabel1);
            this.toolboxProperties.Controls.Add(this.radLabel5);
            this.toolboxProperties.Controls.Add(this.txtTilemapName);
            this.toolboxProperties.Controls.Add(this.radLabel4);
            this.toolboxProperties.Controls.Add(this.txtTilemapDescription);
            this.toolboxProperties.Controls.Add(this.radLabel3);
            this.toolboxProperties.Controls.Add(this.txtTilemapID);
            this.toolboxProperties.Controls.Add(this.radLabel2);
            this.toolboxProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolboxProperties.Location = new System.Drawing.Point(6, 29);
            this.toolboxProperties.Name = "toolboxProperties";
            this.toolboxProperties.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.toolboxProperties.Size = new System.Drawing.Size(518, 430);
            this.toolboxProperties.Text = "Properties";
            // 
            // txtTilemapHeight
            // 
            this.txtTilemapHeight.Location = new System.Drawing.Point(98, 197);
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
            this.txtTilemapWidth.Location = new System.Drawing.Point(98, 171);
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
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.ToolTipText = "Unique identification number";
            this.radLabel1.Size = new System.Drawing.Size(20, 18);
            this.radLabel1.TabIndex = 8;
            this.radLabel1.Text = "ID:";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(3, 199);
            this.radLabel5.Name = "radLabel5";
            // 
            // 
            // 
            this.radLabel5.RootElement.ToolTipText = "Sets the number of tiles vertically on tilemap";
            this.radLabel5.Size = new System.Drawing.Size(42, 18);
            this.radLabel5.TabIndex = 12;
            this.radLabel5.Text = "Height:";
            // 
            // txtTilemapName
            // 
            this.txtTilemapName.Location = new System.Drawing.Point(98, 29);
            this.txtTilemapName.Name = "txtTilemapName";
            // 
            // 
            // 
            this.txtTilemapName.RootElement.ToolTipText = "Sets the name of the tilemap";
            this.txtTilemapName.Size = new System.Drawing.Size(218, 20);
            this.txtTilemapName.TabIndex = 1;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(3, 172);
            this.radLabel4.Name = "radLabel4";
            // 
            // 
            // 
            this.radLabel4.RootElement.ToolTipText = "Sets the number of tiles horizontally on tilemap";
            this.radLabel4.Size = new System.Drawing.Size(39, 18);
            this.radLabel4.TabIndex = 11;
            this.radLabel4.Text = "Width:";
            // 
            // txtTilemapDescription
            // 
            this.txtTilemapDescription.AutoSize = false;
            this.txtTilemapDescription.Location = new System.Drawing.Point(98, 55);
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
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(3, 56);
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
            // txtTilemapID
            // 
            this.txtTilemapID.Location = new System.Drawing.Point(98, 3);
            this.txtTilemapID.Name = "txtTilemapID";
            this.txtTilemapID.ReadOnly = true;
            // 
            // 
            // 
            this.txtTilemapID.RootElement.ToolTipText = "Unique identiciation number";
            this.txtTilemapID.Size = new System.Drawing.Size(218, 20);
            this.txtTilemapID.TabIndex = 6;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 29);
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.ToolTipText = "Sets the name of the tilemap";
            this.radLabel2.Size = new System.Drawing.Size(39, 18);
            this.radLabel2.TabIndex = 9;
            this.radLabel2.Text = "Name:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // TilemapToolboxView
            // 
            this.ClientSize = new System.Drawing.Size(540, 475);
            this.Controls.Add(this.radDock);
            this.Name = "TilemapToolboxView";
            // 
            // 
            // 
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
            this.toolboxCollisionLayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioPassable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioImpassable)).EndInit();
            this.toolboxProperties.ResumeLayout(false);
            this.toolboxProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTilemapID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        private void radDock_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTileset_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnAddTileset() { Args = e });
        }

        private void btnRemoveTileset_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnRemoveTileset() { Page = SelectedTilesetPage });
        }


        private void btnRemoveTilemapLayer_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnRemoveTilemapLayer() { Item = SelectedTilemapLayer });
        }

        private void btnAddTilemapLayer_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnAddTilemapLayer() { Args = e });
        }

        private void btnMoveTilemapLayerUp_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnMoveTilemapLayerUp() { Item = SelectedTilemapLayer });
        }

        private void btnMoveTilemapLayerDown_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnMoveTilemapLayerDown() { Item = SelectedTilemapLayer });
        }

        private void btnMergeTilemapLayer_Click(object sender, EventArgs e)
        {
            RadMessageBox.Show("Merge layer is under construction...");
        }

        public void HideCloseButtonForPage(RadPageViewPage page)
        {
            var pageViewStripElement = ((Telerik.WinControls.UI.RadPageViewContentAreaElement)((radPageViewTilesets.ViewElement).ContentArea)).Owner as RadPageViewStripElement;
            var stripItem = ((Telerik.WinControls.UI.RadPageViewElement)(pageViewStripElement)).Items.Where(item => item.Page == page).FirstOrDefault();
            if (stripItem != null)
            {
                stripItem.ButtonsPanel.SetValue(LightVisualElement.VisibilityProperty, Telerik.WinControls.ElementVisibility.Collapsed);
                stripItem.ButtonsPanel.SetDefaultValueOverride(LightVisualElement.VisibilityProperty, Telerik.WinControls.ElementVisibility.Collapsed);
            }
        }

        private void btnRenameTilemapLayer_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnRenameTilemapLayer() { Item = SelectedTilemapLayer });
        }       
    }
}
