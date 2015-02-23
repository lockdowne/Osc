using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization;

namespace oEditor.Common
{
    [DataContract]
    public class Settings
    {
        [DataMember]
        public Color TilemapBackground { get; set; }

        [DataMember]
        public int MaxNumberOfConsoleMessage { get; set; }

        [DataMember]
        public float ZoomIncrement { get; set; }

        [DataMember]
        public float MaxCameraZoom { get; set; }

        [DataMember]
        public float MinCameraZoom { get; set; }
    }
}
