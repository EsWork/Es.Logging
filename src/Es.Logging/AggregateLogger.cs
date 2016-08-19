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
            List<Exception> exceptions = null;
            foreach (var logger in _loggers) {
                try {
                    if (logger.IsEnabled(logLevel)) {
                        return true;
                    }
                }
                catch (Exception ex) {
                    if (exceptions == null) {
                        exceptions = new List<Exception>();
                    }
                    exceptions.Add(ex);
                }
            }
            if (exceptions != null && exceptions.Count > 0) {
                throw new AggregateException(
                    message: "An error occurred while writing to logger(s).",
                    innerExceptions: exceptions);
            }
            return false;
        }

        public void Log(LogLevel logLevel, string message, Exception exception) {
            List<Exception> exceptions = null;
            foreach (var logger in _loggers) {
                try {
                    logger.Log(logLevel, message, exception);
                }
                catch (Exception ex) {
                    if (exceptions == null) {
                        exceptions = new List<Exception>();
                    }
                    exceptions.Add(ex);
                }
            }
            if (exceptions != null && exceptions.Count > 0) {
                throw new AggregateException(
                    message: "An error occurred while writing to logger(s).", innerExceptions: exceptions);
            }
        }

        internal void AddProvider(ILoggerProvider[] providers) {
            foreach (var provider in providers)
                _loggers.Add(provider.CreateLogger(_logName));
        }
    }
}