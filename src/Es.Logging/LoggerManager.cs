namespace Es.Logging
{
    /// <summary>
    /// 日志记录管理
    /// </summary>
    public sealed class LoggerManager
    {
        private static ILoggerFactory _factory = new LoggerFactory();

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
        /// 替换全局日志工厂，已创建的日志记录实例会切换到新的日志工厂下
        /// （新的<see cref="ILoggerFactory"/>需要基于<see cref="LoggerFactory"/>实现才会支持切换功能）
        /// </summary>
        /// <param name="factory">需要替换的<see cref="ILoggerFactory"/></param>
        public static void SetLoggerFactory(ILoggerFactory factory) {

            if (factory is LoggerFactory) {

                var factoryOld = _factory as LoggerFactory;
                var factoryNew = factory as LoggerFactory;

                foreach (var entry in factoryOld.Loggers) {
                    //清空日志聚合的日志记录实例数据
                    entry.Value.Loggers.Clear();
                    //然后追加新的日志提供者用于创建新的日志记录实例
                    entry.Value.AddProvider(factoryNew.Providers.ToArray());

                    //把旧的日志记录器实例切换到新的上面
                    factoryNew.Loggers.Add(entry.Key, entry.Value);
                }

                //清理旧的资源
                factoryOld.Loggers.Clear();
                factoryOld.Providers.Clear();
                factoryOld = null;

            }
            _factory = factory;
        }

        /// <summary>
        /// 提供全局单<see cref="ILoggerFactory"/>实例使用
        /// </summary>
        public static ILoggerFactory Factory
        {
            get
            {
                return _factory;
            }
        }

        /// <summary>
        /// 根据名称创建一个日志记录实例
        /// </summary>
        /// <param name="name">日志名称</param>
        /// <returns><see cref="ILogger"/></returns>
        public static ILogger GetLogger(string name) {
            return Factory.CreateLogger(name);
        }

        /// <summary>
        /// 根据泛型参数类型创建一个日志记录实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="ILogger"/></returns>
        public static ILogger GetLogger<T>() {
            return Factory.CreateLogger<T>();
        }
    }
}