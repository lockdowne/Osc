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

namespace oEditor.Views
{
    public class TilemapDocumentView : RadForm, ITilemapDocumentView
    {

        private TilemapRender tilemapRender;

        public Guid ID { get; set; }

        public Tilemap Tilemap
        {
            get { return tilemapRender.Tilemap; }
            set { tilemapRender.Tilemap = value; }
        }

        public TilemapDocumentView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.tilemapRender = new oEditor.Controls.TilemapRender();


            // 
            // tilemapRender
            // 
            this.tilemapRender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilemapRender.Location = new System.Drawing.Point(0, 0);
            this.tilemapRender.Name = "tilemapRender";
            this.tilemapRender.Size = new System.Drawing.Size(200, 200);
            this.tilemapRender.TabIndex = 0;
            this.tilemapRender.Tilemap = null;
            this.tilemapRender.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tilemapRender_MouseDown);
            this.tilemapRender.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tilemapRender_MouseMove);
            this.tilemapRender.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tilemapRender_MouseUp);
            this.tilemapRender.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.tilemapRender_MouseWheel);
            // 
            // TilemapDocumentView
            // 
            this.Controls.Add(tilemapRender);
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
    }
}
