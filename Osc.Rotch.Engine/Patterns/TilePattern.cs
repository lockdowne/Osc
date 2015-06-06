using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Osc.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Engine.Patterns
{
    public class TilePattern
    {
        public int[,] Pattern { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 Origin { get; set; }

        public Tileset Tileset { get; set; }

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }

        public Color Tint { get; set; }

        public float Alpha { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Pattern == null)
                return;

            if (Tileset == null)
                return;

            if (Tileset.Texture == null)
                return;

            for(int x = 0; x < Pattern.GetLength(0); x++)
            {
                for(int y = 0; y < Pattern.GetLength(1); y++)
                {
                    int indexValue = Pattern[x, y];

                    if(indexValue >= 0)
                    {
                        spriteBatch.Draw(Tileset.Texture, new Vector2(((x * TileWidth) + Position.X) - Origin.X, ((y * TileHeight) + Position.Y) - Origin.Y),
                            Tileset.GetSourceRectangle(indexValue, TileWidth, TileHeight), Tint * Alpha);
                    }
                }
            }
        }
    }
}
