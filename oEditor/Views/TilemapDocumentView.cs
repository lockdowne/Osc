using oEditor.Aggregators;
using oEditor.Controls;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public class TilemapDocumentView : DocumentWindow, ITilemapDocumentView
    {
        private readonly IEventAggregator eventAggregator;

        private TilemapRender tilemapRender;

        public Guid ID { get; set; }

        public Tilemap Tilemap
        {
            get { return tilemapRender.Tilemap; }
            set { tilemapRender.Tilemap = value; }
        }

        public TilemapDocumentView(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.tilemapRender = new oEditor.Controls.TilemapRender();
            this.SuspendLayout();
            // 
            // tilemapRender
            // 
            this.tilemapRender.Location = new System.Drawing.Point(0, 0);
            this.tilemapRender.Name = "tilemapRender";
            this.tilemapRender.Size = new System.Drawing.Size(150, 150);
            this.tilemapRender.TabIndex = 0;
            this.tilemapRender.Tilemap = null;
            this.tilemapRender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilemapRender.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tilemapRender_MouseDown);
            this.tilemapRender.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tilemapRender_MouseMove);
            this.tilemapRender.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tilemapRender_MouseUp);
            this.tilemapRender.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.tilemapRender_MouseWheel);
            // 
            // TilemapDocumentView
            // 
            this.Controls.Add(this.tilemapRender);
            this.ResumeLayout(false);

        }

        private void tilemapRender_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            eventAggregator.Publish(new OnTilemapMouseWheel() { Args = e, Tilemap = tilemapRender.Tilemap });
        }

        private void tilemapRender_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            eventAggregator.Publish(new OnTilemapMouseDown() { Args = e, Tilemap = tilemapRender.Tilemap });
        }

        private void tilemapRender_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            eventAggregator.Publish(new OnTilemapMouseMove() { Args = e, Tilemap = tilemapRender.Tilemap });
        }

        private void tilemapRender_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            eventAggregator.Publish(new OnTilemapMouseUp() { Args = e, Tilemap = tilemapRender.Tilemap });
        }
    }
}
