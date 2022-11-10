using System;
using MS = Microsoft.Extensions.Logging;

namespace Es.Logging
{
    public class Logger : ILogger
    {
        private readonly MS.ILogger _logger;
        private static readonly Func<object, Exception?, string> _messageFormatter = MessageFormatter;

        public Logger(MS.ILogger logger)
        {
            _logger = logger;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(Logger.GetLogLevel(logLevel));
        }

        private bool IsEnabled(MS.LogLevel logLevel)
        {
            return _logger.IsEnabled(logLevel);
        }

        public void Log(LogLevel logLevel, string message, Exception? exception)
        {
            var level = Logger.GetLogLevel(logLevel);
            if (IsEnabled(level))
            {
                _logger.Log(Logger.GetLogLevel(logLevel), 0, message, exception, _messageFormatter);
            }
        }

        private static MS.LogLevel GetLogLevel(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => MS.LogLevel.Trace,
                LogLevel.Debug => MS.LogLevel.Debug,
                LogLevel.Info => MS.LogLevel.Information,
                LogLevel.Warn => MS.LogLevel.Warning,
                LogLevel.Error => MS.LogLevel.Error,
                LogLevel.Fatal => MS.LogLevel.Critical,
                _ => MS.LogLevel.None,
            };
        }

        private static string MessageFormatter(object state, Exception? error)
        {
            return state?.ToString() ?? string.Empty;
        }
    }
}