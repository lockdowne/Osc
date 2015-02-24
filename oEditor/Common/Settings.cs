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

        public static Settings CreateDefault()
        {
            return new Settings()
            {
                TilemapBackground = new Color(40, 40, 40),
                MaxNumberOfConsoleMessage = 1024,
                ZoomIncrement = 0.1f,
                MaxCameraZoom = 2.0f,
                MinCameraZoom = 0.1f,
            };
        }
    }
}
