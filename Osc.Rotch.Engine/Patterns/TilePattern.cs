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
        public Guid ID { get; set; }

        public List<Layer<TileVisual>> Pattern { get; set; }

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

            for (int z = 0; z < Pattern.Count; z++)
            {
                for (int x = 0; x < Pattern[z].Width; x++)
                {
                    for (int y = 0; y < Pattern[z].Height; y++)
                    {
                        TileVisual tile = Pattern[z].Columns[x].Rows[y];

                        if (!string.IsNullOrEmpty(tile.TilesetName))
                        {
                            if (tile.TilesetIndex >= 0)
                            {
                                Tileset tileset = Tilesets.FirstOrDefault(set => set.TextureName == tile.TilesetName);

                                if (tileset != null)
                                {
                                    if (tileset.Texture != null)
                                    {
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
        }

        public IEnumerable<string> FindAllTilesetNames()
        {
            List<string> tilesetNames = new List<string>();

            for (int z = 0; z < Pattern.Count; z++)
            {
                for (int x = 0; x < Pattern[z].Width; x++)
                {
                    for (int y = 0; y < Pattern[z].Height; y++)
                    {
                        TileVisual tile = Pattern[z].Columns[x].Rows[y];

                        if (!string.IsNullOrEmpty(tile.TilesetName))
                        {
                            if (!tilesetNames.Contains(tile.TilesetName))
                                tilesetNames.Add(tile.TilesetName);
                        }
                    }
                }
            }

            return tilesetNames;
        }
    }
}
