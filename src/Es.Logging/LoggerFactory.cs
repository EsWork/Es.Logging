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
        /// <see cref="LoggerFactory"/>
        /// </summary>
        public readonly static LoggerFactory Factory = new LoggerFactory();

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
        public void AddProvider(params ILoggerProvider[] providers)
        {
            lock (lockObject)
            {
                Providers.AddRange(providers);
                //添加用于创建日志记录实例的提供者时，将已创建的日志记录集合追加新的日志提供者，
                //这样我们可以确保每个日志记录实例包含完整多个不同的实现，
                foreach (var logger in Loggers)
                {
                    logger.Value.AddProvider(providers);
                }
            }
        }

        /// <summary>
        /// 创建日志记录实例
        /// </summary>
        /// <param name="name">定义日志的名称</param>
        /// <returns><see cref="ILogger"/></returns>
        public ILogger CreateLogger(string name)
        {
            if (!Loggers.TryGetValue(name, out AggregateLogger logger))
            {
                lock (lockObject)
                {
                    if (!Loggers.TryGetValue(name, out logger))
                    {
                        logger = new AggregateLogger(Providers.ToArray(), name);
                        Loggers[name] = logger;
                    }
                }
            }
            return logger;
        }


#if NETFULL

        /// <summary>
        /// 根据当前类名创建一个日志记录实例
        /// </summary>
        /// <returns><see cref="ILogger"/></returns>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public static ILogger GetCurrentClassLogger() {
            System.Diagnostics.StackFrame frame = new System.Diagnostics.StackFrame(1, false);
            return Factory.CreateLogger(frame.GetMethod().DeclaringType.FullName);
        }

#endif

        /// <summary>
        /// 根据名称创建一个日志记录实例
        /// </summary>
        /// <param name="name">日志名称</param>
        /// <returns><see cref="ILogger"/></returns>
        public static ILogger GetLogger(string name)
        {
            return Factory.CreateLogger(name);
        }

        /// <summary>
        /// 根据泛型参数类型创建一个日志记录实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="ILogger"/></returns>
        public static ILogger GetLogger<T>()
        {
            return Factory.CreateLogger<T>();
        }
    }
}