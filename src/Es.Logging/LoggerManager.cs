// ==++==
//
//  Copyright (c) . All rights reserved.
//
// ==--==
/* ---------------------------------------------------------------------------
 *
 * Author			: v.la
 * Email			: v.la@live.cn
 * Created			: 2015-09-11
 * Class			: LoggerManager.cs
 *
 * ---------------------------------------------------------------------------
 * */

namespace Es.Logging
{
    /// <summary>
    /// Class LoggerManager. This class cannot be inherited.
    /// </summary>
    public sealed class LoggerManager
    {
        private static ILoggerFactory _factory = new LoggerFactory();

#if NET45

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