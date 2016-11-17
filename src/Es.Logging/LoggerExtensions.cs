using System;
using System.Globalization;

namespace Es.Logging
{
    /// <summary>
    /// Logger Extensions Function.
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        public static void Debug(this ILogger logger, string message) {
            Logger(logger, LogLevel.Debug, message);
        }

        /// <summary>
        /// Debugs the specified format.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void Debug(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Debug, format, args);
        }

        /// <summary>
        /// Traces the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        public static void Trace(this ILogger logger, string message) {
            Logger(logger, LogLevel.Trace, message);
        }

        /// <summary>
        /// Traces the specified format.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void Trace(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Trace, format, args);
        }

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        public static void Info(this ILogger logger, string message) {
            Logger(logger, LogLevel.Info, message);
        }

        /// <summary>
        /// Informations the specified format.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void Info(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Info, format, args);
        }

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        public static void Warn(this ILogger logger, string message) {
            Logger(logger, LogLevel.Warn, message);
        }

        /// <summary>
        /// Warns the specified format.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void Warn(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Warn, format, args);
        }

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="error">The error.</param>
        public static void Warn(this ILogger logger, string message, Exception error) {
            Logger(logger, LogLevel.Warn, message, error);
        }

        /// <summary>
        /// Warns the specified error.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="error">The error.</param>
        public static void Warn(this ILogger logger, Exception error) {
            Logger(logger, LogLevel.Warn, error.Message, error);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        public static void Error(this ILogger logger, string message) {
            Logger(logger, LogLevel.Error, message);
        }

        /// <summary>
        /// Errors the specified format.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void Error(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Error, format, args);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="error">The error.</param>
        public static void Error(this ILogger logger, string message, Exception error) {
            Logger(logger, LogLevel.Error, message, error);
        }

        /// <summary>
        /// Errors the specified error.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="error">The error.</param>
        public static void Error(this ILogger logger, Exception error) {
            Logger(logger, LogLevel.Error, error.Message, error);
        }

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        public static void Fatal(this ILogger logger, string message) {
            Logger(logger, LogLevel.Fatal, message);
        }

        /// <summary>
        /// Fatals the specified format.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void Fatal(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Fatal, format, args);
        }

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="error">The error.</param>
        public static void Fatal(this ILogger logger, string message, Exception error) {
            Logger(logger, LogLevel.Fatal, message, error);
        }

        /// <summary>
        /// Fatals the specified error.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="error">The error.</param>
        public static void Fatal(this ILogger logger, Exception error) {
            Logger(logger, LogLevel.Fatal, error.Message, error);
        }

        /// <summary>
        /// Loggers the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="logLevel">The log level.</param>
        /// <param name="message">The message.</param>
        private static void Logger(ILogger logger, LogLevel logLevel, string message) {
            logger.Log(logLevel, message, null);
        }

        /// <summary>
        /// Loggers the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="logLevel">The log level.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        private static void Logger(ILogger logger, LogLevel logLevel, string format, params object[] args) {
            logger.Log(logLevel,
                string.Format(CultureInfo.InvariantCulture, format, args), null);
        }

        /// <summary>
        /// Loggers the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="logLevel">The log level.</param>
        /// <param name="message">The message.</param>
        /// <param name="error">The error.</param>
        private static void Logger(ILogger logger, LogLevel logLevel, string message, Exception error) {
            logger.Log(logLevel, message, error);
        }
    }
}