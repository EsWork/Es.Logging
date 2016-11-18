namespace Es.Logging
{
    /// <summary>
    /// Provider from <see cref="ConsoleLogger"/>
    /// </summary>
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        private readonly LogLevel _minLevel;

        /// <summary>
        /// Constructor parameters setup log to register
        /// </summary>
        /// <param name="minLevel">Setting <see cref="LogLevel"/></param>
        public ConsoleLoggerProvider(LogLevel minLevel) {
            _minLevel = minLevel;
        }

        /// <summary>
        /// create a <see cref="ConsoleLogger"/> instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns>return <see cref="ConsoleLogger"/> instance</returns>
        public ILogger CreateLogger(string name) {
            return new ConsoleLogger(name, _minLevel);
        }

        /// <summary>
        /// Perform and release or reset unmanaged resources associated application defined tasks.
        /// </summary>
        public void Dispose() {
            //nothing
        }
    }
}