using System;
using System.Collections.Generic;

namespace Es.Logging
{
    internal class AggregateLogger : ILogger
    {
        private readonly string _logName;
        private List<ILogger> _loggers = new List<ILogger>();

        public AggregateLogger(ILoggerProvider[] providers, string logName) {
            _logName = logName;
            AddProvider(providers);
        }

        public bool IsEnabled(LogLevel logLevel) {
            foreach (var logger in _loggers) {
                if (logger.IsEnabled(logLevel)) {
                    return true;
                }
            }
            return false;
        }

        public void Log(LogLevel logLevel, string message, Exception exception) {
            foreach (var logger in _loggers) {
                logger.Log(logLevel, message, exception);
            }
        }

        internal void AddProvider(ILoggerProvider[] providers) {
            foreach (var provider in providers)
                _loggers.Add(provider.CreateLogger(_logName));
        }
    }
}