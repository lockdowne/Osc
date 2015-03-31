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
            this.radCommandBar = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.radStatusStrip = new Telerik.WinControls.UI.RadStatusStrip();
            this.radDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).BeginInit();
            this.radDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
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
            this.radDock.Location = new System.Drawing.Point(0, 60);
            this.radDock.MainDocumentContainer = this.documentContainer1;
            this.radDock.Name = "radDock";
            // 
            // 
            // 
            this.radDock.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock.Size = new System.Drawing.Size(792, 484);
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
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 570);
            this.Controls.Add(this.radDock);
            this.Controls.Add(this.radStatusStrip);
            this.Controls.Add(this.radCommandBar);
            this.Name = "MainView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "MainView";
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock)).EndInit();
            this.radDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCommandBar radCommandBar;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip;
        private Telerik.WinControls.UI.Docking.RadDock radDock;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;

    }
}
