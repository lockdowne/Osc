namespace oEditor.Views
{
    partial class EntitiesView
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
            this.radTreeView = new Telerik.WinControls.UI.RadTreeView();
            this.radContextMenu = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.btnAddEntity = new Telerik.WinControls.UI.RadMenuItem();
            this.btnDeleteEntity = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.btnEditEntity = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem2 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.btnExpand = new Telerik.WinControls.UI.RadMenuItem();
            this.btnCollapse = new Telerik.WinControls.UI.RadMenuItem();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.Tag = oEngine.Common.Enums.EditorWindows.Entities;
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView)).BeginInit();
            this.SuspendLayout();
            // 
            // radTreeView
            // 
            this.radTreeView.BackColor = System.Drawing.SystemColors.Control;
            this.radTreeView.Cursor = System.Windows.Forms.Cursors.Default;
            this.radTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTreeView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radTreeView.Location = new System.Drawing.Point(0, 0);
            this.radTreeView.Name = "radTreeView";
            this.radTreeView.RadContextMenu = this.radContextMenu;
            this.radTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radTreeView.Size = new System.Drawing.Size(150, 250);
            this.radTreeView.SpacingBetweenNodes = -1;
            this.radTreeView.TabIndex = 0;
            this.radTreeView.Text = "radTreeView1";
            this.radTreeView.ThemeName = "VisualStudio2012Dark";
            // 
            // radContextMenu
            // 
            this.radContextMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnAddEntity,
            this.btnDeleteEntity,
            this.radMenuSeparatorItem1,
            this.btnEditEntity,
            this.radMenuSeparatorItem2,
            this.btnExpand,
            this.btnCollapse});
            // 
            // btnAddEntity
            // 
            this.btnAddEntity.AccessibleDescription = "Add Entity";
            this.btnAddEntity.AccessibleName = "Add Entity";
            this.btnAddEntity.Name = "btnAddEntity";
            this.btnAddEntity.Text = "Add Entity";
            // 
            // btnDeleteEntity
            // 
            this.btnDeleteEntity.AccessibleDescription = "btnDeleteEntity";
            this.btnDeleteEntity.AccessibleName = "Delete Entity";
            this.btnDeleteEntity.Name = "btnDeleteEntity";
            this.btnDeleteEntity.Text = "Delete Entity";
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.AccessibleDescription = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.AccessibleName = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            // 
            // btnEditEntity
            // 
            this.btnEditEntity.AccessibleDescription = "Edit Entity";
            this.btnEditEntity.AccessibleName = "Edit Entity";
            this.btnEditEntity.Name = "btnEditEntity";
            this.btnEditEntity.Text = "Edit Entity";
            // 
            // radMenuSeparatorItem2
            // 
            this.radMenuSeparatorItem2.AccessibleDescription = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.AccessibleName = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Name = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Text = "radMenuSeparatorItem2";
            // 
            // btnExpand
            // 
            this.btnExpand.AccessibleDescription = "Expand";
            this.btnExpand.AccessibleName = "Expand";
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Text = "Expand";
            // 
            // btnCollapse
            // 
            this.btnCollapse.AccessibleDescription = "Collapse";
            this.btnCollapse.AccessibleName = "Collapse";
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Text = "Collapse";
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView radTreeView;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.RadContextMenu radContextMenu;
        private Telerik.WinControls.UI.RadMenuItem btnAddEntity;
        private Telerik.WinControls.UI.RadMenuItem btnDeleteEntity;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem btnEditEntity;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem2;
        private Telerik.WinControls.UI.RadMenuItem btnExpand;
        private Telerik.WinControls.UI.RadMenuItem btnCollapse;
    }
}