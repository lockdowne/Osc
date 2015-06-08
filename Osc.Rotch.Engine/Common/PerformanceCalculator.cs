using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Engine.Common
{
    public class PerformanceCalculator
    {
        private Stopwatch stopWatch = null;

        public void Start()
        {
            stopWatch = Stopwatch.StartNew();
        }

        public string Stop()
        {
            if (stopWatch == null) return string.Empty;

            stopWatch.Stop();

            double nanoSeconds = (1000000000.0 * (double)stopWatch.ElapsedTicks / Stopwatch.Frequency);

            double milliSeconds = (nanoSeconds / 1000000.0); double seconds = (milliSeconds / 1000);

            return string.Format(Environment.NewLine + "NanoSeconds: {0}" + Environment.NewLine + "Milliseconds: {1}" + Environment.NewLine + "Seconds: {2}", nanoSeconds, milliSeconds, seconds);

        }
    }
}
