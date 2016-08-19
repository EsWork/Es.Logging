using System;

namespace Es.Logging
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        private readonly LogLevel _minLevel;

        public ConsoleLoggerProvider(LogLevel minLevel) {
            _minLevel = minLevel;
        }

        public ILogger CreateLogger(string name) {
            return new ConsoleLogger(name, _minLevel);
        }

        public void Dispose() {
        }
    }
}