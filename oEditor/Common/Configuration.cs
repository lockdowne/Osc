using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oEngine.Common;
using Microsoft.Xna.Framework;
using System.IO;

namespace oEditor.Common
{
    /// <summary>
    /// Represents global settings for application
    /// Serialized by settings
    /// </summary>
    public static class Configuration
    {
        private static Settings settings;

        public static Settings Settings
        {
            get
            {
                if (settings == null)
                {
                    try
                    {
                        if (File.Exists(Consts.OscPaths.EditorSettings))
                        {
                            settings = Serializer.Deserialize<Settings>(Consts.OscPaths.EditorSettings);// = Serializer.Deserialize<Settings>(Consts.OSC_EDITOR_SETTINGS);
                        }
                        else
                        {
                            settings = Settings.CreateDefault();
                        }
                    }
                    catch(Exception exception)
                    {
                        Logger.Log("Configuration", "Settings", exception, "Invalid data");

                        // If settings not found then use default settings
                        settings = Settings.CreateDefault();
                    }
                }

                return settings;
            }
            set
            {
                settings = value;

                try
                {
                    if (!Directory.Exists(Consts.OscPaths.MainDirectory))
                        Directory.CreateDirectory(Consts.OscPaths.MainDirectory);

                    settings.Serialize(Consts.OscPaths.EditorSettings);
                }
                catch(Exception exception)
                {
                    Logger.Log("Configuration", "Settings", exception, "Cannot serialize");
                }
            }
        }
    }
}
