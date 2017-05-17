#if NETSTANDARD

using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Es.Logging;
using Microsoft.Extensions.Logging;

namespace Sample
{
    public class MicrosoftLogDemo
    {
        private readonly Es.Logging.LoggerFactory _logFactory;

        public MicrosoftLogDemo() {
            _logFactory = new Es.Logging.LoggerFactory();

            var msLogFactory = new Microsoft.Extensions.Logging.LoggerFactory();

            msLogFactory.AddConsole(Microsoft.Extensions.Logging.LogLevel.Debug);

            _logFactory.AddMicrosoftLog(msLogFactory);
        }

        [Demo]
        public void WriteLog() {
            var log = _logFactory.CreateLogger("MicrosoftLogDemo");

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

#endif