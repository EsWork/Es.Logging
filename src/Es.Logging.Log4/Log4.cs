using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Es.Logging
{
    class Log4 : ILogger
    {
        private readonly ILog _log;

        private readonly static Type ThisDeclaringType = typeof(Log4);

        public Log4(ILog log) {
            _log = log;
        }

        public bool IsEnabled(LogLevel logLevel) {
            return _log.Logger.IsEnabledFor(GetLogLevel(logLevel));
        }

        public void Log(LogLevel logLevel, string message, Exception exception) {
            _log.Logger.Log(ThisDeclaringType,
                GetLogLevel(logLevel),
                message, 
                exception);
        }

        private log4net.Core.Level GetLogLevel(LogLevel logLevel) {
            switch (logLevel) {
                case LogLevel.Trace: return log4net.Core.Level.Trace;
                case LogLevel.Debug: return log4net.Core.Level.Debug;
                case LogLevel.Info: return log4net.Core.Level.Info;
                case LogLevel.Warn: return log4net.Core.Level.Warn;
                case LogLevel.Error: return log4net.Core.Level.Error;
                case LogLevel.Fatal: return log4net.Core.Level.Fatal;
                default: return log4net.Core.Level.Off;
            }
        }
    }
}
