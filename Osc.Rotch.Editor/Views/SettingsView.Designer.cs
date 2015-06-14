namespace Osc.Rotch.Editor.Views
{
    partial class SettingsView
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
            this.pageConsole = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.numericMaxConsoleMessages = new Telerik.WinControls.UI.RadSpinEditor();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.pageCamera = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numericLerp = new Telerik.WinControls.UI.RadSpinEditor();
            this.numericZoomIncrement = new Telerik.WinControls.UI.RadSpinEditor();
            this.numericMaxZoom = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.numericMinZoom = new Telerik.WinControls.UI.RadSpinEditor();
            this.pageScene = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.numericSceneHeight = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.numericSceneWidth = new Telerik.WinControls.UI.RadSpinEditor();
            this.pageConsole.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxConsoleMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.pageCamera.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLerp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZoomIncrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinZoom)).BeginInit();
            this.pageScene.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSceneHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSceneWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageConsole
            // 
            this.pageConsole.Controls.Add(this.tableLayoutPanel1);
            this.pageConsole.ItemSize = new System.Drawing.SizeF(56F, 28F);
            this.pageConsole.Location = new System.Drawing.Point(10, 37);
            this.pageConsole.Name = "pageConsole";
            this.pageConsole.Size = new System.Drawing.Size(571, 367);
            this.pageConsole.Text = "Console";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.radLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericMaxConsoleMessages, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 367);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(55, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Max Console Messages:";
            // 
            // numericMaxConsoleMessages
            // 
            this.numericMaxConsoleMessages.Location = new System.Drawing.Point(145, 3);
            this.numericMaxConsoleMessages.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericMaxConsoleMessages.Minimum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericMaxConsoleMessages.Name = "numericMaxConsoleMessages";
            this.numericMaxConsoleMessages.Size = new System.Drawing.Size(127, 20);
            this.numericMaxConsoleMessages.TabIndex = 1;
            this.numericMaxConsoleMessages.TabStop = false;
            this.numericMaxConsoleMessages.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.pageConsole);
            this.radPageView1.Controls.Add(this.pageCamera);
            this.radPageView1.Controls.Add(this.pageScene);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.pageConsole;
            this.radPageView1.Size = new System.Drawing.Size(592, 415);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
            // 
            // pageCamera
            // 
            this.pageCamera.Controls.Add(this.tableLayoutPanel2);
            this.pageCamera.ItemSize = new System.Drawing.SizeF(54F, 28F);
            this.pageCamera.Location = new System.Drawing.Point(10, 37);
            this.pageCamera.Name = "pageCamera";
            this.pageCamera.Size = new System.Drawing.Size(573, 365);
            this.pageCamera.Text = "Camera";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.17801F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.82199F));
            this.tableLayoutPanel2.Controls.Add(this.numericLerp, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.numericZoomIncrement, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.numericMaxZoom, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.radLabel4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.radLabel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.radLabel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.radLabel5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.numericMinZoom, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(573, 365);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // numericLerp
            // 
            this.numericLerp.DecimalPlaces = 2;
            this.numericLerp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericLerp.Location = new System.Drawing.Point(153, 81);
            this.numericLerp.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLerp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericLerp.Name = "numericLerp";
            this.numericLerp.Size = new System.Drawing.Size(113, 20);
            this.numericLerp.TabIndex = 7;
            this.numericLerp.TabStop = false;
            this.numericLerp.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numericZoomIncrement
            // 
            this.numericZoomIncrement.DecimalPlaces = 2;
            this.numericZoomIncrement.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericZoomIncrement.Location = new System.Drawing.Point(153, 55);
            this.numericZoomIncrement.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            this.numericZoomIncrement.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericZoomIncrement.Name = "numericZoomIncrement";
            this.numericZoomIncrement.Size = new System.Drawing.Size(113, 20);
            this.numericZoomIncrement.TabIndex = 6;
            this.numericZoomIncrement.TabStop = false;
            this.numericZoomIncrement.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // numericMaxZoom
            // 
            this.numericMaxZoom.DecimalPlaces = 2;
            this.numericMaxZoom.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericMaxZoom.Location = new System.Drawing.Point(153, 29);
            this.numericMaxZoom.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericMaxZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMaxZoom.Name = "numericMaxZoom";
            this.numericMaxZoom.Size = new System.Drawing.Size(113, 20);
            this.numericMaxZoom.TabIndex = 5;
            this.numericMaxZoom.TabStop = false;
            this.numericMaxZoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(3, 55);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(92, 18);
            this.radLabel4.TabIndex = 2;
            this.radLabel4.Text = "Zoom Increment:";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(3, 29);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(91, 18);
            this.radLabel3.TabIndex = 1;
            this.radLabel3.Text = "Maximum Zoom:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(89, 18);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Minimum Zoom:";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(3, 81);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(106, 18);
            this.radLabel5.TabIndex = 3;
            this.radLabel5.Text = "Linear Interpolation:";
            // 
            // numericMinZoom
            // 
            this.numericMinZoom.DecimalPlaces = 2;
            this.numericMinZoom.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericMinZoom.Location = new System.Drawing.Point(153, 3);
            this.numericMinZoom.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMinZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericMinZoom.Name = "numericMinZoom";
            this.numericMinZoom.Size = new System.Drawing.Size(113, 20);
            this.numericMinZoom.TabIndex = 4;
            this.numericMinZoom.TabStop = false;
            this.numericMinZoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // pageScene
            // 
            this.pageScene.Controls.Add(this.tableLayoutPanel3);
            this.pageScene.ItemSize = new System.Drawing.SizeF(46F, 28F);
            this.pageScene.Location = new System.Drawing.Point(10, 37);
            this.pageScene.Name = "pageScene";
            this.pageScene.Size = new System.Drawing.Size(573, 365);
            this.pageScene.Text = "Scene";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.82897F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.17103F));
            this.tableLayoutPanel3.Controls.Add(this.numericSceneHeight, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.radLabel7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.radLabel6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.numericSceneWidth, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(573, 365);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // numericSceneHeight
            // 
            this.numericSceneHeight.Location = new System.Drawing.Point(150, 29);
            this.numericSceneHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSceneHeight.Name = "numericSceneHeight";
            this.numericSceneHeight.Size = new System.Drawing.Size(112, 20);
            this.numericSceneHeight.TabIndex = 5;
            this.numericSceneHeight.TabStop = false;
            this.numericSceneHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(3, 29);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(82, 18);
            this.radLabel7.TabIndex = 1;
            this.radLabel7.Text = "Default Height:";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(3, 3);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(55, 18);
            this.radLabel6.TabIndex = 0;
            this.radLabel6.Text = "Default Width:";
            // 
            // numericSceneWidth
            // 
            this.numericSceneWidth.Location = new System.Drawing.Point(150, 3);
            this.numericSceneWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSceneWidth.Name = "numericSceneWidth";
            this.numericSceneWidth.Size = new System.Drawing.Size(112, 20);
            this.numericSceneWidth.TabIndex = 4;
            this.numericSceneWidth.TabStop = false;
            this.numericSceneWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 415);
            this.Controls.Add(this.radPageView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ThemeName = "ControlDefault";
            this.pageConsole.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxConsoleMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.pageCamera.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLerp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZoomIncrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinZoom)).EndInit();
            this.pageScene.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSceneHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSceneWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageViewPage pageConsole;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadSpinEditor numericMaxConsoleMessages;
        private Telerik.WinControls.UI.RadPageViewPage pageCamera;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadSpinEditor numericZoomIncrement;
        private Telerik.WinControls.UI.RadSpinEditor numericMaxZoom;
        private Telerik.WinControls.UI.RadSpinEditor numericMinZoom;
        private Telerik.WinControls.UI.RadSpinEditor numericLerp;
        private Telerik.WinControls.UI.RadSpinEditor numericSceneWidth;
        private Telerik.WinControls.UI.RadPageViewPage pageScene;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadSpinEditor numericSceneHeight;

    }
}
