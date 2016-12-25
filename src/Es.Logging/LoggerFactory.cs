using System.Collections.Generic;

namespace Es.Logging
{
    /// <summary>
    /// 基于工厂创建日志记录实例
    /// </summary>
    public class LoggerFactory : ILoggerFactory
    {
        private readonly object lockObject = new object();


        internal readonly Dictionary<string, AggregateLogger> Loggers = new Dictionary<string, AggregateLogger>();

        /// <summary>
        /// 创建日志记录实例的提供者集合
        /// </summary>
        public readonly List<ILoggerProvider> Providers = new List<ILoggerProvider>
        {
            EmptyLoggerProvider.Instance
        };

        /// <summary>
        /// 添加创建日志记录实例的提供者
        /// </summary>
        /// <param name="providers">用于创建日志记录实例的提供者</param>
        public void AddProvider(ILoggerProvider[] providers) {
            lock (lockObject) {
                Providers.AddRange(providers);
                //添加用于创建日志记录实例的提供者时，将已创建的日志记录集合追加新的日志提供者，
                //这样我们可以确保每个日志记录实例包含完整多个不同的实现，
                foreach (var logger in Loggers) {
                    logger.Value.AddProvider(providers);
                }
            }
        }

        /// <summary>
        /// 创建日志记录实例
        /// </summary>
        /// <param name="name">定义日志的名称</param>
        /// <returns><see cref="ILogger"/></returns>
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