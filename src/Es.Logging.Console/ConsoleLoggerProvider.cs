namespace Es.Logging
{
    /// <summary>
    /// Provider from <see cref="ConsoleLogger"/>
    /// </summary>
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        private readonly LogLevel _minLevel;
        private readonly bool _colorEnable;

        /// <summary>
        /// Constructor parameters setup log to register
        /// </summary>
        /// <param name="minLevel">Setting <see cref="LogLevel"/></param>
        /// <param name="colorEnable">Whether open font color</param>
        public ConsoleLoggerProvider(LogLevel minLevel, bool colorEnable = true)
        {
            _minLevel = minLevel;
            _colorEnable = colorEnable;
        }

        /// <summary>
        /// create a <see cref="ConsoleLogger"/> instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns>return <see cref="ConsoleLogger"/> instance</returns>
        public ILogger CreateLogger(string name)
        {
            return new ConsoleLogger(name, _minLevel) { ColorEnable = _colorEnable };
        }

        /// <summary>
        /// Perform and release or reset unmanaged resources associated application defined tasks.
        /// </summary>
        public void Dispose()
        {
            //nothing
        }
    }
}