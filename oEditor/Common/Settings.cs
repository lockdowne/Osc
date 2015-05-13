using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using oEngine.Common;

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
        public Color SelectionBoxColor { get; set; }

        [DataMember]
        public int MaxNumberOfConsoleMessage { get; set; }

        [DataMember]
        public float ZoomIncrement { get; set; }

        [DataMember]
        public float MaxCameraZoom { get; set; }

        [DataMember]
        public float MinCameraZoom { get; set; }

        [DataMember]
        public float SelectionBoxOpacity { get; set; }

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
            try
            {
                if (IOMethods.CreateDirectory(Consts.OscPaths.EditorSettings))
                {
                    if (!File.Exists(Consts.OscPaths.EditorSettings))
                    {
                        Settings settings = Default();
                        Serializer.Serialize(settings, Consts.OscPaths.EditorSettings);
                    }

                    return Serializer.Deserialize<Settings>(Consts.OscPaths.EditorSettings);
                }
            }
            catch(Exception)
            {

            }

            return Default();
        }

        private static Settings Default()
        {
            return new Settings()
            {
                TilemapBackground = new Color(40, 40, 40),
                TilesetBackground = new Color(40, 40, 40),
                SelectionBoxColor = new Color(150, 150, 150),
                MaxNumberOfConsoleMessage = 1024,
                ZoomIncrement = 0.2f,
                MaxCameraZoom = 2.0f,
                MinCameraZoom = 0.5f,
                SelectionBoxOpacity = 0.2f,
                TileWidth = 128,
                TileHeight = 64,
                SceneWidth = 20,
                SceneHeight = 20,
            };
        }
    }
}
