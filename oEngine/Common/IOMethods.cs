using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEngine.Common
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

            if(!IsAccessable(directory))
            {
                return false;
            }

            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return true;

        }
    }
}
