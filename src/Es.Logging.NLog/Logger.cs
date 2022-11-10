using System;
using System.Globalization;

namespace Es.Logging
{
    internal class Logger : ILogger
    {
        private readonly NLog.Logger _logger;

        public Logger(NLog.Logger logger)
        {
            _logger = logger;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(GetLogLevel(logLevel));
        }

        public void Log(LogLevel logLevel, string message, Exception? exception)
        {
            if (!IsEnabled(logLevel))
                return;

            if (string.IsNullOrEmpty(message) && exception == null)
                return;

            var eventInfo = NLog.LogEventInfo.Create(
                GetLogLevel(logLevel),
                _logger.Name,
                exception,
                CultureInfo.CurrentCulture,
                message);

            _logger.Log(eventInfo);
        }

        private NLog.LogLevel GetLogLevel(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => NLog.LogLevel.Trace,
                LogLevel.Debug => NLog.LogLevel.Debug,
                LogLevel.Info => NLog.LogLevel.Info,
                LogLevel.Warn => NLog.LogLevel.Warn,
                LogLevel.Error => NLog.LogLevel.Error,
                LogLevel.Fatal => NLog.LogLevel.Fatal,
                _ => NLog.LogLevel.Off,
            };
        }
    }
}