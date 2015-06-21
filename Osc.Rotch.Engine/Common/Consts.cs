using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Osc.Rotch.Engine.Common
{
    public static class Consts
    {
        public static class OscPaths
        {
            //public static readonly string TilesetTexturesDirectory = Directory.GetCurrentDirectory() + @"\Textures\Tilesets";
            public static readonly string TexturesDirectory = Directory.GetCurrentDirectory() + @"\Textures";
            public static readonly string MainDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Osc\Rotch";
            public static readonly string EditorDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Osc\Rotch\Editor";
           // public static readonly string Log = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Osc\Game\Log.xml";
            public static readonly string EditorSettings = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Osc\Rotch\Editor\Settings.xml";
        }

        public static class Repositories
        {
            public static readonly string Tilemaps = Directory.GetCurrentDirectory() + @"\Tilemaps.xml";
            public static readonly string Characters = Directory.GetCurrentDirectory() + @"\Characters.xml";
            public static readonly string TilemapAssets = Directory.GetCurrentDirectory() + @"\TilemapAssets.xml";
        }

        public static class Nodes
        {
            public const string Root = "Root";
            public const string Tilemap = "Tilemap";
            public const string Character = "Character";
            public const string EmptyTilemap = "EmptyTilemap";
            public const string TilemapAsset = "TilemapAsset";
        }       

        public static class Editor
        {
            public const string TilemapLayerName = "Tilemap Layer";

            public static class Windows
            {
                public const string Console = "Console";
                public const string ProjectExplorer = "Project Explorer";
                public const string Entities = "Entities";
            }
        }

        public static class AlertMessages
        {
            public static class Messages
            {
                public const string DeleteEntity = "Are you sure you want to delete this entity?";
                public const string ImageAlreadyExists = "An image with the same name already exists";
                public const string SelectTilesetImage = "Select a tileset";
                public const string RemoveTileset = "Are you sure you want to delete the selected tileset?";
                public const string RemoveEntity = "Are you sure you want to delete the selected entity?";
                public const string NodeNameTaken = "Name is already in use.";
                public const string ResetConfiguration = "Are you sure you want to reset the configuration";
            }

            public static class Captions
            {
                public const string DeleteEntity = "Hey Listen";
                public const string ImageAlreadyExists = "Hey Listen";
                public const string SelectTilesetImage = "Hey Listen";
                public const string RemoveTileset = "Hey Listen";
                public const string RemoveEntity = "Hey Listen";
                public const string NodeNameTaken = "Hey Listen";
                public const string ResetConfiguration = "Hey Listen";
            }
        }


        public const int MaxSounds = 16;
        public const int LogWidth = 128;

        public const int TurnReady = 100;
    }
}
