namespace Es.Logging
{
    /// <summary>
    /// Class LoggerManager. This class cannot be inherited.
    /// </summary>
    public sealed class LoggerManager
    {
        private static ILoggerFactory _factory = new LoggerFactory();

#if NETFULL

        /// <summary>
        /// Gets the current class logger.
        /// </summary>
        /// <returns>ILogger.</returns>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public static ILogger GetCurrentClassLogger() {

            System.Diagnostics.StackFrame frame = new System.Diagnostics.StackFrame(1, false);
            return Factory.CreateLogger(frame.GetMethod().DeclaringType.FullName);
        }

#endif

        /// <summary>
        /// Sets the logger factory.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public static void SetLoggerFactory(ILoggerFactory factory) {

            if (factory is LoggerFactory) {
                //transfer logger
                var factoryOld = _factory as LoggerFactory;
                var factoryNew = factory as LoggerFactory;

                foreach (var entry in factoryOld.Loggers) {
                    entry.Value.Loggers.Clear();
                    entry.Value.AddProvider(factoryNew.Providers.ToArray());
                    factoryNew.Loggers.Add(entry.Key, entry.Value);
                }

                factoryOld.Loggers.Clear();
                factoryOld.Providers.Clear();
                factoryOld = null;

            }
            _factory = factory;
        }

        /// <summary>
        /// Gets the factory.
        /// </summary>
        /// <value>The factory.</value>
        public static ILoggerFactory Factory
        {
            get
            {
                return _factory;
            }
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ILogger.</returns>
        public static ILogger GetLogger(string name) {
            return Factory.CreateLogger(name);
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>ILogger.</returns>
        public static ILogger GetLogger<T>() {
            return Factory.CreateLogger<T>();
        }
    }
}