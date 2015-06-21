using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Engine.Entities
{
    [DataContract(Namespace="")]
    public class TilemapAsset : ITile
    {
        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<Layer<TileVisual>> VisualLayers { get; set; }
        
        [DataMember]
        public float Alpha { get; set; }
    }
}
