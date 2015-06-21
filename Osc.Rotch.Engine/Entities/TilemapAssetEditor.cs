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
    public class TilemapAssetEditor : IEntity
    {
        public List<Tileset> Tilesets { get; set; }

        public TilemapAsset Asset { get; set; }

        /// <summary>
        /// Gets the unique ID of entity
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of entity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of Entity
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the width of the tilemap in tiles
        /// </summary>
        [DataMember]
        public int Width { get; set; }

        /// <summary>
        /// Gets the height of the tilemap in tiles
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets the tile width of the tilemap in pixels
        /// </summary>
        public int TileWidth { get; set; }

        /// <summary>
        /// Gets the tile height of the tilemap in pixels
        /// </summary>
        public int TileHeight { get; set; }

        /// <summary>
        /// Gets or sets the pixel to draw grid
        /// </summary>
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

            Asset = new TilemapAsset() { Alpha = 1.0f, };

            Tilesets = new List<Tileset>();

            Name = name;
            Description = description;

            TileWidth = tileWidth;
            TileHeight = tileHeight;

            Width = tilemapWidth;
            Height = tilemapHeight;

        }

        public void AddTilemapLayer(Guid id, string name, string description)
        {
            Layer<TileVisual> layer = new Layer<TileVisual>();
            layer.Initialize(Width, Height);
            layer.Name = name;
            layer.Description = description;
            layer.IsVisble = true;
            layer.Alpha = 1.0f;
            layer.ID = id;

            Asset.VisualLayers.Add(layer);
        }

        public void RemoveTilemapLayer(Guid id)
        {
            Asset.VisualLayers.RemoveAll(layer => layer.ID == id);
        }

        public IEnumerable<Layer<TileVisual>> FindTilemapLayers(Func<Layer<TileVisual>, bool> predicate)
        {
            return Asset.VisualLayers.Where(layer => predicate(layer));
        }

        public int FindLayerIndex(Layer<TileVisual> layer)
        {
            return Asset.VisualLayers.IndexOf(layer);
        }

        public Layer<TileVisual> FindLayerByIndex(int index)
        {
            if (index < 0 || index >= Asset.VisualLayers.Count)
                return null;

            return Asset.VisualLayers[index];
        }

        public void MoveLayerUp(int index)
        {
            if (index < 0 || index >= Asset.VisualLayers.Count || (index - 1) < 0)
                return;

            Asset.VisualLayers.Swap(index, index - 1);
        }

        public void MoveLayerDown(int index)
        {
            if (index < 0 || index >= Asset.VisualLayers.Count || (index + 1) >= Asset.VisualLayers.Count)
                return;

            Asset.VisualLayers.Swap(index, index + 1);
        }

        public void AddTileset(Tileset tileset)
        {
            if (Tilesets.Any(set => set.Name == tileset.Name))
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

            Asset.VisualLayers.ForEach(layer =>
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {

                        if (layer.Columns[x].Rows[y].TilesetName == removeTileset.TextureName)
                        {
                            layer.Columns[x].Rows[y].TilesetIndex = -1;
                            layer.Columns[x].Rows[y].TilesetName = string.Empty;
                        }

                    }
                }
            });

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

            for (int z = 0; z < Asset.VisualLayers.Count; z++)
            {
                if (Asset.VisualLayers[z].IsVisble)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        for (int y = 0; y < Height; y++)
                        {
                            TileVisual tile = Asset.VisualLayers[z].Columns[x].Rows[y];

                            if (!string.IsNullOrEmpty(tile.TilesetName))
                            {
                                if (tile.TilesetIndex >= 0)
                                {
                                    Tileset tileset = Tilesets.FirstOrDefault(set => set.TextureName == tile.TilesetName);

                                    if (tileset != null)
                                    {
                                        Vector2 position = MathExtension.IsoCoordinateToPixels(x, y, TileWidth, TileHeight);                                     

                                        //spriteBatch.Draw(Pixel, position, Color.Red);
                                        // TODO: Apply height decimal places to the alignment of Y axis
                                        spriteBatch.Draw(tileset.Texture, new Rectangle((int)position.X, (int)position.Y, TileWidth, TileHeight),
                                            tileset.GetSourceRectangle(tile.TilesetIndex, TileWidth, TileHeight), Color.White * Asset.VisualLayers[z].Alpha, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);

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

        public void Truncate()
        {
            int? startX = null;
            int? startY = null;
            int? width = null;
            int? height = null;
                        
            List<Layer<TileVisual>> layersToRemove = new List<Layer<TileVisual>>();

            TilemapAsset newAsset = new TilemapAsset();
            newAsset.VisualLayers = new List<Layer<TileVisual>>();
            
            // Get bounds of truncated rectangle
            for (int z = 0; z < Asset.VisualLayers.Count; z++)
            {
                bool deleteLayer = true;

                for(int x = 0; x < Width; x++)
                {
                    for(int y = 0; y < Height; y++)
                    {  
                        if(!string.IsNullOrEmpty(Asset.VisualLayers[z].Columns[x].Rows[y].TilesetName))
                        {
                            deleteLayer = false;

                            if (startY == null)
                                startY = y;

                            startY = Math.Min(startY.Value, y);

                            if (startX == null)
                                startX = x;

                            startX = Math.Min(startX.Value, x);

                            if (width == null)
                                width = x;

                            width = Math.Max(width.Value, x);

                            if (height == null)
                                height = y;

                            height = Math.Max(height.Value, y);
                        }
                    }
                }

                if (deleteLayer)
                    layersToRemove.Add(Asset.VisualLayers[z]);
            }

            // If every layer is empty than do nothing
            if (startX == null || startY == null || width == null || height == null)
                return;            
            
            // Remove empty layers
            layersToRemove.ForEach(layer => Asset.VisualLayers.Remove(layer));
          
            List<Layer<TileVisual>> layersToAdd = new List<Layer<TileVisual>>();

            int newWidth = width.Value - startX.Value + 1;
            int newHeight = height.Value - startY.Value + 1;

            // Create new layers
            for(int z = 0; z < Asset.VisualLayers.Count; z++)
            {
                TileVisual[,] box = Asset.VisualLayers[z].FindSection(startX.Value, startY.Value, newWidth, newHeight);
                Layer<TileVisual> newLayer = new Layer<TileVisual>();
                newLayer.Initialize(newWidth, newHeight);
                newLayer.IsVisble = true;
                newLayer.Alpha = 1.0f;
                newLayer.ID = Asset.VisualLayers[z].ID;
                newLayer.Name = Asset.VisualLayers[z].Name;

                for (int x = 0; x < newWidth; x++)
                {
                    for(int y = 0; y < newHeight; y++)
                    {
                        newLayer.Columns[x].Rows[y].TilesetIndex = box[x, y].TilesetIndex;
                        newLayer.Columns[x].Rows[y].TilesetName = box[x, y].TilesetName;
                    }
                }

                layersToAdd.Add(newLayer);
            }

            // Clear and add new layers
            Asset.VisualLayers.Clear();
            layersToAdd.ForEach(layer => Asset.VisualLayers.Add(layer));
            Width = newWidth;
            Height = newHeight;
            
        }
    }
}
