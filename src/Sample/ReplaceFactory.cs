#if NETSTANDARD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Es.Logging;
using Microsoft.Extensions.Logging;
namespace Sample
{
    public class ReplaceFactory
    {
        private readonly Es.Logging.ILogger _logger = LoggerManager.GetLogger("ReplaceFactory");

        public ReplaceFactory() {
            var logFactory = new Es.Logging.LoggerFactory();

            var msLogFactory = new Microsoft.Extensions.Logging.LoggerFactory();

            msLogFactory.AddConsole(Microsoft.Extensions.Logging.LogLevel.Debug);

            logFactory.AddMicrosoftLog(msLogFactory);

            //replace factory and transfer the loggers
            LoggerManager.SetLoggerFactory(logFactory);
        }

        [Demo]
        public void WriteLog() {

            _logger.Trace("Trace....");
            _logger.Debug("Debug...");
            _logger.Info("Information....");
            _logger.Error("Error...");
            _logger.Warn("Warning...");
            _logger.Fatal("Fatal...");

            var exception = new InvalidOperationException("Invalid value");

            _logger.Error(exception);
        }
    }
}
#endif
