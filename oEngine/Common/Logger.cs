using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace oEngine.Common
{
    public static class Logger
    {
        public static void Log(string className, string method, Exception exception = null, string description = "")
        {
            DateTime dateTime = DateTime.Now;
            StringBuilder builder = new StringBuilder();

            string status = exception == null ? "OK" : exception.ToString();

            builder.AppendLine(LineBreak());
            builder.AppendLine(dateTime.ToString());
            builder.AppendLine("Location: " + className + "." + method);
            if (!string.IsNullOrEmpty(description))
                builder.AppendLine("Description: " + description);
            builder.AppendLine("Status: " + status);

            try
            {
                if (!Directory.Exists(Consts.OscDirectory))
                    Directory.CreateDirectory(Consts.OscDirectory);

                File.AppendAllText(Consts.OscLog, builder.ToString());
            }
            catch(Exception e)
            {

            }
        }

        public static void Log(string className, string method, string description = "", Exception exception = null)
        {
            DateTime dateTime = DateTime.Now;
            StringBuilder builder = new StringBuilder();

            string status = exception == null ? "OK" : exception.ToString();

            builder.AppendLine(LineBreak());
            builder.AppendLine(dateTime.ToString());
            builder.AppendLine("Location: " + className + "." + method);
            if (!string.IsNullOrEmpty(description))
                builder.AppendLine("Description: " + description);
            builder.AppendLine("Status: " + status);

            try
            {
                if (!Directory.Exists(Consts.OscDirectory))
                    Directory.CreateDirectory(Consts.OscDirectory);

                File.AppendAllText(Consts.OscLog, builder.ToString());
            }
            catch (Exception e)
            {

            }
        }

        private static string LineBreak()
        {
            return string.Empty.PadRight(Consts.LOG_WIDTH, '-');
        }
    }
}
