using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Osc.Rotch.Engine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Osc.Rotch.Engine.Entities
{
    [DataContract(Name = Consts.Nodes.Tilemap, Namespace = "")]
    public class Tilemap : IEntity
    {
        [DataMember(Name = "Tilesets")]
        private List<Tileset> Tilesets { get; set; }

        [DataMember(Name = "ObjectLayer")]
        public Layer<TilemapAsset> ObjectLayer { get; set; }

        [DataMember(Name = "GroundLayer")]
        public Layer<TilemapAsset> GroundLayer { get; set; }

        [DataMember(Name = "CollisionLayer")]
        public Layer<TileCollision> CollisionLayer { get; set; }

        /// <summary>
        /// Gets the unique ID of entity
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of entity
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of Entity
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets the width of the tilemap in tiles
        /// </summary>
        [DataMember]
        public int Width { get; set; }

        /// <summary>
        /// Gets the height of the tilemap in tiles
        /// </summary>
        [DataMember]
        public int Height { get; set; }

        /// <summary>
        /// Gets the tile width of the tilemap in pixels
        /// </summary>
        [DataMember]
        public int TileWidth { get; set; }

        /// <summary>
        /// Gets the tile height of the tilemap in pixels
        /// </summary>
        [DataMember]
        public int TileHeight { get; set; }

        /// <summary>
        /// Gets or sets the pixel to draw grid
        /// </summary>
        [IgnoreDataMember]
        public Texture2D Pixel { get; set; }

        /// <summary>
        /// Gets or sets whether the grid should be drawn
        /// </summary>
        public bool IsGridVisible { get; set; }

        /// <summary>
        /// Gets or sets to draw the tilemap data 
        /// </summary>
        public bool IsDrawInformationData { get; set; }

        public void Initialize(string name, string description, int tileWidth, int tileHeight, int tilemapWidth, int tilemapHeight)
        {
            if (tileWidth <= 0 || tileHeight <= 0 || tilemapWidth <= 0 || tilemapHeight <= 0)
                throw new ArgumentOutOfRangeException("Tile and Tilemap dimensions should be greater than zero");

            //ID = Guid.NewGuid();

     

            Tilesets = new List<Tileset>();

            CollisionLayer = new Layer<TileCollision>();
            CollisionLayer.Initialize(tilemapWidth, tilemapHeight);

            GroundLayer = new Layer<TilemapAsset>();
            GroundLayer.Initialize(tilemapWidth, tilemapHeight);
            GroundLayer.Name = "Ground Layer";
            GroundLayer.ID = Guid.NewGuid();
            GroundLayer.IsVisble = true;  
            
            ObjectLayer = new Layer<TilemapAsset>();
            ObjectLayer.Initialize(tilemapWidth, tilemapHeight);
            ObjectLayer.Name = "Object Layer";
            ObjectLayer.ID = Guid.NewGuid();
            ObjectLayer.IsVisble = true;

            for (int x = 0; x < tilemapWidth; x++)
            {
                for (int y = 0; y < tilemapHeight; y++)
                {
                    GroundLayer.Columns[x].Rows[y].VisualLayers = new List<Layer<TileVisual>>();
                    ObjectLayer.Columns[x].Rows[y].VisualLayers = new List<Layer<TileVisual>>();                 
                }
            }


            Name = name;
            Description = description;

            TileWidth = tileWidth;
            TileHeight = tileHeight;

            Width = tilemapWidth;
            Height = tilemapHeight;

        }

        public void AddTileset(Tileset tileset)
        {
            if (Tilesets.Any(set => set.TextureName == tileset.TextureName))
                throw new Exception("Tileset with that name already exists");

            Tilesets.Add(tileset);
        }

        public void AddTileset(string name, string description, Texture2D texture)
        {
            if (Tilesets.Any(set => set.Name == name))
                throw new Exception("Tileset with that name already exists");

            Tileset tileset = new Tileset();
            tileset.Initialize(name, texture);
            tileset.Name = name;
            tileset.Description = description;
            Tilesets.Add(tileset);
        }

        

        public void RemoveTileset(Guid id)
        {
            Tileset removeTileset = Tilesets.FirstOrDefault(tileset => tileset.ID == id);

            if (removeTileset == null)
                return;

            //TilemapAssets.ForEach(layer =>
            //{
            //    for (int x = 0; x < Width; x++)
            //    {
            //        for (int y = 0; y < Height; y++)
            //        {

            //            if (layer.Columns[x].Rows[y].TilesetName == removeTileset.Name)
            //            {
            //                layer.Columns[x].Rows[y].TilesetIndex = -1;
            //                layer.Columns[x].Rows[y].TilesetName = string.Empty;
            //            }

            //        }
            //    }
            //});

            Tilesets.Remove(removeTileset);
        }

        public IEnumerable<Tileset> FindTilesets(Func<Tileset, bool> predicate)
        {
            return Tilesets.Where(tileset => predicate(tileset));
        }

        public int FindTilesetIndex(Tileset tileset)
        {
            return Tilesets.IndexOf(tileset);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (spriteBatch == null)
                return;

            if(GroundLayer.IsVisble)
            {
                for (int x = 0; x < GroundLayer.Width; x++)
                {
                    for (int y = 0; y < GroundLayer.Height; y++)
                    {
                        TilemapAsset tile = GroundLayer.Columns[x].Rows[y];

                        for (int tileZ = 0; tileZ < tile.VisualLayers.Count; tileZ++)
                        {
                            for (int tileX = 0; tileX < tile.VisualLayers[tileZ].Width; tileX++)
                            {
                                for (int tileY = 0; tileY < tile.VisualLayers[tileZ].Height; tileY++)
                                {
                                    TileVisual tileAsset = tile.VisualLayers[tileZ].Columns[tileX].Rows[tileY];

                                    if (!string.IsNullOrEmpty(tileAsset.TilesetName))
                                    {
                                        if (tileAsset.TilesetIndex >= 0)
                                        {
                                            Tileset tileset = Tilesets.FirstOrDefault(set => set.TextureName == tileAsset.TilesetName);

                                            if (tileset != null)
                                            {
                                                Vector2 position = MathExtension.IsoCoordinateToPixels(x + tileX, y + tileY, TileWidth, TileHeight);

                                                float zLayer = (1.0f / (Width + Height - 1)) * (x + y);

                                                // TODO: Apply height decimal places to the alignment of Y axis
                                                spriteBatch.Draw(tileset.Texture, new Rectangle((int)position.X, (int)position.Y, TileWidth, TileHeight),
                                                    tileset.GetSourceRectangle(tileAsset.TilesetIndex, TileWidth, TileHeight), Color.White * tile.Alpha, 0.0f, Vector2.Zero, SpriteEffects.None, zLayer);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (ObjectLayer.IsVisble)
            {
                for (int x = 0; x < ObjectLayer.Width; x++)
                {
                    for (int y = 0; y < ObjectLayer.Height; y++)
                    {
                        TilemapAsset tile = ObjectLayer.Columns[x].Rows[y];

                        for (int tileZ = 0; tileZ < tile.VisualLayers.Count; tileZ++)
                        {
                            for (int tileX = 0; tileX < tile.VisualLayers[tileZ].Width; tileX++)
                            {
                                for (int tileY = 0; tileY < tile.VisualLayers[tileZ].Height; tileY++)
                                {
                                    TileVisual tileAsset = tile.VisualLayers[tileZ].Columns[tileX].Rows[tileY];

                                    if (!string.IsNullOrEmpty(tileAsset.TilesetName))
                                    {
                                        if (tileAsset.TilesetIndex >= 0)
                                        {
                                            Tileset tileset = Tilesets.FirstOrDefault(set => set.TextureName == tileAsset.TilesetName);

                                            if (tileset != null)
                                            {
                                                int width = tile.VisualLayers[tileZ].Width;
                                                int height = tile.VisualLayers[tileZ].Height;

                                                Vector2 position = MathExtension.IsoCoordinateToPixels(x + tileX - width + 1, y + tileY - height + 1, TileWidth, TileHeight);

                                                float zLayer = (1.0f / (Width + Height - 1)) * (x + y);

                                                // TODO: Apply height decimal places to the alignment of Y axis
                                                spriteBatch.Draw(tileset.Texture, new Rectangle((int)position.X, (int)position.Y, TileWidth, TileHeight),
                                                    tileset.GetSourceRectangle(tileAsset.TilesetIndex, TileWidth, TileHeight), Color.White * tile.Alpha, 0.0f, Vector2.Zero, SpriteEffects.None, zLayer);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
         
            // TODO: Implement merged layers and if we want the old method of top tiles per cell

            DrawGrid(spriteBatch);
        }

        public void DrawGrid(SpriteBatch spriteBatch)
        {
            if (!IsGridVisible || Pixel == null)
                return;

            for (int x = 1; x < Width + 2; x++)
            {
                for (int y = -1; y < Height; y++)
                {
                    spriteBatch.Draw(Pixel, MathExtension.IsoCoordinateToPixels(x, y, TileWidth, TileHeight, TileWidth / 2, 0), Color.White);
                }
            }
        }

        public void DrawInformationData(SpriteBatch spriteBatch)
        {

        }
    }
}
