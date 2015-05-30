using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace oEngine.Entities
{
    public class TileCollision : ITile
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

        [DataMember]
        public bool IsCollidable { get; set; }
    }
}
