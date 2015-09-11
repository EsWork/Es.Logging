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

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Es.Logging
{
    /// <summary>
    /// Class LoggerManager. This class cannot be inherited.
    /// </summary>
    public sealed class LoggerManager
    {
        private static ILoggerFactory _factory = new LoggerFactory();

        /// <summary>
        /// Gets the current class logger.
        /// </summary>
        /// <returns>ILogger.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ILogger GetCurrentClassLogger() {
#if SL
            StackFrame frame = new StackTrace(1);
#else
            StackFrame frame = new StackFrame(1, false);
#endif
            return Factory.CreateLogger(frame.GetMethod().DeclaringType.FullName);
        }

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
        public static ILoggerFactory Factory {
            get {
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