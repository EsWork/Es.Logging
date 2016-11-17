using System.Collections.Generic;

namespace Es.Logging
{
    /// <summary>
    /// Logger is based on the factory create instance
    /// </summary>
    public class LoggerFactory : ILoggerFactory
    {
        /// <summary>
        /// The lock object
        /// </summary>
        private readonly object lockObject = new object();

        /// <summary>
        /// More than one Provider
        /// </summary>
        private List<ILoggerProvider> _providers = new List<ILoggerProvider>();

        /// <summary>
        /// For different Loggers
        /// </summary>
        private readonly Dictionary<string, AggregateLogger> _loggers = new Dictionary<string, AggregateLogger>();

        /// <summary>
        /// Adds the provider.
        /// </summary>
        /// <param name="providers">The providers.</param>
        public void AddProvider(ILoggerProvider[] providers) {
            lock (lockObject) {
                _providers.AddRange(providers);
                //When add the provider, will need to update the provider of original logger
                foreach (var logger in _loggers) {
                    logger.Value.AddProvider(providers);
                }
            }
        }

        /// <summary>
        /// Creates the logger.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ILogger.</returns>
        public ILogger CreateLogger(string name) {
            AggregateLogger logger;
            if (!_loggers.TryGetValue(name, out logger)) {
                lock (lockObject) {
                    if (!_loggers.TryGetValue(name, out logger)) {
                        logger = new AggregateLogger(_providers.ToArray(), name);
                        _loggers[name] = logger;
                    }
                }
            }
            return logger;
        }
    }
}