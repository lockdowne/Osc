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
            public const string DeleteConfirmation = "Are you sure you want to delete this entity?";
            public const string DeleteConfirmationCaption = "Warning";
            public const string ImageAlreadyExists = "An image with the same name already exists do you want to overwrite it?";
        }


        public const int MaxSounds = 16;
        public const int LogWidth = 128;
    }
}
