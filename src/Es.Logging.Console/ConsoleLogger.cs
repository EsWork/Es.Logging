using System;
using System.Globalization;

namespace Es.Logging
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

            message = Formatter(message, exception);

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
            SetConsoleColor(logLevel);
            if (logLevel >= LogLevel.Error)
                Console.Error.WriteLine("{0} {1}:[{2}] {3}",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    logLevel.ToString().ToLowerInvariant(),
                    name,
                    message);
            else
                Console.WriteLine("{0} {1}:[{2}] {3}",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    logLevel.ToString().ToLowerInvariant(),
                    name,
                    message);
            Console.ResetColor();
        }

        private void SetConsoleColor(LogLevel logLevel) {
            switch (logLevel) {
                case LogLevel.Fatal:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;

                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case LogLevel.Trace:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }

        private static string Formatter(string message, Exception error) {
            if (message == null && error == null) {
                throw new InvalidOperationException("Not found the message or exception information to create a log message.");
            }

            if (message == null) {
                return error.ToString();
            }

            if (error == null) {
                return message;
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", message, Environment.NewLine, error.ToString());
        }
    }
}