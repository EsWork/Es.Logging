using System.Collections.Generic;

namespace Es.Logging
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly object lockObject = new object();

        private List<ILoggerProvider> _providers = new List<ILoggerProvider>();

        private readonly Dictionary<string, AggregateLogger> _loggers = new Dictionary<string, AggregateLogger>();

        public ILoggerProvider[] Providers {
            get {
                return _providers.ToArray();
            }
        }

        public void AddProvider(ILoggerProvider[] providers) {
            lock (lockObject) {
                _providers.AddRange(providers);
                //When add the provider, will need to update the provider of original logger
                foreach (var logger in _loggers) {
                    logger.Value.AddProvider(providers);
                }
            }
        }

        public ILogger CreateLogger(string name) {
            AggregateLogger logger;
            if (!_loggers.TryGetValue(name, out logger)) {
                lock (lockObject) {
                    if (!_loggers.TryGetValue(name, out logger)) {
                        logger = new AggregateLogger(Providers, name);
                        _loggers[name] = logger;
                    }
                }
            }
            return logger;
        }
    }
}