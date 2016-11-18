using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Es.Logging
{
    internal class ConsoleLogger : ILogger
    {

        private readonly IConsole _console;

        private readonly string _name;

        private readonly LogLevel _minLevel;

        private readonly object _syncLock = new object();

        private readonly ConsoleColor? DefaultConsoleColor = null;

        public ConsoleLogger(string name, LogLevel minLevel) {
            _name = name;
            _minLevel = minLevel;

#if !NET40
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                _console = new WindowsLogConsole();
            }
            else {
                _console = new UnixLogConsole();
            }
#else
            _console = new WindowsLogConsole();
#endif
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

            WriteLine(logLevel, _name, message);
        }


        protected virtual void WriteLine(LogLevel logLevel, string name, string message) {

            var color = GetColor(logLevel);
            var levelString = GetLevelString(logLevel);

            lock (_syncLock) {
                _console.Write(
                    $"{levelString.PadLeft(5, ' ')}",
                    color.Background,
                    color.Foreground);

                _console.WriteLine(
                    $":{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {name} {message}",
                    DefaultConsoleColor, DefaultConsoleColor);

                _console.Flush();
            }
        }

        private static string GetLevelString(LogLevel logLevel) {
            switch (logLevel) {
                case LogLevel.Trace:
                    return "TRACE";

                case LogLevel.Debug:
                    return "DEBUG";

                case LogLevel.Info:
                    return "INFO";

                case LogLevel.Warn:
                    return "WARN";

                case LogLevel.Error:
                    return "ERROR";

                case LogLevel.Fatal:
                    return "FATAL";

                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel));
            }
        }

        private Color GetColor(LogLevel logLevel) {
            switch (logLevel) {
                case LogLevel.Fatal:
                    return new Color(ConsoleColor.White, ConsoleColor.Red);

                case LogLevel.Error:
                    return new Color(ConsoleColor.Black, ConsoleColor.Red);

                case LogLevel.Warn:
                    return new Color(ConsoleColor.Yellow, ConsoleColor.Black);

                case LogLevel.Info:
                    return new Color(ConsoleColor.DarkGreen, ConsoleColor.Black);

                case LogLevel.Trace:
                    return new Color(ConsoleColor.Gray, ConsoleColor.Black);

                case LogLevel.Debug:
                    return new Color(ConsoleColor.Gray, ConsoleColor.Black);

                default:
                    return new Color(ConsoleColor.White, ConsoleColor.Red);
            }
        }

        private struct Color
        {
            public Color(ConsoleColor? foreground, ConsoleColor? background) {
                Foreground = foreground;
                Background = background;
            }

            public ConsoleColor? Foreground { get; }

            public ConsoleColor? Background { get; }
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