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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.cmdBar = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.radDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.windowWorldMap = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.toolTabStrip3 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.windowToolbox = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.radSplitContainer2 = new Telerik.WinControls.UI.RadSplitContainer();
            this.documentContainer = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.toolTabStrip2 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.windowConsole = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.listboxConsole = new Telerik.WinControls.UI.RadListControl();
            this.toolTabStrip1 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.windowExplorer = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.windowProperties = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.toolTabStrip5 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.radColorDialog1 = new Telerik.WinControls.RadColorDialog();
            this.commandBarDropDownButton1 = new Telerik.WinControls.UI.CommandBarDropDownButton();
            this.menuItemNewScene = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemOpenScene = new Telerik.WinControls.UI.RadMenuItem();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmdBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).BeginInit();
            this.radDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip3)).BeginInit();
            this.toolTabStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).BeginInit();
            this.radSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer)).BeginInit();
            this.documentContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip2)).BeginInit();
            this.toolTabStrip2.SuspendLayout();
            this.windowConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listboxConsole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).BeginInit();
            this.toolTabStrip1.SuspendLayout();
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
            this.cmdBar.Size = new System.Drawing.Size(1184, 85);
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
            this.commandBarDropDownButton1});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // radDock
            // 
            this.radDock.ActiveWindow = this.windowConsole;
            this.radDock.Controls.Add(this.toolTabStrip3);
            this.radDock.Controls.Add(this.radSplitContainer2);
            this.radDock.Controls.Add(this.toolTabStrip1);
            this.radDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock.IsCleanUpTarget = true;
            this.radDock.Location = new System.Drawing.Point(0, 85);
            this.radDock.MainDocumentContainer = this.documentContainer;
            this.radDock.Name = "radDock";
            this.radDock.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.radDock.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock.Size = new System.Drawing.Size(1184, 645);
            this.radDock.SplitterWidth = 2;
            this.radDock.TabIndex = 1;
            this.radDock.TabStop = false;
            this.radDock.Text = "radDock1";
            this.radDock.ThemeName = "VisualStudio2012Dark";
            // 
            // windowWorldMap
            // 
            this.windowWorldMap.CloseAction = Telerik.WinControls.UI.Docking.DockWindowCloseAction.Hide;
            this.windowWorldMap.Location = new System.Drawing.Point(4, 29);
            this.windowWorldMap.Name = "windowWorldMap";
            this.windowWorldMap.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.windowWorldMap.Size = new System.Drawing.Size(772, 410);
            this.windowWorldMap.Text = "World Map";
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
            this.toolTabStrip3.Size = new System.Drawing.Size(200, 645);
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
            this.windowToolbox.Size = new System.Drawing.Size(192, 617);
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
            this.radSplitContainer2.Size = new System.Drawing.Size(780, 645);
            this.radSplitContainer2.SplitterWidth = 2;
            this.radSplitContainer2.TabIndex = 0;
            this.radSplitContainer2.TabStop = false;
            this.radSplitContainer2.ThemeName = "VisualStudio2012Dark";
            // 
            // documentContainer
            // 
            this.documentContainer.Controls.Add(this.documentTabStrip1);
            this.documentContainer.Name = "documentContainer";
            // 
            // 
            // 
            this.documentContainer.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer.SplitterWidth = 2;
            this.documentContainer.ThemeName = "VisualStudio2012Dark";
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.Controls.Add(this.windowWorldMap);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(780, 443);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.ThemeName = "VisualStudio2012Dark";
            // 
            // toolTabStrip2
            // 
            this.toolTabStrip2.CanUpdateChildIndex = true;
            this.toolTabStrip2.Controls.Add(this.windowConsole);
            this.toolTabStrip2.Location = new System.Drawing.Point(0, 445);
            this.toolTabStrip2.Name = "toolTabStrip2";
            // 
            // 
            // 
            this.toolTabStrip2.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.toolTabStrip2.SelectedIndex = 0;
            this.toolTabStrip2.Size = new System.Drawing.Size(780, 200);
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
            this.windowConsole.Size = new System.Drawing.Size(772, 172);
            this.windowConsole.Text = "Console";
            // 
            // listboxConsole
            // 
            this.listboxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxConsole.Location = new System.Drawing.Point(0, 0);
            this.listboxConsole.Name = "listboxConsole";
            this.listboxConsole.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listboxConsole.Size = new System.Drawing.Size(772, 172);
            this.listboxConsole.TabIndex = 0;
            this.listboxConsole.Text = "radListControl1";
            this.listboxConsole.ThemeName = "VisualStudio2012Dark";
            // 
            // toolTabStrip1
            // 
            this.toolTabStrip1.CanUpdateChildIndex = true;
            this.toolTabStrip1.Controls.Add(this.windowExplorer);
            this.toolTabStrip1.Controls.Add(this.windowProperties);
            this.toolTabStrip1.Location = new System.Drawing.Point(984, 0);
            this.toolTabStrip1.Name = "toolTabStrip1";
            // 
            // 
            // 
            this.toolTabStrip1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.toolTabStrip1.SelectedIndex = 0;
            this.toolTabStrip1.Size = new System.Drawing.Size(200, 645);
            this.toolTabStrip1.TabIndex = 5;
            this.toolTabStrip1.TabStop = false;
            this.toolTabStrip1.ThemeName = "VisualStudio2012Dark";
            // 
            // windowExplorer
            // 
            this.windowExplorer.Caption = null;
            this.windowExplorer.CloseAction = Telerik.WinControls.UI.Docking.DockWindowCloseAction.CloseAndDispose;
            this.windowExplorer.Location = new System.Drawing.Point(4, 24);
            this.windowExplorer.Name = "windowExplorer";
            this.windowExplorer.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.windowExplorer.Size = new System.Drawing.Size(192, 592);
            this.windowExplorer.Text = "Project Explorer";
            // 
            // windowProperties
            // 
            this.windowProperties.Caption = null;
            this.windowProperties.Location = new System.Drawing.Point(4, 24);
            this.windowProperties.Name = "windowProperties";
            this.windowProperties.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.windowProperties.Size = new System.Drawing.Size(192, 649);
            this.windowProperties.Text = "Properties";
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
            // radColorDialog1
            // 
            this.radColorDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("radColorDialog1.Icon")));
            this.radColorDialog1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radColorDialog1.SelectedColor = System.Drawing.Color.Red;
            this.radColorDialog1.SelectedHslColor = Telerik.WinControls.HslColor.FromAhsl(0D, 1D, 1D);
            // 
            // commandBarDropDownButton1
            // 
            this.commandBarDropDownButton1.AccessibleDescription = "File";
            this.commandBarDropDownButton1.AccessibleName = "File";
            this.commandBarDropDownButton1.DisplayName = "commandBarDropDownButton1";
            this.commandBarDropDownButton1.DrawText = true;
            this.commandBarDropDownButton1.Image = null;
            this.commandBarDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuItemNewScene,
            this.menuItemOpenScene});
            this.commandBarDropDownButton1.Name = "commandBarDropDownButton1";
            this.commandBarDropDownButton1.Text = "File";
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
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 730);
            this.Controls.Add(this.radDock);
            this.Controls.Add(this.cmdBar);
            this.Name = "MainView";
            this.Text = "MainView";
            ((System.ComponentModel.ISupportInitialize)(this.cmdBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).EndInit();
            this.radDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip3)).EndInit();
            this.toolTabStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).EndInit();
            this.radSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer)).EndInit();
            this.documentContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip2)).EndInit();
            this.toolTabStrip2.ResumeLayout(false);
            this.windowConsole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listboxConsole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).EndInit();
            this.toolTabStrip1.ResumeLayout(false);
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
        private Telerik.WinControls.UI.Docking.DocumentWindow windowWorldMap;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer2;
        private Telerik.WinControls.UI.Docking.ToolWindow windowToolbox;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip2;
        private Telerik.WinControls.UI.Docking.ToolWindow windowConsole;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip3;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip1;
        private Telerik.WinControls.UI.Docking.ToolWindow windowExplorer;
        private Telerik.WinControls.UI.Docking.ToolWindow windowProperties;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip5;
        private Telerik.WinControls.RadColorDialog radColorDialog1;
        private Telerik.WinControls.UI.RadListControl listboxConsole;
        private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton1;
        private Telerik.WinControls.UI.RadMenuItem menuItemNewScene;
        private Telerik.WinControls.UI.RadMenuItem menuItemOpenScene;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
    }
}