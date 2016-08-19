using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Logging;

namespace Sample
{
    public class ConsoleDemo
    {
        private readonly ILoggerFactory _logFactory;

        public ConsoleDemo() {
            _logFactory = new LoggerFactory();
            _logFactory.AddConsole(LogLevel.Trace);
        }

        [Demo]
        public void WriteLog() {
            var log = _logFactory.CreateLogger("ConsoleDemo");

            log.Trace("Trace....");
            log.Debug("Debug...");
            log.Info("Information....");
            log.Error("Error...");
            log.Warn("Warning...");
            log.Fatal("Fatal...");

            var exception = new InvalidOperationException("Invalid value");

            log.Error(exception);
        }
    }
}
