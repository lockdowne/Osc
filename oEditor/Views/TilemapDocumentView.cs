using oEditor.Controls;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using oEngine.Common;
using oEditor.Events;
using Telerik.WinControls.Enumerations;

namespace oEditor.Views
{
    public class TilemapDocumentView : RadForm, ITilemapDocumentView
    {
        private RadDock radDock1;
        private ToolWindow toolWindow1;
        private RadDock radDock2;
        private DocumentWindow documentWindow4;
        private RadPageView radPageView1;
        private RadCommandBar radCommandBar2;
        private CommandBarRowElement commandBarRowElement2;
        private CommandBarStripElement commandBarStripElement2;
        private CommandBarButton btnAddTileset;
        private CommandBarButton btnRemoveTileset;
        private DocumentContainer documentContainer2;
        private DocumentTabStrip documentTabStrip2;
        private DocumentWindow documentWindow3;
        private ToolTabStrip toolTabStrip1;
        private DocumentContainer documentContainer1;
        private DocumentTabStrip documentTabStrip1;
        private DocumentWindow documentWindow1;
        private RadCommandBar radCommandBar1;
        private CommandBarRowElement commandBarRowElement1;
        private CommandBarStripElement commandBarStripElement1;
        private RadCheckedListBox radCheckedListBox1;
        private RadCommandBar radCommandBar3;
        private CommandBarRowElement commandBarRowElement3;
        private CommandBarStripElement commandBarStripElement3;
        private CommandBarButton btnAddTilemapLayer;
        private CommandBarButton btnRemoveTilemapLayer;
        private CommandBarButton btnMoveTilemapLayerUp;
        private CommandBarButton btnMoveTilemapLayerDown;
        private CommandBarButton btnMergeTilemapLayer;
        private CommandBarButton btnRenameTilemap;
        private CommandBarToggleButton btnTilemapSelect;
        private CommandBarToggleButton btnTilemapDraw;
        private CommandBarToggleButton btnTilemapFill;
        private CommandBarToggleButton btnTilemapErase;
        private CommandBarToggleButton btnTilemapCollision;
        private CommandBarSeparator commandBarSeparator1;
        private CommandBarButton btnTilemapCopy;
        private CommandBarButton btnTilemapCut;
        private CommandBarButton btnTilemapProperties;
        private CommandBarSeparator commandBarSeparator2;
        private CommandBarToggleButton btnTilemapGrid;
        private TilemapRender tilemapRender;

        public Guid ID { get; set; }

        public Tilemap Tilemap
        {
            get { return tilemapRender.Tilemap; }
            set { tilemapRender.Tilemap = value; }
        }

        public RadPageView TilesetPages
        {
            get { return radPageView1; }
            set { radPageView1 = value; }
        }

        public TilesetPage SelectedTilesetPage
        {
            get { return radPageView1.SelectedPage as TilesetPage; }
        }

        public ListViewDataItem SelectedTilemapLayer
        {
            get { return radCheckedListBox1.SelectedItem; }
        }

        public RadCheckedListBox TilemapLayersListBox
        {
            get { return radCheckedListBox1; }
        }

        public DockWindow SelectedDocument
        {
            get { return radDock2.DocumentManager.ActiveDocument; }
        }

        public TilemapDocumentView()
        {
            InitializeComponent();

            radDock1.DockWindowClosing += (sender, e) => { e.Cancel = true; };
            radDock2.DockWindowClosing += (sender, e) => { e.Cancel = true; };

            this.radDock2.TabIndexChanged += (sender, e) =>
            {
                this.Publish(new OnTilemapDocumentChanged() { Window = SelectedDocument }.AsTask());
            };

            
        }

        private void InitializeComponent()
        {
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.toolWindow1 = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.radDock2 = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentWindow4 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radCommandBar2 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnAddTileset = new Telerik.WinControls.UI.CommandBarButton();
            this.btnRemoveTileset = new Telerik.WinControls.UI.CommandBarButton();
            this.documentContainer2 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip2 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.documentWindow3 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radCheckedListBox1 = new Telerik.WinControls.UI.RadCheckedListBox();
            this.radCommandBar3 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnAddTilemapLayer = new Telerik.WinControls.UI.CommandBarButton();
            this.btnRemoveTilemapLayer = new Telerik.WinControls.UI.CommandBarButton();
            this.btnMoveTilemapLayerUp = new Telerik.WinControls.UI.CommandBarButton();
            this.btnMoveTilemapLayerDown = new Telerik.WinControls.UI.CommandBarButton();
            this.btnMergeTilemapLayer = new Telerik.WinControls.UI.CommandBarButton();
            this.btnRenameTilemap = new Telerik.WinControls.UI.CommandBarButton();
            this.toolTabStrip1 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.documentWindow1 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnTilemapSelect = new Telerik.WinControls.UI.CommandBarToggleButton();
            this.btnTilemapDraw = new Telerik.WinControls.UI.CommandBarToggleButton();
            this.btnTilemapFill = new Telerik.WinControls.UI.CommandBarToggleButton();
            this.btnTilemapErase = new Telerik.WinControls.UI.CommandBarToggleButton();
            this.btnTilemapCollision = new Telerik.WinControls.UI.CommandBarToggleButton();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnTilemapCopy = new Telerik.WinControls.UI.CommandBarButton();
            this.btnTilemapCut = new Telerik.WinControls.UI.CommandBarButton();
            this.btnTilemapProperties = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnTilemapGrid = new Telerik.WinControls.UI.CommandBarToggleButton();
            this.tilemapRender = new oEditor.Controls.TilemapRender();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            this.toolWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDock2)).BeginInit();
            this.radDock2.SuspendLayout();
            this.documentWindow4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer2)).BeginInit();
            this.documentContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip2)).BeginInit();
            this.documentTabStrip2.SuspendLayout();
            this.documentWindow3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).BeginInit();
            this.toolTabStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            this.documentWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radDock1
            // 
            this.radDock1.ActiveWindow = this.toolWindow1;
            this.radDock1.Controls.Add(this.toolTabStrip1);
            this.radDock1.Controls.Add(this.documentContainer1);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 0);
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radDock1.Size = new System.Drawing.Size(1075, 451);
            this.radDock1.TabIndex = 0;
            this.radDock1.TabStop = false;
            this.radDock1.Text = "radDock1";
            // 
            // toolWindow1
            // 
            this.toolWindow1.Caption = null;
            this.toolWindow1.Controls.Add(this.radDock2);
            this.toolWindow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolWindow1.Location = new System.Drawing.Point(1, 24);
            this.toolWindow1.Name = "toolWindow1";
            this.toolWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.toolWindow1.Size = new System.Drawing.Size(525, 415);
            this.toolWindow1.Text = "Toolbox";
            // 
            // radDock2
            // 
            this.radDock2.ActiveWindow = this.documentWindow3;
            this.radDock2.Controls.Add(this.documentContainer2);
            this.radDock2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock2.IsCleanUpTarget = true;
            this.radDock2.Location = new System.Drawing.Point(0, 0);
            this.radDock2.MainDocumentContainer = this.documentContainer2;
            this.radDock2.Name = "radDock2";
            // 
            // 
            // 
            this.radDock2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radDock2.Size = new System.Drawing.Size(525, 415);
            this.radDock2.TabIndex = 0;
            this.radDock2.TabStop = false;
            this.radDock2.Text = "radDock2";
            // 
            // documentWindow4
            // 
            this.documentWindow4.Controls.Add(this.radPageView1);
            this.documentWindow4.Controls.Add(this.radCommandBar2);
            this.documentWindow4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow4.Location = new System.Drawing.Point(6, 29);
            this.documentWindow4.Name = "documentWindow4";
            this.documentWindow4.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow4.Size = new System.Drawing.Size(503, 370);
            this.documentWindow4.Text = "Tilesets";
            // 
            // radPageView1
            // 
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 30);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.Size = new System.Drawing.Size(503, 340);
            this.radPageView1.TabIndex = 1;
            this.radPageView1.Text = "radPageView1";
            // 
            // radCommandBar2
            // 
            this.radCommandBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar2.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar2.Name = "radCommandBar2";
            this.radCommandBar2.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement2});
            this.radCommandBar2.Size = new System.Drawing.Size(503, 30);
            this.radCommandBar2.TabIndex = 0;
            this.radCommandBar2.Text = "radCommandBar2";
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
            this.btnAddTileset,
            this.btnRemoveTileset});
            this.commandBarStripElement2.Name = "commandBarStripElement2";
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
            // documentContainer2
            // 
            this.documentContainer2.Controls.Add(this.documentTabStrip2);
            this.documentContainer2.Name = "documentContainer2";
            // 
            // 
            // 
            this.documentContainer2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer2.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            // 
            // documentTabStrip2
            // 
            this.documentTabStrip2.CanUpdateChildIndex = true;
            this.documentTabStrip2.Controls.Add(this.documentWindow4);
            this.documentTabStrip2.Controls.Add(this.documentWindow3);
            this.documentTabStrip2.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip2.Name = "documentTabStrip2";
            // 
            // 
            // 
            this.documentTabStrip2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip2.SelectedIndex = 1;
            this.documentTabStrip2.Size = new System.Drawing.Size(515, 405);
            this.documentTabStrip2.TabIndex = 0;
            this.documentTabStrip2.TabStop = false;
            // 
            // documentWindow3
            // 
            this.documentWindow3.Controls.Add(this.radCheckedListBox1);
            this.documentWindow3.Controls.Add(this.radCommandBar3);
            this.documentWindow3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow3.Location = new System.Drawing.Point(6, 29);
            this.documentWindow3.Name = "documentWindow3";
            this.documentWindow3.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow3.Size = new System.Drawing.Size(503, 370);
            this.documentWindow3.Text = "Layers";
            // 
            // radCheckedListBox1
            // 
            this.radCheckedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radCheckedListBox1.Location = new System.Drawing.Point(0, 30);
            this.radCheckedListBox1.Name = "radCheckedListBox1";
            this.radCheckedListBox1.Size = new System.Drawing.Size(503, 340);
            this.radCheckedListBox1.TabIndex = 1;
            this.radCheckedListBox1.Text = "radCheckedListBox1";
            // 
            // radCommandBar3
            // 
            this.radCommandBar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar3.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar3.Name = "radCommandBar3";
            this.radCommandBar3.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement3});
            this.radCommandBar3.Size = new System.Drawing.Size(503, 30);
            this.radCommandBar3.TabIndex = 0;
            this.radCommandBar3.Text = "radCommandBar3";
            // 
            // commandBarRowElement3
            // 
            this.commandBarRowElement3.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement3.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement3});
            // 
            // commandBarStripElement3
            // 
            this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
            this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnAddTilemapLayer,
            this.btnRemoveTilemapLayer,
            this.btnMoveTilemapLayerUp,
            this.btnMoveTilemapLayerDown,
            this.btnMergeTilemapLayer,
            this.btnRenameTilemap});
            this.commandBarStripElement3.Name = "commandBarStripElement3";
            // 
            // btnAddTilemapLayer
            // 
            this.btnAddTilemapLayer.AccessibleDescription = "commandBarButton1";
            this.btnAddTilemapLayer.AccessibleName = "commandBarButton1";
            this.btnAddTilemapLayer.DisplayName = "commandBarButton1";
            this.btnAddTilemapLayer.Image = global::oEditor.Properties.Resources.AddMark_10580;
            this.btnAddTilemapLayer.Name = "btnAddTilemapLayer";
            this.btnAddTilemapLayer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAddTilemapLayer.Text = "commandBarButton1";
            this.btnAddTilemapLayer.Click += new System.EventHandler(this.btnAddTilemapLayer_Click);
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
            this.btnRemoveTilemapLayer.Click += new System.EventHandler(this.btnRemoveTilemapLayer_Click);
            // 
            // btnMoveTilemapLayerUp
            // 
            this.btnMoveTilemapLayerUp.AccessibleDescription = "commandBarButton1";
            this.btnMoveTilemapLayerUp.AccessibleName = "commandBarButton1";
            this.btnMoveTilemapLayerUp.DisplayName = "commandBarButton1";
            this.btnMoveTilemapLayerUp.Image = global::oEditor.Properties.Resources.arrow_Up_16xLG;
            this.btnMoveTilemapLayerUp.Name = "btnMoveTilemapLayerUp";
            this.btnMoveTilemapLayerUp.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnMoveTilemapLayerUp.Text = "commandBarButton1";
            this.btnMoveTilemapLayerUp.Click += new System.EventHandler(this.btnMoveTilemapLayerUp_Click);
            // 
            // btnMoveTilemapLayerDown
            // 
            this.btnMoveTilemapLayerDown.AccessibleDescription = "commandBarButton2";
            this.btnMoveTilemapLayerDown.AccessibleName = "commandBarButton2";
            this.btnMoveTilemapLayerDown.DisplayName = "commandBarButton2";
            this.btnMoveTilemapLayerDown.Image = global::oEditor.Properties.Resources.arrow_Down_16xLG;
            this.btnMoveTilemapLayerDown.Name = "btnMoveTilemapLayerDown";
            this.btnMoveTilemapLayerDown.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnMoveTilemapLayerDown.Text = "commandBarButton2";
            this.btnMoveTilemapLayerDown.Click += new System.EventHandler(this.btnMoveTilemapLayerDown_Click);
            // 
            // btnMergeTilemapLayer
            // 
            this.btnMergeTilemapLayer.AccessibleDescription = "commandBarButton3";
            this.btnMergeTilemapLayer.AccessibleName = "commandBarButton3";
            this.btnMergeTilemapLayer.DisplayName = "commandBarButton3";
            this.btnMergeTilemapLayer.Image = global::oEditor.Properties.Resources.Merge_13256;
            this.btnMergeTilemapLayer.Name = "btnMergeTilemapLayer";
            this.btnMergeTilemapLayer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnMergeTilemapLayer.Text = "commandBarButton3";
            this.btnMergeTilemapLayer.Click += new System.EventHandler(this.btnMergeTilemapLayer_Click);
            // 
            // btnRenameTilemap
            // 
            this.btnRenameTilemap.AccessibleDescription = "commandBarButton4";
            this.btnRenameTilemap.AccessibleName = "commandBarButton4";
            this.btnRenameTilemap.DisplayName = "commandBarButton4";
            this.btnRenameTilemap.Image = global::oEditor.Properties.Resources.Rename_6779;
            this.btnRenameTilemap.Name = "btnRenameTilemap";
            this.btnRenameTilemap.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRenameTilemap.Text = "commandBarButton4";
            this.btnRenameTilemap.Click += new System.EventHandler(this.btnRenameTilemap_Click);
            // 
            // toolTabStrip1
            // 
            this.toolTabStrip1.CanUpdateChildIndex = true;
            this.toolTabStrip1.Controls.Add(this.toolWindow1);
            this.toolTabStrip1.Location = new System.Drawing.Point(5, 5);
            this.toolTabStrip1.Name = "toolTabStrip1";
            // 
            // 
            // 
            this.toolTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabStrip1.SelectedIndex = 0;
            this.toolTabStrip1.Size = new System.Drawing.Size(527, 441);
            this.toolTabStrip1.SizeInfo.AbsoluteSize = new System.Drawing.Size(527, 200);
            this.toolTabStrip1.SizeInfo.SplitterCorrection = new System.Drawing.Size(327, 0);
            this.toolTabStrip1.TabIndex = 1;
            this.toolTabStrip1.TabStop = false;
            // 
            // documentContainer1
            // 
            this.documentContainer1.Controls.Add(this.documentTabStrip1);
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer1.SizeInfo.AbsoluteSize = new System.Drawing.Size(534, 200);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-327, 0);
            this.documentContainer1.TabIndex = 2;
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.Controls.Add(this.documentWindow1);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(534, 441);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            // 
            // documentWindow1
            // 
            this.documentWindow1.Controls.Add(this.radCommandBar1);
            this.documentWindow1.Controls.Add(this.tilemapRender);
            this.documentWindow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow1.Location = new System.Drawing.Point(6, 29);
            this.documentWindow1.Name = "documentWindow1";
            this.documentWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow1.Size = new System.Drawing.Size(522, 406);
            this.documentWindow1.Text = "Tilemap";
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(522, 30);
            this.radCommandBar1.TabIndex = 2;
            this.radCommandBar1.Text = "radCommandBar1";
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
            this.btnTilemapSelect,
            this.btnTilemapDraw,
            this.btnTilemapFill,
            this.btnTilemapErase,
            this.btnTilemapCollision,
            this.commandBarSeparator1,
            this.btnTilemapCopy,
            this.btnTilemapCut,
            this.btnTilemapProperties,
            this.commandBarSeparator2,
            this.btnTilemapGrid});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // btnTilemapSelect
            // 
            this.btnTilemapSelect.AccessibleDescription = "commandBarToggleButton1";
            this.btnTilemapSelect.AccessibleName = "commandBarToggleButton1";
            this.btnTilemapSelect.DisplayName = "commandBarToggleButton1";
            this.btnTilemapSelect.Image = global::oEditor.Properties.Resources.RectangleSelectionTool_200;
            this.btnTilemapSelect.Name = "btnTilemapSelect";
            this.btnTilemapSelect.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTilemapSelect.Text = "commandBarToggleButton1";
            this.btnTilemapSelect.Click += new System.EventHandler(this.btnTilemapSelect_Click);
            // 
            // btnTilemapDraw
            // 
            this.btnTilemapDraw.AccessibleDescription = "commandBarToggleButton1";
            this.btnTilemapDraw.AccessibleName = "commandBarToggleButton1";
            this.btnTilemapDraw.DisplayName = "commandBarToggleButton1";
            this.btnTilemapDraw.Image = global::oEditor.Properties.Resources.PencilTool_206;
            this.btnTilemapDraw.Name = "btnTilemapDraw";
            this.btnTilemapDraw.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTilemapDraw.Text = "commandBarToggleButton1";
            this.btnTilemapDraw.Click += new System.EventHandler(this.btnTilemapDraw_Click);
            // 
            // btnTilemapFill
            // 
            this.btnTilemapFill.AccessibleDescription = "commandBarToggleButton2";
            this.btnTilemapFill.AccessibleName = "commandBarToggleButton2";
            this.btnTilemapFill.DisplayName = "commandBarToggleButton2";
            this.btnTilemapFill.Image = global::oEditor.Properties.Resources.FillTool_204;
            this.btnTilemapFill.Name = "btnTilemapFill";
            this.btnTilemapFill.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTilemapFill.Text = "commandBarToggleButton2";
            this.btnTilemapFill.Click += new System.EventHandler(this.btnTilemapFill_Click);
            // 
            // btnTilemapErase
            // 
            this.btnTilemapErase.AccessibleDescription = "commandBarToggleButton3";
            this.btnTilemapErase.AccessibleName = "commandBarToggleButton3";
            this.btnTilemapErase.DisplayName = "commandBarToggleButton3";
            this.btnTilemapErase.Image = global::oEditor.Properties.Resources.EraseTool_203;
            this.btnTilemapErase.Name = "btnTilemapErase";
            this.btnTilemapErase.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTilemapErase.Text = "commandBarToggleButton3";
            this.btnTilemapErase.Click += new System.EventHandler(this.btnTilemapErase_Click);
            // 
            // btnTilemapCollision
            // 
            this.btnTilemapCollision.AccessibleDescription = "commandBarToggleButton4";
            this.btnTilemapCollision.AccessibleName = "commandBarToggleButton4";
            this.btnTilemapCollision.DisplayName = "commandBarToggleButton4";
            this.btnTilemapCollision.Image = global::oEditor.Properties.Resources.Partition_16xLG;
            this.btnTilemapCollision.Name = "btnTilemapCollision";
            this.btnTilemapCollision.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTilemapCollision.Text = "commandBarToggleButton4";
            this.btnTilemapCollision.Click += new System.EventHandler(this.btnTilemapCollision_Click);
            // 
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
            this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
            this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // btnTilemapCopy
            // 
            this.btnTilemapCopy.AccessibleDescription = "commandBarButton1";
            this.btnTilemapCopy.AccessibleName = "commandBarButton1";
            this.btnTilemapCopy.DisplayName = "commandBarButton1";
            this.btnTilemapCopy.Image = global::oEditor.Properties.Resources.Copy_6524;
            this.btnTilemapCopy.Name = "btnTilemapCopy";
            this.btnTilemapCopy.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTilemapCopy.Text = "commandBarButton1";
            this.btnTilemapCopy.Click += new System.EventHandler(this.btnTilemapCopy_Click);
            // 
            // btnTilemapCut
            // 
            this.btnTilemapCut.AccessibleDescription = "commandBarButton2";
            this.btnTilemapCut.AccessibleName = "commandBarButton2";
            this.btnTilemapCut.DisplayName = "commandBarButton2";
            this.btnTilemapCut.Image = global::oEditor.Properties.Resources.Cut_6523;
            this.btnTilemapCut.Name = "btnTilemapCut";
            this.btnTilemapCut.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTilemapCut.Text = "commandBarButton2";
            this.btnTilemapCut.Click += new System.EventHandler(this.btnTilemapCut_Click);
            // 
            // btnTilemapProperties
            // 
            this.btnTilemapProperties.AccessibleDescription = "commandBarButton3";
            this.btnTilemapProperties.AccessibleName = "commandBarButton3";
            this.btnTilemapProperties.DisplayName = "commandBarButton3";
            this.btnTilemapProperties.Image = global::oEditor.Properties.Resources.procedure_16xLG;
            this.btnTilemapProperties.Name = "btnTilemapProperties";
            this.btnTilemapProperties.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTilemapProperties.Text = "commandBarButton3";
            this.btnTilemapProperties.Click += new System.EventHandler(this.btnTilemapProperties_Click);
            // 
            // commandBarSeparator2
            // 
            this.commandBarSeparator2.AccessibleDescription = "commandBarSeparator2";
            this.commandBarSeparator2.AccessibleName = "commandBarSeparator2";
            this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
            this.commandBarSeparator2.Name = "commandBarSeparator2";
            this.commandBarSeparator2.VisibleInOverflowMenu = false;
            // 
            // btnTilemapGrid
            // 
            this.btnTilemapGrid.AccessibleDescription = "commandBarToggleButton5";
            this.btnTilemapGrid.AccessibleName = "commandBarToggleButton5";
            this.btnTilemapGrid.DisplayName = "commandBarToggleButton5";
            this.btnTilemapGrid.Image = global::oEditor.Properties.Resources.grid_Toggle_16xLG;
            this.btnTilemapGrid.Name = "btnTilemapGrid";
            this.btnTilemapGrid.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTilemapGrid.Text = "commandBarToggleButton5";
            this.btnTilemapGrid.Click += new System.EventHandler(this.btnTilemapGrid_Click);
            // 
            // tilemapRender
            // 
            this.tilemapRender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilemapRender.Location = new System.Drawing.Point(0, 0);
            this.tilemapRender.Name = "tilemapRender";
            this.tilemapRender.Size = new System.Drawing.Size(522, 406);
            this.tilemapRender.TabIndex = 1;
            this.tilemapRender.Tilemap = null;
            // 
            // TilemapDocumentView
            // 
            this.ClientSize = new System.Drawing.Size(1075, 451);
            this.Controls.Add(this.radDock1);
            this.Name = "TilemapDocumentView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            this.toolWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radDock2)).EndInit();
            this.radDock2.ResumeLayout(false);
            this.documentWindow4.ResumeLayout(false);
            this.documentWindow4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer2)).EndInit();
            this.documentContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip2)).EndInit();
            this.documentTabStrip2.ResumeLayout(false);
            this.documentWindow3.ResumeLayout(false);
            this.documentWindow3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).EndInit();
            this.toolTabStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            this.documentWindow1.ResumeLayout(false);
            this.documentWindow1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void tilemapRender_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Publish(new OnTilemapMouseWheel() { MouseEvent = e }.AsTask());
        }

        private void tilemapRender_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Publish(new OnTilemapMouseDown() { MouseEvent = e }.AsTask());
        }

        private void tilemapRender_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Publish(new OnTilemapMouseMove() { MouseEvent = e }.AsTask());
        }

        private void tilemapRender_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Publish(new OnTilemapMouseUp() { MouseEvent = e }.AsTask());
        }

        private void btnAddTileset_Click(object sender, EventArgs e)
        {
            this.Publish(new OnAddTileset().AsTask());
        }

        private void btnRemoveTileset_Click(object sender, EventArgs e)
        {
            this.Publish(new OnRemoveTileset() { Page = SelectedTilesetPage }.AsTask());
        }

        private void btnAddTilemapLayer_Click(object sender, EventArgs e)
        {
            this.Publish(new OnAddTilemapLayer() { Args = e }.AsTask());
        }

        private void btnRemoveTilemapLayer_Click(object sender, EventArgs e)
        {
            this.Publish(new OnRemoveTilemapLayer() { Item = SelectedTilemapLayer }.AsTask());
        }

        private void btnMoveTilemapLayerUp_Click(object sender, EventArgs e)
        {
            this.Publish(new OnMoveTilemapLayerUp() { Item = SelectedTilemapLayer }.AsTask());
        }

        private void btnMoveTilemapLayerDown_Click(object sender, EventArgs e)
        {
            this.Publish(new OnMoveTilemapLayerDown() { Item = SelectedTilemapLayer }.AsTask());
        }

        private void btnMergeTilemapLayer_Click(object sender, EventArgs e)
        {
            // this.Publish(new OnMergeLayer()
        }

        private void btnRenameTilemap_Click(object sender, EventArgs e)
        {
            this.Publish(new OnRenameTilemapLayer() { Item = SelectedTilemapLayer }.AsTask());
        }

        private void btnTilemapSelect_Click(object sender, EventArgs e)
        {
            DeToggleMains();
            btnTilemapSelect.ToggleState = ToggleState.On;
            EnabledNonSelectableButtons();

            this.Publish(new OnTilemapSelectionBoxClicked().AsTask());
        }

        private void btnTilemapDraw_Click(object sender, EventArgs e)
        {
            DeToggleMains();
            btnTilemapDraw.ToggleState = ToggleState.On;
            DisableNonSelectableButtons();

            this.Publish(new OnTilemapDrawClicked().AsTask());
        }

        private void btnTilemapFill_Click(object sender, EventArgs e)
        {
            DeToggleMains();
            btnTilemapFill.ToggleState = ToggleState.On;
            DisableNonSelectableButtons();

            this.Publish(new OnTilemapFillClicked().AsTask());
        }

        private void btnTilemapErase_Click(object sender, EventArgs e)
        {
            DeToggleMains();
            btnTilemapErase.ToggleState = ToggleState.On;
            DisableNonSelectableButtons();

            this.Publish(new OnTilemapEraseClicked().AsTask());
        }

        private void btnTilemapCollision_Click(object sender, EventArgs e)
        {
            DeToggleMains();
            btnTilemapCollision.ToggleState = ToggleState.On;
            DisableNonSelectableButtons();

            this.Publish(new OnTilemapCollisionClicked().AsTask());
        }

        private void btnTilemapCopy_Click(object sender, EventArgs e)
        {
            this.Publish(new OnTilemapCopyClicked().AsTask());
        }

        private void btnTilemapCut_Click(object sender, EventArgs e)
        {
            this.Publish(new OnTilemapCutClicked().AsTask());
        }

        private void btnTilemapProperties_Click(object sender, EventArgs e)
        {
            this.Publish(new OnTilemapPropertiesClicked().AsTask());
        }

        private void btnTilemapGrid_Click(object sender, EventArgs e)
        {           
            this.Publish(new OnTilemapGridClicked().AsTask());
        }

        private void DeToggleMains()
        {
            this.btnTilemapSelect.ToggleState = ToggleState.Off;
            this.btnTilemapDraw.ToggleState = ToggleState.Off;
            this.btnTilemapFill.ToggleState = ToggleState.Off;
            this.btnTilemapErase.ToggleState = ToggleState.Off;
            this.btnTilemapCollision.ToggleState = ToggleState.Off;
        }

        private void DisableNonSelectableButtons()
        {
            this.btnTilemapCopy.Enabled = false;
            this.btnTilemapCut.Enabled = false;
        }

        private void EnabledNonSelectableButtons()
        {
            this.btnTilemapCopy.Enabled = true;
            this.btnTilemapCut.Enabled = true;
        }
    }
}
