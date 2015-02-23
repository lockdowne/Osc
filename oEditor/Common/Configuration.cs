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
                        settings = Serializer.Deserialize<Settings>(Consts.OSC_EDITOR_SETTINGS);
                    }
                    catch(FileNotFoundException fileNotFoundException)
                    {
                        Logger.Log("Configuration", "Settings", fileNotFoundException, "File not found");

                        // If settings not found then use default settings
                        settings = new Settings();
                        settings.TilemapBackground = new Color(40, 40, 40);
                        settings.MaxNumberOfConsoleMessage = 5;
                        settings.ZoomIncrement = 0.1f;
                        settings.MaxCameraZoom = 2.0f;
                        settings.MinCameraZoom = 0.1f;
                    }
                    catch(Exception exception)
                    {
                        Logger.Log("Configuration", "Settings", exception, "Invalid data");

                        // If settings not found then use default settings
                        settings = new Settings();
                        settings.TilemapBackground = new Color(40, 40, 40);
                        settings.MaxNumberOfConsoleMessage = 5;
                        settings.ZoomIncrement = 0.1f;
                        settings.MaxCameraZoom = 2.0f;
                        settings.MinCameraZoom = 0.1f;
                    }
                }

                return settings;
            }
        }
    }
}
