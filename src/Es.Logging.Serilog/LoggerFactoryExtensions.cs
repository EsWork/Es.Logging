namespace Es.Logging
{
    /// <summary>
    /// LoggerFactoryExtensions
    /// </summary>
    public static class LoggerFactoryExtensions
    {
        /// <summary>
        /// Enable Serilog as logging provider
        /// </summary>
        /// <param name="factory"><see cref="ILoggerFactory"/></param>
        /// <param name="logger"><see cref="Serilog.ILogger"/></param>
        /// <returns></returns>
        public static ILoggerFactory AddSerilog(this ILoggerFactory factory, Serilog.ILogger logger)
        {
            factory.AddProvider(new LoggerProvider(logger));
            return factory;
        }
    }
}