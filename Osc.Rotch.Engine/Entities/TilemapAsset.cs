using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Engine.Entities
{
    public class TilemapAsset : IEntity
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public Layer<TileVisual> VisualLayer { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
