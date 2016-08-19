// ==++==
//
//  Copyright (c) . All rights reserved.
//
// ==--==
/* ---------------------------------------------------------------------------
 *
 * Author			: v.la
 * Email			: v.la@live.cn
 * Created			: 2015-09-07
 * Class			: LoggerFactory.cs
 *
 * ---------------------------------------------------------------------------
 * */

using System.Collections.Generic;

namespace Es.Logging
{
    /// <summary>
    /// Class LoggerFactory.
    /// </summary>
    public class LoggerFactory : ILoggerFactory
    {
        /// <summary>
        /// The lock object
        /// </summary>
        private readonly object lockObject = new object();

        /// <summary>
        /// The _providers
        /// </summary>
        private List<ILoggerProvider> _providers = new List<ILoggerProvider>();

        /// <summary>
        /// The _loggers
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