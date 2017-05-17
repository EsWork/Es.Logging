using System;
using Es.Logging;
using NLog;

namespace Sample
{
    public class NLogXmlConfigureDemo
    {
        private readonly ILoggerFactory _logFactory;

        public NLogXmlConfigureDemo()
        {
            _logFactory = new LoggerFactory();

            string filename = "";
#if NETFULL
            filename = AppDomain.CurrentDomain.BaseDirectory + "NLog.xml";
#else
            filename = AppContext.BaseDirectory + "/NLog.xml";
#endif
            _logFactory.AddNLog(filename);
        }

        [Demo]
        public void WriteLog()
        {
            var log = _logFactory.CreateLogger("ConsoleDemo");

            log.Trace("Trace....");
            log.Debug("Verbose...");
            log.Info("Information....");
            log.Error("Error...");
            log.Warn("Warning...");
            log.Fatal("Fatal...");

            var exception = new InvalidOperationException("Invalid value");

            log.Error(exception);
        }
    }
}