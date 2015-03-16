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
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.radCommandBar = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarDropDownButton1 = new Telerik.WinControls.UI.CommandBarDropDownButton();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.toolWindow2 = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.toolWindow1 = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.documentWindow2 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.commandBarDropDownButton2 = new Telerik.WinControls.UI.CommandBarDropDownButton();
            this.commandBarDropDownButton3 = new Telerik.WinControls.UI.CommandBarDropDownButton();
            this.btnConsoleWindow = new Telerik.WinControls.UI.RadMenuItem();
            this.btnProjectWindow = new Telerik.WinControls.UI.RadMenuItem();
            this.btnEntitiesWindow = new Telerik.WinControls.UI.RadMenuItem();
            this.btnToolboxWindow = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).BeginInit();
            this.radDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar
            // 
            this.radCommandBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar.Name = "radCommandBar";
            this.radCommandBar.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1,
            this.commandBarRowElement2});
            this.radCommandBar.Size = new System.Drawing.Size(792, 60);
            this.radCommandBar.TabIndex = 0;
            this.radCommandBar.Text = "radCommandBar1";
            this.radCommandBar.ThemeName = "VisualStudio2012Dark";
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
            this.commandBarDropDownButton1,
            this.commandBarDropDownButton2,
            this.commandBarDropDownButton3});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // commandBarDropDownButton1
            // 
            this.commandBarDropDownButton1.AccessibleDescription = "FILE";
            this.commandBarDropDownButton1.AccessibleName = "FILE";
            this.commandBarDropDownButton1.DisplayName = "commandBarDropDownButton1";
            this.commandBarDropDownButton1.DrawText = true;
            this.commandBarDropDownButton1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.commandBarDropDownButton1.Image = null;
            this.commandBarDropDownButton1.Name = "commandBarDropDownButton1";
            this.commandBarDropDownButton1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.commandBarDropDownButton1.Text = "FILE";
            ((Telerik.WinControls.UI.RadCommandBarArrowButton)(this.commandBarDropDownButton1.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            // 
            // toolWindow2
            // 
            this.toolWindow2.Caption = null;
            this.toolWindow2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolWindow2.Location = new System.Drawing.Point(4, 24);
            this.toolWindow2.Name = "toolWindow2";
            this.toolWindow2.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.toolWindow2.Size = new System.Drawing.Size(192, 479);
            this.toolWindow2.Text = "toolWindow2";
            // 
            // toolWindow1
            // 
            this.toolWindow1.Caption = null;
            this.toolWindow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolWindow1.Location = new System.Drawing.Point(4, 24);
            this.toolWindow1.Name = "toolWindow1";
            this.toolWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.toolWindow1.Size = new System.Drawing.Size(192, 479);
            this.toolWindow1.Text = "toolWindow1";
            // 
            // documentContainer1
            // 
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
            this.documentTabStrip1.Controls.Add(this.documentWindow2);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(388, 507);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.ThemeName = "VisualStudio2012Dark";
            // 
            // documentWindow2
            // 
            this.documentWindow2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow2.Location = new System.Drawing.Point(4, 4);
            this.documentWindow2.Name = "documentWindow2";
            this.documentWindow2.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow2.Size = new System.Drawing.Size(380, 499);
            this.documentWindow2.Text = "documentWindow2";
            // 
            // radDock
            // 
            this.radDock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radDock.Controls.Add(this.documentContainer1);
            this.radDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock.IsCleanUpTarget = true;
            this.radDock.Location = new System.Drawing.Point(0, 60);
            this.radDock.MainDocumentContainer = this.documentContainer1;
            this.radDock.Name = "radDock";
            this.radDock.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.radDock.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock.Size = new System.Drawing.Size(792, 507);
            this.radDock.SplitterWidth = 2;
            this.radDock.TabIndex = 1;
            this.radDock.TabStop = false;
            this.radDock.Text = "radDock1";
            this.radDock.ThemeName = "VisualStudio2012Dark";
            // 
            // commandBarDropDownButton2
            // 
            this.commandBarDropDownButton2.AccessibleDescription = "EDIT";
            this.commandBarDropDownButton2.AccessibleName = "EDIT";
            this.commandBarDropDownButton2.DisplayName = "commandBarDropDownButton2";
            this.commandBarDropDownButton2.DrawText = true;
            this.commandBarDropDownButton2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.commandBarDropDownButton2.Image = null;
            this.commandBarDropDownButton2.Name = "commandBarDropDownButton2";
            this.commandBarDropDownButton2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.commandBarDropDownButton2.Text = "EDIT";
            ((Telerik.WinControls.UI.RadCommandBarArrowButton)(this.commandBarDropDownButton2.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // commandBarDropDownButton3
            // 
            this.commandBarDropDownButton3.AccessibleDescription = "VIEW";
            this.commandBarDropDownButton3.AccessibleName = "VIEW";
            this.commandBarDropDownButton3.DisplayName = "commandBarDropDownButton3";
            this.commandBarDropDownButton3.DrawText = true;
            this.commandBarDropDownButton3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.commandBarDropDownButton3.Image = null;
            this.commandBarDropDownButton3.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnConsoleWindow,
            this.btnProjectWindow,
            this.btnEntitiesWindow,
            this.btnToolboxWindow});
            this.commandBarDropDownButton3.Name = "commandBarDropDownButton3";
            this.commandBarDropDownButton3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.commandBarDropDownButton3.Text = "VIEW";
            ((Telerik.WinControls.UI.RadCommandBarArrowButton)(this.commandBarDropDownButton3.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // btnConsoleWindow
            // 
            this.btnConsoleWindow.AccessibleDescription = "Console Window";
            this.btnConsoleWindow.AccessibleName = "Console Window";
            this.btnConsoleWindow.CheckOnClick = true;
            this.btnConsoleWindow.IsChecked = true;
            this.btnConsoleWindow.Name = "btnConsoleWindow";
            this.btnConsoleWindow.Text = "Console Window";
            this.btnConsoleWindow.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // btnProjectWindow
            // 
            this.btnProjectWindow.AccessibleDescription = "Project Window";
            this.btnProjectWindow.AccessibleName = "Project Window";
            this.btnProjectWindow.CheckOnClick = true;
            this.btnProjectWindow.IsChecked = true;
            this.btnProjectWindow.Name = "btnProjectWindow";
            this.btnProjectWindow.Text = "Project Window";
            this.btnProjectWindow.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // btnEntitiesWindow
            // 
            this.btnEntitiesWindow.AccessibleDescription = "Entities Window";
            this.btnEntitiesWindow.AccessibleName = "Entities Window";
            this.btnEntitiesWindow.CheckOnClick = true;
            this.btnEntitiesWindow.IsChecked = true;
            this.btnEntitiesWindow.Name = "btnEntitiesWindow";
            this.btnEntitiesWindow.Text = "Entities Window";
            this.btnEntitiesWindow.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // btnToolboxWindow
            // 
            this.btnToolboxWindow.AccessibleDescription = "Toolbox Window";
            this.btnToolboxWindow.AccessibleName = "Toolbox Window";
            this.btnToolboxWindow.CheckOnClick = true;
            this.btnToolboxWindow.IsChecked = true;
            this.btnToolboxWindow.Name = "btnToolboxWindow";
            this.btnToolboxWindow.Text = "Toolbox Window";
            this.btnToolboxWindow.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 567);
            this.Controls.Add(this.radDock);
            this.Controls.Add(this.radCommandBar);
            this.Name = "MainView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "oEditor";
            this.ThemeName = "VisualStudio2012Dark";
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).EndInit();
            this.radDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.Docking.ToolWindow toolWindow2;
        private Telerik.WinControls.UI.Docking.ToolWindow toolWindow1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow2;
        private Telerik.WinControls.UI.Docking.RadDock radDock;
        private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton1;
        private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton2;
        private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton3;
        private Telerik.WinControls.UI.RadMenuItem btnConsoleWindow;
        private Telerik.WinControls.UI.RadMenuItem btnProjectWindow;
        private Telerik.WinControls.UI.RadMenuItem btnEntitiesWindow;
        private Telerik.WinControls.UI.RadMenuItem btnToolboxWindow;
    }
}