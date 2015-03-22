using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using oEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace oEngine.Entities
{
    [DataContract(Name=Consts.Nodes.Tilemap)]
    public class Tilemap : IEntity
    {
        [DataMember(Name = "Initialized")]
        private bool isInitialized;

        [DataMember(Name = "Tilesets")]
        private List<Tileset> tilesets = new List<Tileset>();

        [DataMember(Name = "Layers")]
        private List<Layer<TileVisual>> tilemapLayers = new List<Layer<TileVisual>>();


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
        public int Width { get; private set; }

        /// <summary>
        /// Gets the height of the tilemap in tiles
        /// </summary>
        [DataMember]
        public int Height { get; private set; }

        /// <summary>
        /// Gets the tile width of the tilemap in pixels
        /// </summary>
        [DataMember]
        public int TileWidth { get; private set; }

        /// <summary>
        /// Gets the tile height of the tilemap in pixels
        /// </summary>
        [DataMember]
        public int TileHeight { get; private set; }

        /// <summary>
        /// Gets or sets the pixel to draw grid
        /// </summary>
        public Texture2D Pixel { get; set; }

        /// <summary>
        /// Gets or sets whether the grid should be drawn
        /// </summary>
        public bool IsGridVisible;

        public void Initialize(string name, string description, int tileWidth, int tileHeight, int tilemapWidth, int tilemapHeight)
        {
            // Prevent this method from being called more than once
            if (isInitialized)
                throw new Exception("Tilemap has already been initialized");

            if (tileWidth <= 0 || tileHeight <= 0 || tilemapWidth <= 0 || tilemapHeight <= 0)
                throw new ArgumentOutOfRangeException("Tile and Tilemap dimensions should be greater than zero");

            //ID = Guid.NewGuid();

            Name = name;
            Description = description;

            TileWidth = tileWidth;
            TileHeight = tileHeight;

            Width = tilemapWidth;
            Height = tilemapHeight;

            isInitialized = true;

        }

        public void AddTilemapLayer<T>(string name, string description) where T : ITile
        {
            if (!isInitialized)
                throw new Exception("Scene must be initialized first before adding layer");

            Layer<TileVisual> layer = new Layer<TileVisual>();
            layer.Initialize(Width, Height);
            layer.Name = name;
            layer.Description = description;
            layer.IsVisble = true;
            layer.Alpha = 1.0f;
            
            tilemapLayers.Add(layer);           
        }

        public void RemoveTilemapLayer(Guid id)
        {
            tilemapLayers.RemoveAll(layer => layer.ID == id);
        }

        public IEnumerable<Layer<TileVisual>> FindTilemapLayers(Func<Layer<TileVisual>, bool> predicate)
        {
            return tilemapLayers.Where(layer => predicate(layer));
        }

        public int FindLayerIndex(Layer<TileVisual> layer)
        {
            return tilemapLayers.IndexOf(layer);
        }

        public void AddTileset(string name, string description, Texture2D texture)
        {
            if (!isInitialized)
                throw new Exception("Tilemap must be initialized first before adding tileset");

            if (tilesets.Any(set => set.Name == name))
                throw new Exception("Tileset with that name already exists");

            Tileset tileset = new Tileset();
            tileset.Initialize(name, texture);
            tileset.Name = name;
            tileset.Description = description;
            tilesets.Add(tileset);
        }

        public void RemoveTileset(Guid id)
        {
            Tileset removeTileset = tilesets.FirstOrDefault(tileset => tileset.ID == id);

            if (removeTileset == null)
                return;

            tilemapLayers.ForEach(layer =>
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {

                        if (layer.Columns[x].Rows[y].TilesetName == removeTileset.Name)
                            layer.Columns[x].Rows[y].TilesetName = string.Empty;

                    }
                }
            });

            tilesets.Remove(removeTileset);
        }

        public IEnumerable<Tileset> FindTilesets(Func<Tileset, bool> predicate)
        {
            return tilesets.Where(tileset => predicate(tileset));
        }

        public int FindTilesetIndex(Tileset tileset)
        {
            return tilesets.IndexOf(tileset);
        }       

        public void Draw(SpriteBatch spriteBatch)
        {
            if (spriteBatch == null || !isInitialized)
                return;

            for (int z = 0; z < tilemapLayers.Count; z++)
            {
                for (int x = Width - 1; x >= 0; x--)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        TileVisual tile = tilemapLayers[z].Columns[x].Rows[y];

                        if (!string.IsNullOrEmpty(tile.TilesetName))
                        {
                            if (tile.TilesetIndex >= 0)
                            {
                                Tileset tileset = tilesets.FirstOrDefault(set => set.Name == tile.TilesetName);

                                if (tileset != null)
                                {
                                    Vector2 position = MathExtension.IsoCoordinateToPixels(x, y, TileWidth, TileHeight);
                                    // TODO: Apply height decimal places to the alignment of Y axis
                                    spriteBatch.Draw(tileset.Texture, new Rectangle((int)position.X, (int)position.Y, TileWidth, TileHeight),
                                        tileset.GetSourceRectangle(tile.TilesetIndex, TileWidth, TileHeight), Color.White * tilemapLayers[z].Alpha, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);
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

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    spriteBatch.Draw(Pixel, MathExtension.IsoCoordinateToPixels(x, y, TileWidth, TileHeight), Color.White);
                }
            }
        }
    }   
}
