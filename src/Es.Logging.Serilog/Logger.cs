using Serilog.Events;
using System;

namespace Es.Logging
{
    internal class Logger : ILogger
    {
        private readonly Serilog.ILogger _logger;

        public Logger(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(GetLogLevel(logLevel));
        }

        public void Log(LogLevel logLevel, string message, Exception? exception)
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
            return logLevel switch
            {
                LogLevel.Debug => LogEventLevel.Debug,
                LogLevel.Info => LogEventLevel.Information,
                LogLevel.Warn => LogEventLevel.Warning,
                LogLevel.Error => LogEventLevel.Error,
                LogLevel.Fatal => LogEventLevel.Fatal,
                _ => LogEventLevel.Verbose,
            };
        }
    }
}