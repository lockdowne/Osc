using Osc.Rotch.Engine.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Editor.Common
{
    /// <summary>
    /// Represents global settings for application
    /// Serialized by settings
    /// </summary>
    public static class Configuration
    {
        private static Settings settings = Settings.CreateDefault();

        public static Settings Settings
        {
            get
            {              
                return settings;
            }
            set
            {
                settings = value;
            }
        }
        
        public static void SaveSettings()
        {
            try
            {
                if(IOMethods.CreateDirectory(Consts.OscPaths.EditorSettings))
                {
                    Serializer.Serialize(settings, Consts.OscPaths.EditorSettings);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
