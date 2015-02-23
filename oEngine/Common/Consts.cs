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

        public static readonly string OSC_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Osc\Tactics";
        public static readonly string OSC_FILE = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Osc\Tactics\Log.txt";
        public static readonly string OSC_EDITOR_SETTINGS = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Osc\Tactics\EditorSettings.osc";
        public static readonly string OSC_GAME_SETTINGS = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Osc\Tactics\GameSettings.osc";
    }
}
