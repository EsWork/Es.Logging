using System;
using System.Globalization;

namespace Es.Logging
{
    internal class Logger : ILogger
    {
        private NLog.Logger _logger;

        public Logger(NLog.Logger logger)
        {
            _logger = logger;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(GetLogLevel(logLevel));
        }

        public void Log(LogLevel logLevel, string message, Exception exception)
        {
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
            switch (logLevel)
            {
                case LogLevel.Trace: return NLog.LogLevel.Trace;
                case LogLevel.Debug: return NLog.LogLevel.Debug;
                case LogLevel.Info: return NLog.LogLevel.Info;
                case LogLevel.Warn: return NLog.LogLevel.Warn;
                case LogLevel.Error: return NLog.LogLevel.Error;
                case LogLevel.Fatal: return NLog.LogLevel.Fatal;
                default: return NLog.LogLevel.Off;
            }
        }
    }
}