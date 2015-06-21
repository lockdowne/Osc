using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Engine.Patterns
{
    public class TilePattern
    {
        public Layer<TileVisual> Pattern { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 Origin { get; set; }

        public List<Tileset> Tilesets { get; set; }

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }

        public Color Tint { get; set; }

        public float Alpha { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Pattern == null)
                return;

            for(int x = 0; x < Pattern.Width; x++)
            {
                for(int y = 0; y < Pattern.Height; y++)
                {
                    TileVisual tile = Pattern.Columns[x].Rows[y];

                    if(!string.IsNullOrEmpty(tile.TilesetName))
                    {
                        if(tile.TilesetIndex >= 0)
                        {
                            Tileset tileset = Tilesets.FirstOrDefault(set => set.TextureName == tile.TilesetName);

                            Vector2 position = MathExtension.IsoCoordinateToPixels(x, y, TileWidth, TileHeight);

                            spriteBatch.Draw(tileset.Texture, new Vector2(position.X + Position.X - Origin.X, position.Y + Position.Y - Origin.Y),
                                tileset.GetSourceRectangle(tile.TilesetIndex, TileWidth, TileHeight), Tint * Alpha);
                        }
                    }
                }
            }
        }
    }
}
