namespace Osc.Rotch.Editor.Views
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
            this.radStatusStrip = new Telerik.WinControls.UI.RadStatusStrip();
            this.radDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.radRibbonBar1 = new Telerik.WinControls.UI.RadRibbonBar();
            this.ribbonTab1 = new Telerik.WinControls.UI.RibbonTab();
            this.radRibbonBarGroup1 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.btnSaveLocal = new Telerik.WinControls.UI.RadButtonElement();
            this.btnSaveSync = new Telerik.WinControls.UI.RadButtonElement();
            this.radRibbonBarGroup3 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.ribbonTab2 = new Telerik.WinControls.UI.RibbonTab();
            this.radRibbonBarGroup2 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.chkConsoleWindow = new Telerik.WinControls.UI.RadCheckBoxElement();
            this.chkProjectWindow = new Telerik.WinControls.UI.RadCheckBoxElement();
            this.chkEntitiesWindow = new Telerik.WinControls.UI.RadCheckBoxElement();
            this.radRibbonBarButtonGroup2 = new Telerik.WinControls.UI.RadRibbonBarButtonGroup();
            this.radRibbonBarButtonGroup3 = new Telerik.WinControls.UI.RadRibbonBarButtonGroup();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).BeginInit();
            this.radDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radStatusStrip
            // 
            this.radStatusStrip.Location = new System.Drawing.Point(0, 544);
            this.radStatusStrip.Name = "radStatusStrip";
            this.radStatusStrip.Size = new System.Drawing.Size(792, 26);
            this.radStatusStrip.TabIndex = 1;
            this.radStatusStrip.Text = "radStatusStrip1";
            // 
            // radDock
            // 
            this.radDock.Controls.Add(this.documentContainer1);
            this.radDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock.IsCleanUpTarget = true;
            this.radDock.Location = new System.Drawing.Point(0, 162);
            this.radDock.MainDocumentContainer = this.documentContainer1;
            this.radDock.Name = "radDock";
            // 
            // 
            // 
            this.radDock.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock.Size = new System.Drawing.Size(792, 382);
            this.radDock.TabIndex = 2;
            this.radDock.TabStop = false;
            this.radDock.Text = "radDock1";
            this.radDock.DockWindowAdded += new Telerik.WinControls.UI.Docking.DockWindowEventHandler(this.radDock_DockWindowAdded);
            this.radDock.DockWindowClosing += new Telerik.WinControls.UI.Docking.DockWindowCancelEventHandler(this.radDock_DockWindowClosing);
            this.radDock.DockWindowClosed += new Telerik.WinControls.UI.Docking.DockWindowEventHandler(this.radDock_DockWindowClosed);
            // 
            // documentContainer1
            // 
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            // 
            // radRibbonBar1
            // 
            this.radRibbonBar1.CommandTabs.AddRange(new Telerik.WinControls.RadItem[] {
            this.ribbonTab1,
            this.ribbonTab2});
            this.radRibbonBar1.Location = new System.Drawing.Point(0, 0);
            this.radRibbonBar1.Name = "radRibbonBar1";
            this.radRibbonBar1.Size = new System.Drawing.Size(792, 162);
            this.radRibbonBar1.TabIndex = 3;
            this.radRibbonBar1.Text = "MainView";
            this.radRibbonBar1.Click += new System.EventHandler(this.radRibbonBar1_Click);
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.AccessibleDescription = "Home";
            this.ribbonTab1.AccessibleName = "Home";
            this.ribbonTab1.IsSelected = true;
            this.ribbonTab1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radRibbonBarGroup1,
            this.radRibbonBarGroup3});
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Home";
            // 
            // radRibbonBarGroup1
            // 
            this.radRibbonBarGroup1.AccessibleDescription = "Save";
            this.radRibbonBarGroup1.AccessibleName = "Save";
            this.radRibbonBarGroup1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnSaveLocal,
            this.btnSaveSync});
            this.radRibbonBarGroup1.Name = "radRibbonBarGroup1";
            this.radRibbonBarGroup1.Text = "Save";
            this.radRibbonBarGroup1.Click += new System.EventHandler(this.radRibbonBarGroup1_Click);
            // 
            // btnSaveLocal
            // 
            this.btnSaveLocal.AccessibleDescription = "Local";
            this.btnSaveLocal.AccessibleName = "Local";
            this.btnSaveLocal.Image = global::Osc.Rotch.Editor.Properties.Resources.save_32;
            this.btnSaveLocal.Name = "btnSaveLocal";
            this.btnSaveLocal.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSaveLocal.Text = "Local";
            this.btnSaveLocal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveLocal.Click += new System.EventHandler(this.btnSaveLocal_Click);
            // 
            // btnSaveSync
            // 
            this.btnSaveSync.AccessibleDescription = "Sync";
            this.btnSaveSync.AccessibleName = "Sync";
            this.btnSaveSync.Image = global::Osc.Rotch.Editor.Properties.Resources.sinchronize_32;
            this.btnSaveSync.Name = "btnSaveSync";
            this.btnSaveSync.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSaveSync.Text = "Sync";
            this.btnSaveSync.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveSync.Click += new System.EventHandler(this.btnSaveSync_Click);
            // 
            // radRibbonBarGroup3
            // 
            this.radRibbonBarGroup3.AccessibleDescription = "Commands";
            this.radRibbonBarGroup3.AccessibleName = "Commands";
            this.radRibbonBarGroup3.Name = "radRibbonBarGroup3";
            this.radRibbonBarGroup3.Text = "Commands";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.AccessibleDescription = "View";
            this.ribbonTab2.AccessibleName = "View";
            this.ribbonTab2.IsSelected = false;
            this.ribbonTab2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radRibbonBarGroup2});
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "View";
            // 
            // radRibbonBarGroup2
            // 
            this.radRibbonBarGroup2.AccessibleDescription = "Windows";
            this.radRibbonBarGroup2.AccessibleName = "Windows";
            this.radRibbonBarGroup2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.chkConsoleWindow,
            this.chkProjectWindow,
            this.chkEntitiesWindow});
            this.radRibbonBarGroup2.Name = "radRibbonBarGroup2";
            this.radRibbonBarGroup2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.radRibbonBarGroup2.Text = "Visible Windows";
            // 
            // chkConsoleWindow
            // 
            this.chkConsoleWindow.AccessibleDescription = "Console";
            this.chkConsoleWindow.AccessibleName = "Console";
            this.chkConsoleWindow.Checked = true;
            this.chkConsoleWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsoleWindow.Name = "chkConsoleWindow";
            this.chkConsoleWindow.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.chkConsoleWindow.ReadOnly = false;
            this.chkConsoleWindow.StretchVertically = false;
            this.chkConsoleWindow.Text = "Console";
            this.chkConsoleWindow.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // chkProjectWindow
            // 
            this.chkProjectWindow.AccessibleDescription = "Project";
            this.chkProjectWindow.AccessibleName = "Project";
            this.chkProjectWindow.Checked = true;
            this.chkProjectWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProjectWindow.Name = "chkProjectWindow";
            this.chkProjectWindow.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.chkProjectWindow.ReadOnly = false;
            this.chkProjectWindow.StretchVertically = false;
            this.chkProjectWindow.Text = "Project Explorer";
            this.chkProjectWindow.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // chkEntitiesWindow
            // 
            this.chkEntitiesWindow.AccessibleDescription = "Entities";
            this.chkEntitiesWindow.AccessibleName = "Entities";
            this.chkEntitiesWindow.Checked = true;
            this.chkEntitiesWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEntitiesWindow.Name = "chkEntitiesWindow";
            this.chkEntitiesWindow.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.chkEntitiesWindow.ReadOnly = false;
            this.chkEntitiesWindow.StretchVertically = false;
            this.chkEntitiesWindow.Text = "Entities";
            this.chkEntitiesWindow.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radRibbonBarButtonGroup2
            // 
            this.radRibbonBarButtonGroup2.AccessibleDescription = "radRibbonBarButtonGroup2";
            this.radRibbonBarButtonGroup2.AccessibleName = "radRibbonBarButtonGroup2";
            this.radRibbonBarButtonGroup2.Name = "radRibbonBarButtonGroup2";
            this.radRibbonBarButtonGroup2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.radRibbonBarButtonGroup2.Text = "radRibbonBarButtonGroup2";
            // 
            // radRibbonBarButtonGroup3
            // 
            this.radRibbonBarButtonGroup3.AccessibleDescription = "radRibbonBarButtonGroup3";
            this.radRibbonBarButtonGroup3.AccessibleName = "radRibbonBarButtonGroup3";
            this.radRibbonBarButtonGroup3.Name = "radRibbonBarButtonGroup3";
            this.radRibbonBarButtonGroup3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.radRibbonBarButtonGroup3.Text = "radRibbonBarButtonGroup3";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 570);
            this.Controls.Add(this.radDock);
            this.Controls.Add(this.radStatusStrip);
            this.Controls.Add(this.radRibbonBar1);
            this.Name = "MainView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "MainView";
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).EndInit();
            this.radDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip;
        private Telerik.WinControls.UI.Docking.RadDock radDock;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.RadRibbonBar radRibbonBar1;
        private Telerik.WinControls.UI.RibbonTab ribbonTab1;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup1;
        private Telerik.WinControls.UI.RadButtonElement btnSaveLocal;
        private Telerik.WinControls.UI.RadButtonElement btnSaveSync;
        private Telerik.WinControls.UI.RibbonTab ribbonTab2;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup2;
        private Telerik.WinControls.UI.RadCheckBoxElement chkConsoleWindow;
        private Telerik.WinControls.UI.RadCheckBoxElement chkProjectWindow;
        private Telerik.WinControls.UI.RadCheckBoxElement chkEntitiesWindow;
        private Telerik.WinControls.UI.RadRibbonBarButtonGroup radRibbonBarButtonGroup2;
        private Telerik.WinControls.UI.RadRibbonBarButtonGroup radRibbonBarButtonGroup3;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup3;

    }
}
