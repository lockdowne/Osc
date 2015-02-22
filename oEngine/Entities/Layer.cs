using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using oEngine.Common;

namespace oEngine.Entities
{
    public class Layer : IEntity
    {
        public class Column
        {
            public List<Tile> Rows = new List<Tile>();
        }

        private int width;
        private int height;

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
        /// Get or set the tiles inside layer
        /// </summary>
        public List<Column> Columns = new List<Column>();

        /// <summary>
        /// Gets or sets the visibilty state of the layer
        /// </summary>
        public bool IsVisble { get; set; }

        /// <summary>
        /// Sets the dimensions of the layer
        /// </summary>
        /// <param name="width">width in tiles</param>
        /// <param name="height">height in tiles</param>
        public void Initialize(int width, int height)
        {
            // Prevent this call if has already been initialized
            if (Columns.Count > 0)
                throw new Exception("Layer has already been initialized");

            this.width = width;
            this.height = height;

            ID = Guid.NewGuid();

            // Populate layer with tile instances
            for (int x = 0; x < width; x++)
            {
                Column column = new Column();

                for (int y = 0; y < height; y++)
                {
                    column.Rows.Add(new Tile()
                    {
                        TilesetIndex = -1,
                        TileType = Enums.TileTypes.None,
                    });
                }

                Columns.Add(column);
            }
        }

        public Tile FindTile(int x, int y)
        {
            if (x < 0 || y < 0)
                return null;

            if (x >= width || y >= height)
                return null;

            return Columns[x].Rows[y];
        }

        public void Resize(int width, int height)
        {
            // TODO: Resize layer
        }       
    }
}
