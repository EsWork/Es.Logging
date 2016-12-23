using System.Collections.Generic;

namespace Es.Logging
{
    /// <summary>
    /// Logger is based on the factory create instance
    /// </summary>
    public class LoggerFactory : ILoggerFactory
    {
        private readonly object lockObject = new object();

        /// <summary>
        /// For different Loggers
        /// </summary>
        internal readonly Dictionary<string, AggregateLogger> Loggers = new Dictionary<string, AggregateLogger>();

        /// <summary>
        /// More than one Provider
        /// </summary>
        public readonly List<ILoggerProvider> Providers = new List<ILoggerProvider>
        {
            new EmptyLoggerProvider()
        };

        /// <summary>
        /// Adds the provider.
        /// </summary>
        /// <param name="providers">The providers.</param>
        public void AddProvider(ILoggerProvider[] providers) {
            lock (lockObject) {
                Providers.AddRange(providers);
                //When add the provider, will need to update the provider of original logger
                foreach (var logger in Loggers) {
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
            if (!Loggers.TryGetValue(name, out logger)) {
                lock (lockObject) {
                    if (!Loggers.TryGetValue(name, out logger)) {
                        logger = new AggregateLogger(Providers.ToArray(), name);
                        Loggers[name] = logger;
                    }
                }
            }
            return logger;
        }
    }
}