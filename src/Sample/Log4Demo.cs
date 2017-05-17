using System;
using Es.Logging;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using log4net.Repository;

namespace Sample
{
    public class Log4Demo
    {
        private readonly ILoggerFactory _logFactory;

        public Log4Demo()
        {
            _logFactory = new LoggerFactory();

            ILoggerRepository repo = LogManager.CreateRepository("Default");

            BasicConfigurator.Configure(repo, new ConsoleAppender
            {
                Layout = new PatternLayout(
                "%date [%thread] %-5level %logger - %message%newline"
                )
            });

            _logFactory.AddLog4net();
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