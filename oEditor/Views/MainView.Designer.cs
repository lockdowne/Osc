namespace oEditor.Views
{
    partial class MainView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.cmdBar = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.menuFile = new Telerik.WinControls.UI.CommandBarDropDownButton();
            this.menuItemNewScene = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemOpenScene = new Telerik.WinControls.UI.RadMenuItem();
            this.menuEdit = new Telerik.WinControls.UI.CommandBarDropDownButton();
            this.menuView = new Telerik.WinControls.UI.CommandBarDropDownButton();
            this.menuViewConsole = new Telerik.WinControls.UI.RadMenuItem();
            this.menuViewEntities = new Telerik.WinControls.UI.RadMenuItem();
            this.menuViewProject = new Telerik.WinControls.UI.RadMenuItem();
            this.menuViewToolbox = new Telerik.WinControls.UI.RadMenuItem();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.radDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.windowEntities = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.treeViewEntities = new Telerik.WinControls.UI.RadTreeView();
            this.toolTabStrip3 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.windowToolbox = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.radSplitContainer2 = new Telerik.WinControls.UI.RadSplitContainer();
            this.documentContainer = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.toolTabStrip2 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.windowConsole = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.listboxConsole = new Telerik.WinControls.UI.RadListControl();
            this.toolTabStrip4 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.windowProject = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.treeViewProject = new Telerik.WinControls.UI.RadTreeView();
            this.toolTabStrip6 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.toolTabStrip5 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.contextAdd = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextAddEntity = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.contextAddExpand = new Telerik.WinControls.UI.RadMenuItem();
            this.contextAddCollapse = new Telerik.WinControls.UI.RadMenuItem();
            this.contextEdit = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextEditEntity = new Telerik.WinControls.UI.RadMenuItem();
            this.contextEditDelete = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem2 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.contextEditExpand = new Telerik.WinControls.UI.RadMenuItem();
            this.contextEditCollapse = new Telerik.WinControls.UI.RadMenuItem();
            this.radContextMenuManager = new Telerik.WinControls.UI.RadContextMenuManager();
            ((System.ComponentModel.ISupportInitialize)(this.cmdBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).BeginInit();
            this.radDock.SuspendLayout();
            this.windowEntities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip3)).BeginInit();
            this.toolTabStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).BeginInit();
            this.radSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip2)).BeginInit();
            this.toolTabStrip2.SuspendLayout();
            this.windowConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listboxConsole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip4)).BeginInit();
            this.toolTabStrip4.SuspendLayout();
            this.windowProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip6)).BeginInit();
            this.toolTabStrip6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip5)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdBar
            // 
            this.cmdBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdBar.Location = new System.Drawing.Point(0, 0);
            this.cmdBar.Name = "cmdBar";
            this.cmdBar.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1,
            this.commandBarRowElement2});
            this.cmdBar.Size = new System.Drawing.Size(1184, 60);
            this.cmdBar.TabIndex = 0;
            this.cmdBar.Text = "radCommandBar1";
            this.cmdBar.ThemeName = "VisualStudio2012Dark";
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
            this.menuFile,
            this.menuEdit,
            this.menuView});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // menuFile
            // 
            this.menuFile.AccessibleDescription = "File";
            this.menuFile.AccessibleName = "File";
            this.menuFile.DisplayName = "commandBarDropDownButton1";
            this.menuFile.DrawText = true;
            this.menuFile.Image = null;
            this.menuFile.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuItemNewScene,
            this.menuItemOpenScene});
            this.menuFile.Name = "menuFile";
            this.menuFile.Text = "File";
            // 
            // menuItemNewScene
            // 
            this.menuItemNewScene.AccessibleDescription = "New Scene";
            this.menuItemNewScene.AccessibleName = "New Scene";
            this.menuItemNewScene.Name = "menuItemNewScene";
            this.menuItemNewScene.Text = "New Scene";
            // 
            // menuItemOpenScene
            // 
            this.menuItemOpenScene.AccessibleDescription = "Open Scene";
            this.menuItemOpenScene.AccessibleName = "Open Scene";
            this.menuItemOpenScene.Name = "menuItemOpenScene";
            this.menuItemOpenScene.Text = "Open Scene";
            // 
            // menuEdit
            // 
            this.menuEdit.AccessibleDescription = "Edit";
            this.menuEdit.AccessibleName = "Edit";
            this.menuEdit.DisplayName = "Edit";
            this.menuEdit.DrawText = true;
            this.menuEdit.Image = null;
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Text = "Edit";
            // 
            // menuView
            // 
            this.menuView.AccessibleDescription = "View";
            this.menuView.AccessibleName = "View";
            this.menuView.DisplayName = "View";
            this.menuView.DrawText = true;
            this.menuView.Image = null;
            this.menuView.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuViewConsole,
            this.menuViewEntities,
            this.menuViewProject,
            this.menuViewToolbox});
            this.menuView.Name = "menuView";
            this.menuView.Text = "View";
            // 
            // menuViewConsole
            // 
            this.menuViewConsole.AccessibleDescription = "Console";
            this.menuViewConsole.AccessibleName = "Console";
            this.menuViewConsole.CheckOnClick = true;
            this.menuViewConsole.IsChecked = true;
            this.menuViewConsole.Name = "menuViewConsole";
            this.menuViewConsole.Text = "Console";
            this.menuViewConsole.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.menuViewConsole.Click += new System.EventHandler(this.menuViewConsole_Click);
            // 
            // menuViewEntities
            // 
            this.menuViewEntities.AccessibleDescription = "Entities";
            this.menuViewEntities.AccessibleName = "Entities";
            this.menuViewEntities.CheckOnClick = true;
            this.menuViewEntities.IsChecked = true;
            this.menuViewEntities.Name = "menuViewEntities";
            this.menuViewEntities.Text = "Entities";
            this.menuViewEntities.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.menuViewEntities.Click += new System.EventHandler(this.menuViewEntities_Click);
            // 
            // menuViewProject
            // 
            this.menuViewProject.AccessibleDescription = "Project";
            this.menuViewProject.AccessibleName = "Project";
            this.menuViewProject.CheckOnClick = true;
            this.menuViewProject.IsChecked = true;
            this.menuViewProject.Name = "menuViewProject";
            this.menuViewProject.Text = "Project";
            this.menuViewProject.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.menuViewProject.Click += new System.EventHandler(this.menuViewProject_Click);
            // 
            // menuViewToolbox
            // 
            this.menuViewToolbox.AccessibleDescription = "Toolbox";
            this.menuViewToolbox.AccessibleName = "Toolbox";
            this.menuViewToolbox.CheckOnClick = true;
            this.menuViewToolbox.IsChecked = true;
            this.menuViewToolbox.Name = "menuViewToolbox";
            this.menuViewToolbox.Text = "Toolbox";
            this.menuViewToolbox.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.menuViewToolbox.Click += new System.EventHandler(this.menuViewToolbox_Click);
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
            this.commandBarButton1});
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            // 
            // commandBarButton1
            // 
            this.commandBarButton1.AccessibleDescription = "commandBarButton1";
            this.commandBarButton1.AccessibleName = "commandBarButton1";
            this.commandBarButton1.DisplayName = "commandBarButton1";
            this.commandBarButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton1.Image")));
            this.commandBarButton1.Name = "commandBarButton1";
            this.commandBarButton1.Text = "commandBarButton1";
            // 
            // radDock
            // 
            this.radDock.ActiveWindow = this.windowToolbox;
            this.radDock.Controls.Add(this.toolTabStrip3);
            this.radDock.Controls.Add(this.radSplitContainer2);
            this.radDock.Controls.Add(this.toolTabStrip4);
            this.radDock.Controls.Add(this.toolTabStrip6);
            this.radDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock.IsCleanUpTarget = true;
            this.radDock.Location = new System.Drawing.Point(0, 60);
            this.radDock.MainDocumentContainer = this.documentContainer;
            this.radDock.Name = "radDock";
            this.radDock.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.radDock.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock.Size = new System.Drawing.Size(1184, 670);
            this.radDock.SplitterWidth = 2;
            this.radDock.TabIndex = 1;
            this.radDock.TabStop = false;
            this.radDock.Text = "radDock1";
            this.radDock.ThemeName = "VisualStudio2012Dark";
            this.radDock.DockWindowClosing += new Telerik.WinControls.UI.Docking.DockWindowCancelEventHandler(this.radDock_DockWindowClosing);
            // 
            // windowEntities
            // 
            this.windowEntities.Caption = null;
            this.windowEntities.CloseAction = Telerik.WinControls.UI.Docking.DockWindowCloseAction.CloseAndDispose;
            this.windowEntities.Controls.Add(this.treeViewEntities);
            this.windowEntities.Location = new System.Drawing.Point(4, 24);
            this.windowEntities.Name = "windowEntities";
            this.windowEntities.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.windowEntities.Size = new System.Drawing.Size(192, 642);
            this.windowEntities.Text = "Entities";
            // 
            // treeViewEntities
            // 
            this.treeViewEntities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.treeViewEntities.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeViewEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewEntities.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.treeViewEntities.ForeColor = System.Drawing.Color.White;
            this.treeViewEntities.Location = new System.Drawing.Point(0, 0);
            this.treeViewEntities.Name = "treeViewEntities";
            this.treeViewEntities.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeViewEntities.Size = new System.Drawing.Size(192, 642);
            this.treeViewEntities.TabIndex = 0;
            this.treeViewEntities.Text = "radTreeView1";
            this.treeViewEntities.ThemeName = "VisualStudio2012Dark";
            this.treeViewEntities.NodeExpandedChanged += new Telerik.WinControls.UI.RadTreeView.TreeViewEventHandler(this.treeViewEntities_NodeExpandedChanged);
            // 
            // toolTabStrip3
            // 
            this.toolTabStrip3.CanUpdateChildIndex = true;
            this.toolTabStrip3.Controls.Add(this.windowToolbox);
            this.toolTabStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolTabStrip3.Name = "toolTabStrip3";
            // 
            // 
            // 
            this.toolTabStrip3.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.toolTabStrip3.SelectedIndex = 0;
            this.toolTabStrip3.Size = new System.Drawing.Size(200, 670);
            this.toolTabStrip3.TabIndex = 2;
            this.toolTabStrip3.TabStop = false;
            this.toolTabStrip3.ThemeName = "VisualStudio2012Dark";
            // 
            // windowToolbox
            // 
            this.windowToolbox.Caption = null;
            this.windowToolbox.Location = new System.Drawing.Point(4, 24);
            this.windowToolbox.Name = "windowToolbox";
            this.windowToolbox.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.windowToolbox.Size = new System.Drawing.Size(192, 642);
            this.windowToolbox.Text = "Toolbox";
            // 
            // radSplitContainer2
            // 
            this.radSplitContainer2.Controls.Add(this.documentContainer);
            this.radSplitContainer2.Controls.Add(this.toolTabStrip2);
            this.radSplitContainer2.IsCleanUpTarget = true;
            this.radSplitContainer2.Location = new System.Drawing.Point(202, 0);
            this.radSplitContainer2.Name = "radSplitContainer2";
            this.radSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.radSplitContainer2.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radSplitContainer2.Size = new System.Drawing.Size(578, 670);
            this.radSplitContainer2.SplitterWidth = 2;
            this.radSplitContainer2.TabIndex = 0;
            this.radSplitContainer2.TabStop = false;
            this.radSplitContainer2.ThemeName = "VisualStudio2012Dark";
            // 
            // documentContainer
            // 
            this.documentContainer.Name = "documentContainer";
            // 
            // 
            // 
            this.documentContainer.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer.SplitterWidth = 2;
            this.documentContainer.ThemeName = "VisualStudio2012Dark";
            // 
            // toolTabStrip2
            // 
            this.toolTabStrip2.CanUpdateChildIndex = true;
            this.toolTabStrip2.Controls.Add(this.windowConsole);
            this.toolTabStrip2.Location = new System.Drawing.Point(0, 470);
            this.toolTabStrip2.Name = "toolTabStrip2";
            // 
            // 
            // 
            this.toolTabStrip2.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.toolTabStrip2.SelectedIndex = 0;
            this.toolTabStrip2.Size = new System.Drawing.Size(578, 200);
            this.toolTabStrip2.TabIndex = 1;
            this.toolTabStrip2.TabStop = false;
            this.toolTabStrip2.ThemeName = "VisualStudio2012Dark";
            // 
            // windowConsole
            // 
            this.windowConsole.Caption = null;
            this.windowConsole.Controls.Add(this.listboxConsole);
            this.windowConsole.Location = new System.Drawing.Point(4, 24);
            this.windowConsole.Name = "windowConsole";
            this.windowConsole.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.windowConsole.Size = new System.Drawing.Size(570, 172);
            this.windowConsole.Text = "Console";
            // 
            // listboxConsole
            // 
            this.listboxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxConsole.Location = new System.Drawing.Point(0, 0);
            this.listboxConsole.Name = "listboxConsole";
            this.listboxConsole.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listboxConsole.Size = new System.Drawing.Size(570, 172);
            this.listboxConsole.TabIndex = 0;
            this.listboxConsole.Text = "radListControl1";
            this.listboxConsole.ThemeName = "VisualStudio2012Dark";
            // 
            // toolTabStrip4
            // 
            this.toolTabStrip4.CanUpdateChildIndex = true;
            this.toolTabStrip4.Controls.Add(this.windowProject);
            this.toolTabStrip4.Location = new System.Drawing.Point(782, 0);
            this.toolTabStrip4.Name = "toolTabStrip4";
            // 
            // 
            // 
            this.toolTabStrip4.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.toolTabStrip4.SelectedIndex = 0;
            this.toolTabStrip4.Size = new System.Drawing.Size(200, 670);
            this.toolTabStrip4.TabIndex = 6;
            this.toolTabStrip4.TabStop = false;
            this.toolTabStrip4.ThemeName = "VisualStudio2012Dark";
            // 
            // windowProject
            // 
            this.windowProject.Caption = null;
            this.windowProject.Controls.Add(this.treeViewProject);
            this.windowProject.Location = new System.Drawing.Point(4, 24);
            this.windowProject.Name = "windowProject";
            this.windowProject.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.windowProject.Size = new System.Drawing.Size(192, 642);
            this.windowProject.Text = "Project";
            // 
            // treeViewProject
            // 
            this.treeViewProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewProject.Location = new System.Drawing.Point(0, 0);
            this.treeViewProject.Name = "treeViewProject";
            this.treeViewProject.Size = new System.Drawing.Size(192, 642);
            this.treeViewProject.TabIndex = 0;
            this.treeViewProject.Text = "radTreeView1";
            this.treeViewProject.ThemeName = "VisualStudio2012Dark";
            // 
            // toolTabStrip6
            // 
            this.toolTabStrip6.CanUpdateChildIndex = true;
            this.toolTabStrip6.Controls.Add(this.windowEntities);
            this.toolTabStrip6.Location = new System.Drawing.Point(984, 0);
            this.toolTabStrip6.Name = "toolTabStrip6";
            // 
            // 
            // 
            this.toolTabStrip6.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.toolTabStrip6.SelectedIndex = 0;
            this.toolTabStrip6.Size = new System.Drawing.Size(200, 670);
            this.toolTabStrip6.TabIndex = 7;
            this.toolTabStrip6.TabStop = false;
            this.toolTabStrip6.ThemeName = "VisualStudio2012Dark";
            // 
            // toolTabStrip5
            // 
            this.toolTabStrip5.CanUpdateChildIndex = true;
            this.toolTabStrip5.Location = new System.Drawing.Point(0, 0);
            this.toolTabStrip5.Name = "toolTabStrip5";
            // 
            // 
            // 
            this.toolTabStrip5.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabStrip5.Size = new System.Drawing.Size(200, 200);
            this.toolTabStrip5.TabIndex = 0;
            this.toolTabStrip5.TabStop = false;
            this.toolTabStrip5.ThemeName = "VisualStudio2012Dark";
            // 
            // contextAdd
            // 
            this.contextAdd.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.contextAddEntity,
            this.radMenuSeparatorItem1,
            this.contextAddExpand,
            this.contextAddCollapse});
            this.contextAdd.ThemeName = "VisualStudio2012Dark";
            // 
            // contextAddEntity
            // 
            this.contextAddEntity.AccessibleDescription = "Add Entity";
            this.contextAddEntity.AccessibleName = "Add Entity";
            this.contextAddEntity.Name = "contextAddEntity";
            this.contextAddEntity.Text = "Add Entity";
            this.contextAddEntity.Click += new System.EventHandler(this.contextAddEntity_Click);
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.AccessibleDescription = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.AccessibleName = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            // 
            // contextAddExpand
            // 
            this.contextAddExpand.AccessibleDescription = "Expand";
            this.contextAddExpand.AccessibleName = "Expand";
            this.contextAddExpand.Name = "contextAddExpand";
            this.contextAddExpand.Text = "Expand";
            this.contextAddExpand.Click += new System.EventHandler(this.contextAddExpand_Click);
            // 
            // contextAddCollapse
            // 
            this.contextAddCollapse.AccessibleDescription = "Collapse";
            this.contextAddCollapse.AccessibleName = "Collapse";
            this.contextAddCollapse.Name = "contextAddCollapse";
            this.contextAddCollapse.Text = "Collapse";
            this.contextAddCollapse.Click += new System.EventHandler(this.contextAddCollapse_Click);
            // 
            // contextEdit
            // 
            this.contextEdit.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.contextEditEntity,
            this.contextEditDelete,
            this.radMenuSeparatorItem2,
            this.contextEditExpand,
            this.contextEditCollapse});
            this.contextEdit.ThemeName = "VisualStudio2012Dark";
            // 
            // contextEditEntity
            // 
            this.contextEditEntity.AccessibleDescription = "Edit";
            this.contextEditEntity.AccessibleName = "Edit";
            this.contextEditEntity.Name = "contextEditEntity";
            this.contextEditEntity.Text = "Edit";
            this.contextEditEntity.Click += new System.EventHandler(this.contextEditEntity_Click);
            // 
            // contextEditDelete
            // 
            this.contextEditDelete.AccessibleDescription = "Delete";
            this.contextEditDelete.AccessibleName = "Delete";
            this.contextEditDelete.Name = "contextEditDelete";
            this.contextEditDelete.Text = "Delete";
            this.contextEditDelete.Click += new System.EventHandler(this.contextEditDelete_Click);
            // 
            // radMenuSeparatorItem2
            // 
            this.radMenuSeparatorItem2.AccessibleDescription = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.AccessibleName = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Name = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Text = "radMenuSeparatorItem2";
            // 
            // contextEditExpand
            // 
            this.contextEditExpand.AccessibleDescription = "Expand";
            this.contextEditExpand.AccessibleName = "Expand";
            this.contextEditExpand.Name = "contextEditExpand";
            this.contextEditExpand.Text = "Expand";
            this.contextEditExpand.Click += new System.EventHandler(this.contextEditExpand_Click);
            // 
            // contextEditCollapse
            // 
            this.contextEditCollapse.AccessibleDescription = "Collapse";
            this.contextEditCollapse.AccessibleName = "Collapse";
            this.contextEditCollapse.Name = "contextEditCollapse";
            this.contextEditCollapse.Text = "Collapse";
            this.contextEditCollapse.Click += new System.EventHandler(this.contextEditCollapse_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 730);
            this.Controls.Add(this.radDock);
            this.Controls.Add(this.cmdBar);
            this.Name = "MainView";
            this.Text = "oEditor";
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmdBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).EndInit();
            this.radDock.ResumeLayout(false);
            this.windowEntities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeViewEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip3)).EndInit();
            this.toolTabStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).EndInit();
            this.radSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip2)).EndInit();
            this.toolTabStrip2.ResumeLayout(false);
            this.windowConsole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listboxConsole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip4)).EndInit();
            this.toolTabStrip4.ResumeLayout(false);
            this.windowProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeViewProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip6)).EndInit();
            this.toolTabStrip6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCommandBar cmdBar;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.Docking.RadDock radDock;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer2;
        private Telerik.WinControls.UI.Docking.ToolWindow windowToolbox;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip2;
        private Telerik.WinControls.UI.Docking.ToolWindow windowConsole;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip3;
        private Telerik.WinControls.UI.Docking.ToolWindow windowEntities;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip5;
        private Telerik.WinControls.UI.RadListControl listboxConsole;
        private Telerik.WinControls.UI.CommandBarDropDownButton menuFile;
        private Telerik.WinControls.UI.RadMenuItem menuItemNewScene;
        private Telerik.WinControls.UI.RadMenuItem menuItemOpenScene;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
        private Telerik.WinControls.UI.RadTreeView treeViewEntities;
        private Telerik.WinControls.UI.Docking.ToolWindow windowProject;
        private Telerik.WinControls.UI.RadTreeView treeViewProject;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip4;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip6;
        private Telerik.WinControls.UI.CommandBarDropDownButton menuEdit;
        private Telerik.WinControls.UI.CommandBarDropDownButton menuView;
        private Telerik.WinControls.UI.RadMenuItem menuItemConsole;
        private Telerik.WinControls.UI.RadMenuItem menuViewConsole;
        private Telerik.WinControls.UI.RadMenuItem menuViewEntities;
        private Telerik.WinControls.UI.RadMenuItem menuViewProject;
        private Telerik.WinControls.UI.RadMenuItem menuViewToolbox;
        private Telerik.WinControls.UI.RadContextMenu contextAdd;
        private Telerik.WinControls.UI.RadMenuItem contextAddEntity;
        private Telerik.WinControls.UI.RadContextMenu contextEdit;
        private Telerik.WinControls.UI.RadMenuItem contextEditEntity;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem contextAddExpand;
        private Telerik.WinControls.UI.RadMenuItem contextAddCollapse;
        private Telerik.WinControls.UI.RadMenuItem contextEditDelete;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem2;
        private Telerik.WinControls.UI.RadMenuItem contextEditExpand;
        private Telerik.WinControls.UI.RadMenuItem contextEditCollapse;
    }
}