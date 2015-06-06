using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Osc.Engine.Common;

namespace Osc.Rotch.Editor.Common
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
        public Color EraseBoxColor { get; set; }

        [DataMember]
        public Color CollisionBoxColor { get; set; }

        [DataMember]
        public Color CollisionLayerColor { get; set; }

        [DataMember]
        public int MaxNumberOfConsoleMessage { get; set; }

        [DataMember]
        public float ZoomIncrement { get; set; }

        [DataMember]
        public float MaxCameraZoom { get; set; }

        [DataMember]
        public float MinCameraZoom { get; set; }

        [DataMember]
        public float CameraLerpAmount { get; set; }

        [DataMember]
        public float SelectionBoxOpacity { get; set; }

        [DataMember]
        public float EraseBoxOpacity { get; set; }

        [DataMember]
        public float CollisionBoxOpacity { get; set; }

        [DataMember]
        public float CollisionLayerOpacity { get; set; }

        [DataMember]
        public float TilePatternOpacity { get; set; }

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
                if (IOMethods.CreateDirectory(Consts.OscPaths.Settings))
                {
                    if (!File.Exists(Consts.OscPaths.Settings))
                    {
                        Settings settings = Default();
                        Serializer.Serialize(settings, Consts.OscPaths.Settings);
                    }

                    return Serializer.Deserialize<Settings>(Consts.OscPaths.Settings);
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
                EraseBoxColor = Color.Red,
                CollisionBoxColor = new Color(150, 150, 150),
                CollisionLayerColor = new Color(75, 0, 130),
                MaxNumberOfConsoleMessage = 1024,
                ZoomIncrement = 0.2f,
                MaxCameraZoom = 2.0f,
                MinCameraZoom = 0.5f,
                SelectionBoxOpacity = 0.2f,
                EraseBoxOpacity = 0.2f,
                CollisionBoxOpacity = 0.2f,
                CollisionLayerOpacity = 0.5f,
                TilePatternOpacity = 0.5f,
                TileWidth = 128,
                TileHeight = 64,
                SceneWidth = 20,
                SceneHeight = 20,
                CameraLerpAmount = 1.0f,
            };
        }
    }
}
