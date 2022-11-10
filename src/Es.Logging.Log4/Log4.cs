using System;
using log4net;

namespace Es.Logging
{
    internal class Log4 : ILogger
    {
        private readonly ILog _log;

        private readonly static Type ThisDeclaringType = typeof(Log4);

        public Log4(ILog log)
        {
            _log = log;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _log.Logger.IsEnabledFor(GetLogLevel(logLevel));
        }

        public void Log(LogLevel logLevel, string message, Exception? exception)
        {
            if (!IsEnabled(logLevel))
                return;

            _log.Logger.Log(ThisDeclaringType,
                GetLogLevel(logLevel),
                message,
                exception);
        }

        private log4net.Core.Level GetLogLevel(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => log4net.Core.Level.Trace,
                LogLevel.Debug => log4net.Core.Level.Debug,
                LogLevel.Info => log4net.Core.Level.Info,
                LogLevel.Warn => log4net.Core.Level.Warn,
                LogLevel.Error => log4net.Core.Level.Error,
                LogLevel.Fatal => log4net.Core.Level.Fatal,
                _ => log4net.Core.Level.Off,
            };
        }
    }
}