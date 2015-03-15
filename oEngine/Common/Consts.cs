using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oEngine.Common
{
    public static class Consts
    {
        public const int MAX_SOUNDS = 16;
        public const int LOG_WIDTH = 128;

        public static readonly string OscDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Osc\Tactics";
        public static readonly string OscLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Osc\Tactics\Log.txt";
        public static readonly string OscEditorSettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Osc\Tactics\EditorSettings.osc";
        public static readonly string OscGameSettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Osc\Tactics\GameSettings.osc";
        public static readonly string OscSceneRepositoryPath = "Scenes.xml";
        public static readonly string OscCharacterRepositoryPath = "Characters.xml";

        public const string SceneNode = "Scene";
        public const string CharacterNode = "Character";
    }
}
