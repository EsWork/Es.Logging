using System;
using System.Text;

namespace Es.Logging
{
    internal class UnixLogConsole : IConsole
    {
        private readonly StringBuilder _messageBuilder = new StringBuilder();

        private const string BACKGROUND = "\x1B[39m\x1B[22m";
        private const string FOREGROUND = "\x1B[49m";

        public void Flush()
        {
            Console.Write(_messageBuilder.ToString());
            _messageBuilder.Clear();
        }

        public void Write(string logMessage, ConsoleColor? background, ConsoleColor? foreground)
        {
            if (background.HasValue)
            {
                _messageBuilder.Append(GetBackgroundColor(background.Value));
            }

            if (foreground.HasValue)
            {
                _messageBuilder.Append(GetForegroundColor(foreground.Value));
            }

            _messageBuilder.Append(logMessage);

            if (foreground.HasValue)
            {
                _messageBuilder.Append(BACKGROUND);
            }

            if (background.HasValue)
            {
                _messageBuilder.Append(FOREGROUND);
            }
        }

        public void WriteLine(string logMessage, ConsoleColor? background, ConsoleColor? foreground)
        {
            Write(logMessage, background, foreground);
            _messageBuilder.AppendLine();
        }

        private static string GetForegroundColor(ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    return "\x1B[30m";

                case ConsoleColor.DarkRed:
                    return "\x1B[31m";

                case ConsoleColor.DarkGreen:
                    return "\x1B[32m";

                case ConsoleColor.DarkYellow:
                    return "\x1B[33m";

                case ConsoleColor.DarkBlue:
                    return "\x1B[34m";

                case ConsoleColor.DarkMagenta:
                    return "\x1B[35m";

                case ConsoleColor.DarkCyan:
                    return "\x1B[36m";

                case ConsoleColor.Gray:
                    return "\x1B[37m";

                case ConsoleColor.Red:
                    return "\x1B[1m\x1B[31m";

                case ConsoleColor.Green:
                    return "\x1B[1m\x1B[32m";

                case ConsoleColor.Yellow:
                    return "\x1B[1m\x1B[33m";

                case ConsoleColor.Blue:
                    return "\x1B[1m\x1B[34m";

                case ConsoleColor.Magenta:
                    return "\x1B[1m\x1B[35m";

                case ConsoleColor.Cyan:
                    return "\x1B[1m\x1B[36m";

                case ConsoleColor.White:
                    return "\x1B[1m\x1B[37m";

                default:
                    return FOREGROUND;
            }
        }

        private static string GetBackgroundColor(ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    return "\x1B[40m";

                case ConsoleColor.Red:
                    return "\x1B[41m";

                case ConsoleColor.Green:
                    return "\x1B[42m";

                case ConsoleColor.Yellow:
                    return "\x1B[43m";

                case ConsoleColor.Blue:
                    return "\x1B[44m";

                case ConsoleColor.Magenta:
                    return "\x1B[45m";

                case ConsoleColor.Cyan:
                    return "\x1B[46m";

                case ConsoleColor.White:
                    return "\x1B[47m";

                default:
                    return BACKGROUND;
            }
        }
    }
}