using System;

namespace Es.Logging
{
    internal class WindowsLogConsole : IConsole
    {
        public void Flush() {
            //Do Nothing, data is sent directly to the console
        }

        public void Write(string logMessage, ConsoleColor? background, ConsoleColor? foreground) {
            SetColor(background, foreground);
            Console.Out.Write(logMessage);
            ResetColor();
        }

        public void WriteLine(string logMessage, ConsoleColor? background, ConsoleColor? foreground) {
            SetColor(background, foreground);
            Console.Out.WriteLine(logMessage);
            ResetColor();
        }

        private void SetColor(ConsoleColor? background, ConsoleColor? foreground) {
            if (background.HasValue) {
                Console.BackgroundColor = background.Value;
            }

            if (foreground.HasValue) {
                Console.ForegroundColor = foreground.Value;
            }
        }

        private void ResetColor() {
            Console.ResetColor();
        }
    }
}