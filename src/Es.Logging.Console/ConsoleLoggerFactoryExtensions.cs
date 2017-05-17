namespace Es.Logging
{
    /// <summary>
    /// Console Logger Factory Extensions
    /// </summary>
    public static class ConsoleLoggerFactoryExtensions
    {
        /// <summary>
        /// Add the Console output Logger.
        /// </summary>
        /// <param name="factory"><see cref="LoggerFactory"/></param>
        /// <param name="minLevel"><see cref="LogLevel"/></param>
        /// <param name="colorEnable">Whether open font color</param>
        /// <returns></returns>
        public static LoggerFactory AddConsole(this LoggerFactory factory, LogLevel minLevel, bool colorEnable = true)
        {
            factory.AddProvider(new ConsoleLoggerProvider(minLevel, colorEnable));
            return factory;
        }

    }
}