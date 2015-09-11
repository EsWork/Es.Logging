// ==++==
//
//  Copyright (c) . All rights reserved.
//
// ==--==
/* ---------------------------------------------------------------------------
 *
 * Author			: v.la
 * Email			: v.la@live.cn
 * Created			: 2015-09-02
 * Class			: LoggerFactoryExtensions.cs
 *
 * ---------------------------------------------------------------------------
 * */

namespace Es.Logging
{
    /// <summary>
    /// Class LoggerFactoryExtensions.
    /// </summary>
    public static class LoggerFactoryExtensions
    {
        /// <summary>
        /// Adds the provider.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="provider">The provider.</param>
        public static void AddProvider(this ILoggerFactory factory, ILoggerProvider provider) {
            factory.AddProvider(new[] { provider });
        }

        /// <summary>
        /// Creates the logger.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory">The factory.</param>
        /// <returns>ILogger.</returns>
        public static ILogger CreateLogger<T>(this ILoggerFactory factory) {
            return factory.CreateLogger(typeof(T).FullName);
        }
    }
}