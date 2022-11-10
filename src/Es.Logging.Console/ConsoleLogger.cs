using System;
using System.Globalization;
#if !NET462
using System.Runtime.InteropServices;
#endif
namespace Es.Logging
{
    internal class ConsoleLogger : ILogger
    {
        private static readonly IConsole _console;

        private readonly string _name;

        private readonly LogLevel _minLevel;

        private readonly ConsoleColor? DefaultConsoleColor = null;

        private static readonly OutPutQueue _outPutQueue;

        static ConsoleLogger()
        {
#if !NET462
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

        public ConsoleLogger(string name, LogLevel minLevel)
        {
            _name = name;
            _minLevel = minLevel;
        }

        public bool ColorEnable { get; set; } = true;

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= _minLevel;
        }

        public void Log(LogLevel logLevel, string message, Exception? exception)
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
                Message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} {levelString} {name} {message}",
                Background = color.Background,
                Foreground = color.Foreground
            });

        }

        private static string GetLevelString(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => "trace",
                LogLevel.Debug => "debug",
                LogLevel.Info => "info",
                LogLevel.Warn => "warn",
                LogLevel.Error => "error",
                LogLevel.Fatal => "fatal",
                _ => throw new ArgumentOutOfRangeException(nameof(logLevel)),
            };
        }

        private Color GetColor(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Fatal => new Color(ConsoleColor.Magenta, ConsoleColor.Black),
                LogLevel.Error => new Color(ConsoleColor.Red, ConsoleColor.Black),
                LogLevel.Warn => new Color(ConsoleColor.Yellow, ConsoleColor.Black),
                LogLevel.Info => new Color(ConsoleColor.White, ConsoleColor.Black),
                LogLevel.Trace => new Color(ConsoleColor.Gray, ConsoleColor.Black),
                LogLevel.Debug => new Color(ConsoleColor.Gray, ConsoleColor.Black),
                _ => new Color(ConsoleColor.White, ConsoleColor.Black),
            };
        }

        private readonly struct Color
        {
            public Color(ConsoleColor? foreground, ConsoleColor? background)
            {
                Foreground = foreground;
                Background = background;
            }

            public ConsoleColor? Foreground { get; }

            public ConsoleColor? Background { get; }
        }

        private static string Formatter(string message, Exception? error)
        {
            if (message == null)
            {
                throw new InvalidOperationException("Not found the message information to create a log message.");
            }

            if (error == null)
            {
                return message;
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", message, Environment.NewLine, error.ToString());
        }
    }
}