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
                        settings = Serializer.Deserialize<Settings>(Consts.OscEditorSettingsPath);// = Serializer.Deserialize<Settings>(Consts.OSC_EDITOR_SETTINGS);
                    }
                    catch(FileNotFoundException fileNotFoundException)
                    {
                        Logger.Log("Configuration", "Settings", fileNotFoundException, "File not found");

                        // If settings not found then use default settings
                        settings = Settings.CreateDefault();
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
                    if (!Directory.Exists(Consts.OscDirectory))
                        Directory.CreateDirectory(Consts.OscDirectory);

                    settings.Serialize(Consts.OscEditorSettingsPath);
                }
                catch(Exception exception)
                {
                    Logger.Log("Configuration", "Settings", exception, "Cannot serialize");
                }
            }
        }
    }
}
