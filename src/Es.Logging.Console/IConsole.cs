using System;

namespace Es.Logging
{
    internal interface IConsole
    {
        void Write(string logMessage, ConsoleColor? background, ConsoleColor? foreground);

        void WriteLine(string logMessage, ConsoleColor? background, ConsoleColor? foreground);

        void Flush();
    }
}