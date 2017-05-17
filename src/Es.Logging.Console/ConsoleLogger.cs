using System;
using System.Globalization;
#if NETSTANDARD
using System.Runtime.InteropServices;
#endif
namespace Es.Logging
{
    internal class ConsoleLogger : ILogger
    {
        private readonly IConsole _console;

        private readonly string _name;

        private readonly LogLevel _minLevel;

        private readonly ConsoleColor? DefaultConsoleColor = null;

        private readonly OutPutQueue _outPutQueue;

        public ConsoleLogger(string name, LogLevel minLevel)
        {
            _name = name;
            _minLevel = minLevel;

#if !NETFULL
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _console = new WindowsLogConsole();
            }
            else
            {
                _console = new UnixLogConsole();
            }
#else
            _console = new WindowsLogConsole();
#endif
            _outPutQueue = new OutPutQueue()
            {
                Console = _console
            };
        }

        public bool ColorEnable { get; set; } = true;

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= _minLevel;
        }

        public void Log(LogLevel logLevel, string message, Exception exception)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            message = Formatter(message, exception);

            if (string.IsNullOrEmpty(message))
                return;

            WriteLine(logLevel, _name, message);
        }

        protected virtual void WriteLine(LogLevel logLevel, string name, string message)
        {
            var color = ColorEnable ? GetColor(logLevel)
                : new Color(DefaultConsoleColor, DefaultConsoleColor);
            var levelString = GetLevelString(logLevel);

            _outPutQueue.EnqueueMessage(new LogMessage
            {
                Message = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {levelString} {name} {message}",
                Background = color.Background,
                Foreground = color.Foreground
            });

        }

        private static string GetLevelString(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    return "trace";

                case LogLevel.Debug:
                    return "debug";

                case LogLevel.Info:
                    return "info";

                case LogLevel.Warn:
                    return "warn";

                case LogLevel.Error:
                    return "error";

                case LogLevel.Fatal:
                    return "fatal";

                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel));
            }
        }

        private Color GetColor(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Fatal:
                    return new Color(ConsoleColor.Magenta, ConsoleColor.Black);

                case LogLevel.Error:
                    return new Color(ConsoleColor.Red, ConsoleColor.Black);

                case LogLevel.Warn:
                    return new Color(ConsoleColor.Yellow, ConsoleColor.Black);

                case LogLevel.Info:
                    return new Color(ConsoleColor.White, ConsoleColor.Black);

                case LogLevel.Trace:
                    return new Color(ConsoleColor.Gray, ConsoleColor.Black);

                case LogLevel.Debug:
                    return new Color(ConsoleColor.Gray, ConsoleColor.Black);

                default:
                    return new Color(ConsoleColor.White, ConsoleColor.Black);
            }
        }

        private struct Color
        {
            public Color(ConsoleColor? foreground, ConsoleColor? background)
            {
                Foreground = foreground;
                Background = background;
            }

            public ConsoleColor? Foreground { get; }

            public ConsoleColor? Background { get; }
        }

        private static string Formatter(string message, Exception error)
        {
            if (message == null && error == null)
            {
                throw new InvalidOperationException("Not found the message or exception information to create a log message.");
            }

            if (message == null)
            {
                return error.ToString();
            }

            if (error == null)
            {
                return message;
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", message, Environment.NewLine, error.ToString());
        }
    }
}