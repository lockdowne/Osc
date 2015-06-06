using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Editor.Events
{
    public class OnWriteConsole
    {
        public string Message { get; set; }
    }

    public class OnParseConsoleCommand
    {
        public string Command { get; set; }
    }
}
