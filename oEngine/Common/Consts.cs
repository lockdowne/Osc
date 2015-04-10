using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace oEngine.Common
{
    public static class Consts
    {
        public static class OscPaths
        {
            public static readonly string TilesetTexturesDirectory = Directory.GetCurrentDirectory() + @"\Textures\Tilesets";
            public static readonly string TexturesDirectory = Directory.GetCurrentDirectory() + @"\Textures";
            public static readonly string MainDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Osc\Game";
            public static readonly string ExceptionLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Osc\Game\Log.txt";
            public static readonly string EditorSettings = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Osc\Game\EditorSettings.xml";
        }

        public static class Repositories
        {
            public static readonly string Tilemaps = "Tilemaps.xml";
            public static readonly string Characters = "Characters.xml";
        }

        public static class Nodes
        {
            public const string Tilemap = "Tilemap";
            public const string Character = "Character";            
        }

        public static class AlertMessages
        {
            public static class Messages
            {
                public const string DeleteEntity = "Are you sure you want to delete this entity?";
                public const string ImageAlreadyExists = "An image with the same name already exists";
                public const string SelectTilesetImage = "Select a tileset";
                public const string RemoveTileset = "Are you sure you want to delete the selected tileset?";

            }

            public static class Captions
            {
                public const string DeleteEntity = "Hey Listen";
                public const string ImageAlreadyExists = "Hey Listen";
                public const string SelectTilesetImage = "Hey Listen";
                public const string RemoveTileset = "Hey Listen";
            }
        }


        public const int MaxSounds = 16;
        public const int LogWidth = 128;
    }
}
