using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace oEditor.Common
{
    [DataContract]
    public class Settings
    {
        [DataMember]
        public Color TilemapBackground { get; set; }

        [DataMember]
        public Color TilesetBackground { get; set; }

        [DataMember]
        public int MaxNumberOfConsoleMessage { get; set; }

        [DataMember]
        public float ZoomIncrement { get; set; }

        [DataMember]
        public float MaxCameraZoom { get; set; }

        [DataMember]
        public float MinCameraZoom { get; set; }

        [DataMember]
        public int TileWidth { get; set; }

        [DataMember]
        public int TileHeight { get; set; }

        [DataMember]
        public int SceneWidth { get; set; }

        [DataMember]
        public int SceneHeight { get; set; }

        public static Settings CreateDefault()
        {
            return new Settings()
            {
                TilemapBackground = new Color(40, 40, 40),
                TilesetBackground = Color.White,
                MaxNumberOfConsoleMessage = 1024,
                ZoomIncrement = 0.2f,
                MaxCameraZoom = 2.0f,
                MinCameraZoom = 0.5f,
                TileWidth = 100,
                TileHeight = 50,
                SceneWidth = 25,
                SceneHeight = 25,
            };
        }
    }
}
