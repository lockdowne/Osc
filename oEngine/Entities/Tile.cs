using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using oEngine.Common;
using System.Runtime.Serialization;

namespace oEngine.Entities
{
    [DataContract]
    public class Tile : IEntity
    {
        /// <summary>
        /// Gets or sets the unique ID of entity
        /// NOTE: Unused for tile, since tiles are identified by their location in the layer
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
        /// Name of tileset tile should be drawn from
        /// </summary>
        [DataMember]
        public string TilesetName { get; set; }

        /// <summary>
        /// Gets or sets the location of the tileset to draw based off of tile dimensions compared to the tileset image
        /// </summary>
        [DataMember]
        public int TilesetIndex { get; set; }

        /// <summary>
        /// Gets or sets the height of tile represented in tilemap 
        /// Does not represent height in pixels
        /// </summary>
        [DataMember]
        public float Height { get; set; }

        /// <summary>
        /// Base tile type
        /// </summary>
        [DataMember]
        public Enums.TileTypes TileType { get; set; }

        // TODO: Add triggers

        // TODO: Look into other ways to merge layers
        // public List<Tuple<int, string>> TopTiles = new List<Tuple<int, string>>();
    }
}
