using System;
using System.Collections.Generic;
using System.Text;
using Serilog.Events;
using Serilog.Parsing;

namespace Es.Logging
{
    internal class Logger : ILogger
    {
        private Serilog.ILogger _logger;

        public Logger(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(GetLogLevel(logLevel));
        }

        public void Log(LogLevel logLevel, string message, Exception exception)
        {
            var level = GetLogLevel(logLevel);
            if (!_logger.IsEnabled(level))
            {
                return;
            }

            if (string.IsNullOrEmpty(message) && exception == null)
                return;

            var logger = _logger;
            logger.Write(level, exception, message);
        }

        private LogEventLevel GetLogLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Debug: return LogEventLevel.Debug;
                case LogLevel.Info: return LogEventLevel.Information;
                case LogLevel.Warn: return LogEventLevel.Warning;
                case LogLevel.Error: return LogEventLevel.Error;
                case LogLevel.Fatal: return LogEventLevel.Fatal;
                case LogLevel.Trace:
                default: return LogEventLevel.Verbose;
            }
        }
    }
}
