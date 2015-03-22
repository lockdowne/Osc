using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using oEditor.Controls;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using oEngine.Entities;

namespace oEditor.Views
{
    public class TilesetView : RadPageViewPage
    {
        private TilesetRender tilesetRender = new TilesetRender();

        public GraphicsDevice GraphicsDevice
        {
            get { return tilesetRender.GraphicsDevice; }
        }

        public Tileset Tileset
        {
            get { return tilesetRender.Tileset; }
            set { tilesetRender.Tileset = value; }
        }

        public event MouseEventHandler TilesetMouseDown;
        public event MouseEventHandler TilesetMouseMove;
        public event MouseEventHandler TilesetMouseUp;
        public event MouseEventHandler TilesetMouseWheel;

        public TilesetView()
        {
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            tilesetRender.Dock = System.Windows.Forms.DockStyle.Fill;

            tilesetRender.RenderMouseDown += (sender, e) =>
            {
                if (TilesetMouseDown != null)
                    TilesetMouseDown(sender, e);
            };

            tilesetRender.RenderMouseMove += (sender, e) =>
            {
                if (TilesetMouseMove != null)
                    TilesetMouseMove(sender, e);
            };

            tilesetRender.RenderMouseUp += (sender, e) =>
            {
                if (TilesetMouseUp != null)
                    TilesetMouseUp(sender, e);
            };

            tilesetRender.RenderMouseWheel += (sender, e) =>
            {
                if (TilesetMouseWheel != null)
                    TilesetMouseWheel(sender, e);
            };
        }

        
    }
}
