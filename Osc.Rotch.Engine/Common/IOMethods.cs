using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Engine.Common
{
    public static class IOMethods
    {
        public static bool IsAccessable(string path)
        {
            try
            {
                System.Security.AccessControl.DirectorySecurity result = Directory.GetAccessControl(path);

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }       
  
        public static bool CreateDirectory(string path)
        {
            string directory = Path.GetDirectoryName(path);
 
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if(!IsAccessable(directory))
            {
                return false;
            }

            return true;

        }
    }
}
