using System;

namespace Es.Logging.Console
{
    public class ConsoleLogger : ILogger
    {
        private readonly string _name;

        private readonly LogLevel _minLevel;

        private readonly object lockObject = new object();

        public ConsoleLogger(string name, LogLevel minLevel) {
            _name = name;
            _minLevel = minLevel;
        }

        public bool IsEnabled(LogLevel logLevel) {
            return logLevel >= _minLevel;
        }

        public void Log(LogLevel logLevel, string message, Exception exception) {
            if (!IsEnabled(logLevel)) {
                return;
            }

            message = LogFormatter.Formatter(message, exception);

            if (string.IsNullOrEmpty(message))
                return;

            lock (SyncRoot) {
                WriteLine(logLevel, _name, message);
            }
        }

        protected object SyncRoot {
            get { return lockObject; }
        }

        protected virtual void WriteLine(LogLevel logLevel, string name, string message) {
            if (logLevel >= LogLevel.Error)
                System.Console.Error.WriteLine("{0}:[{1}] {2}", GetLogLevelLable(logLevel), name, message);
            else
                System.Console.WriteLine("{0}:[{1}] {2}", GetLogLevelLable(logLevel), name, message);
        }

        private static string GetLogLevelLable(LogLevel logLevel) {
            switch (logLevel) {
                case LogLevel.Debug:
                    return "debug   ";

                case LogLevel.Trace:
                    return "trace   ";

                case LogLevel.Info:
                    return "info    ";

                case LogLevel.Warn:
                    return "warning ";

                case LogLevel.Error:
                    return "error   ";

                case LogLevel.Fatal:
                    return "fatal   ";

                default:
                    return "unknown ";
            }
        }
    }
}