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
        /// <param name="factory"><see cref="ILoggerFactory"/></param>
        /// <param name="minLevel"><see cref="LogLevel"/></param>
        /// <returns></returns>
        public static ILoggerFactory AddConsole(this ILoggerFactory factory, LogLevel minLevel) {
            factory.AddProvider(new ConsoleLoggerProvider(minLevel));
            return factory;
        }
    }
}