﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Es.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Sample
{
    public class NLogDemo
    {
        private readonly LoggerFactory _logFactory;

        public NLogDemo()
        {
            _logFactory = new LoggerFactory();

            LoggingConfiguration config = new LoggingConfiguration();

            ColoredConsoleTarget consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            LoggingRule rule1 = new LoggingRule("*", NLog.LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(rule1);

            _logFactory.AddNLog(config.LogFactory);
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