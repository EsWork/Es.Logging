using System;
using MS = Microsoft.Extensions.Logging;

namespace Es.Logging
{
    public class Logger : ILogger
    {
        private readonly MS.ILogger _logger;
        private static readonly Func<object, Exception, string> _messageFormatter = MessageFormatter;

        public Logger(MS.ILogger logger) {
            _logger = logger;
        }

        public bool IsEnabled(LogLevel logLevel) {
            return _logger.IsEnabled(GetLogLevel(logLevel));
        }

        private bool IsEnabled(MS.LogLevel logLevel) {
            return _logger.IsEnabled(logLevel);
        }

        public void Log(LogLevel logLevel, string message, Exception exception) {
            var level = GetLogLevel(logLevel);
            if (IsEnabled(level)) {
                _logger.Log(GetLogLevel(logLevel), 0, message, exception, _messageFormatter);
            }
        }

        private MS.LogLevel GetLogLevel(LogLevel logLevel) {
            switch (logLevel) {
                case LogLevel.Trace: return MS.LogLevel.Trace;
                case LogLevel.Debug: return MS.LogLevel.Debug;
                case LogLevel.Info: return MS.LogLevel.Information;
                case LogLevel.Warn: return MS.LogLevel.Warning;
                case LogLevel.Error: return MS.LogLevel.Error;
                case LogLevel.Fatal: return MS.LogLevel.Critical;
                default: return MS.LogLevel.None;
            }
        }

        private static string MessageFormatter(object state, Exception error) {
            return state.ToString();
        }
    }
}