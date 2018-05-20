using System;

namespace Microsoft.Extensions.Logging
{
    /// <summary>
    /// Microsoft Logger Extensions
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        public static void Error(this ILogger logger, string message)
        {
            logger.LogError(0, message);
        }

        /// <summary>
        /// Errors the specified format.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void Error(this ILogger logger, string format, params object[] args)
        {
            logger.LogError(0, format, args);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="error">The error.</param>
        public static void Error(this ILogger logger, string message, Exception error)
        {
            logger.LogError(0, error, message);
        }

        /// <summary>
        /// Errors the specified error.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="error">The error.</param>
        public static void Error(this ILogger logger, Exception error)
        {
            logger.LogError(0, error, error.Message);
        }

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        public static void Warn(this ILogger logger, string message)
        {
            logger.LogWarning(0, message);
        }

        /// <summary>
        /// Warns the specified format.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void Warn(this ILogger logger, string format, params object[] args)
        {
            logger.LogWarning(0, format, args);
        }

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="error">The error.</param>
        public static void Warn(this ILogger logger, string message, Exception error)
        {
            logger.LogWarning(0, error, message);
        }

        /// <summary>
        /// Warns the specified error.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="error">The error.</param>
        public static void Warn(this ILogger logger, Exception error)
        {
            logger.LogWarning(0, error, error.Message);
        }

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        public static void Fatal(this ILogger logger, string message)
        {
            logger.LogCritical(0, message);
        }

        /// <summary>
        /// Fatals the specified format.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void Fatal(this ILogger logger, string format, params object[] args)
        {
            logger.LogCritical(0, format, args);
        }

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="error">The error.</param>
        public static void Fatal(this ILogger logger, string message, Exception error)
        {
            logger.LogCritical(0, error, message);
        }

        /// <summary>
        /// Fatals the specified error.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="error">The error.</param>
        public static void Fatal(this ILogger logger, Exception error)
        {
            logger.LogCritical(0, error, error.Message);
        }
    }
}