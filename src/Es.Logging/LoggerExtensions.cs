using System;
using System.Globalization;

namespace Es.Logging
{
    public static class LoggerExtensions
    {
        public static void Debug(this ILogger logger, string message) {
            Logger(logger, LogLevel.Debug, message);
        }

        public static void Debug(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Debug, format, args);
        }

        public static void Trace(this ILogger logger, string message) {
            Logger(logger, LogLevel.Trace, message);
        }

        public static void Trace(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Trace, format, args);
        }

        public static void Info(this ILogger logger, string message) {
            Logger(logger, LogLevel.Info, message);
        }

        public static void Info(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Info, format, args);
        }

        public static void Warn(this ILogger logger, string message) {
            Logger(logger, LogLevel.Warn, message);
        }

        public static void Warn(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Warn, format, args);
        }

        public static void Warn(this ILogger logger, string message, Exception error) {
            Logger(logger, LogLevel.Warn, message, error);
        }

        public static void Error(this ILogger logger, string message) {
            Logger(logger, LogLevel.Error, message);
        }

        public static void Error(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Error, format, args);
        }

        public static void Error(this ILogger logger, string message, Exception error) {
            Logger(logger, LogLevel.Error, message, error);
        }

        public static void Fatal(this ILogger logger, string message) {
            Logger(logger, LogLevel.Fatal, message);
        }

        public static void Fatal(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Fatal, format, args);
        }

        public static void Fatal(this ILogger logger, string message, Exception error) {
            Logger(logger, LogLevel.Fatal, message, error);
        }

        private static void Logger(ILogger logger, LogLevel logLevel, string message) {
            logger.Log(logLevel, message, null);
        }

        private static void Logger(ILogger logger, LogLevel logLevel, string format, params object[] args) {
            logger.Log(logLevel,
                string.Format(CultureInfo.InvariantCulture, format, args), null);
        }

        private static void Logger(ILogger logger, LogLevel logLevel, string message, Exception error) {
            logger.Log(logLevel, message, error);
        }
    }
}