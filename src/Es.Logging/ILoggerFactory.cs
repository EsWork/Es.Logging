namespace Es.Logging
{
    /// <summary>
    /// Interface ILoggerFactory
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// Creates the logger.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ILogger.</returns>
        ILogger CreateLogger(string name);

        /// <summary>
        /// Adds the provider.
        /// </summary>
        /// <param name="providers">The providers.</param>
        void AddProvider(ILoggerProvider[] providers);
    }
}