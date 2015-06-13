using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Osc.Rotch.Engine.Common
{
    public class Logger : ILogger
    {
        [DataContract(Namespace="")]
        public class LogEntry
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public string Message { get; set; }
            [DataMember]
            public string MethodName { get; set; }
            [DataMember]
            public string ClassName { get; set; }
            [DataMember]
            public int LineNumber { get; set; }
            [DataMember]
            public string DateTime { get; set; }            
        }

        private List<LogEntry> Logs { get; set; }

        private object locker = new object();

        private string logPath;

        public event Action<LogEntry> OnLogged;

        
        public Logger()
        {
            Logs = new List<LogEntry>();

            logPath = Consts.OscPaths.MainDirectory + @"\Log [" + DateTime.Today.ToString("d").Replace('/', '.') + "].xml";

            if (CheckPath())
            {
                if (File.Exists(logPath))
                {
                    Logs = Serializer.Deserialize<LogEntry[]>(logPath).ToList();
                }
            }
        }

        public bool CheckPath()
        {
            try
            {
                if (!Directory.Exists(Consts.OscPaths.MainDirectory))
                {
                    Directory.CreateDirectory(Consts.OscPaths.MainDirectory);
                }

                System.Security.AccessControl.DirectorySecurity directory = Directory.GetAccessControl(Consts.OscPaths.MainDirectory);

                return true;
            }
            catch(UnauthorizedAccessException)
            {
                return false;
            }
        }

        public void Log(string message, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0)
        {
            lock (locker)
            {
                try
                {

                    LogEntry logEntry = new LogEntry()
                    {
                        Message = message,
                        MethodName = methodName,
                        ClassName = Path.GetFileNameWithoutExtension(filePath),
                        LineNumber = line,
                        DateTime = DateTime.Now.ToString("f"),
                        ID = Logs.Count,
                    };

                    Logs.Add(logEntry);

                    Serializer.SerializeAsync(Logs.ToArray(), logPath);

                    if (OnLogged != null)
                        OnLogged(logEntry);

                }
                catch (Exception)
                {

                }
            }               
        }

        public void Save()
        {
            lock (locker)
            {
                try
                {
                    Serializer.SerializeAsync(Logs.ToArray(), logPath);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
