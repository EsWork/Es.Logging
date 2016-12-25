using System;
using System.Globalization;

namespace Es.Logging
{
    /// <summary>
    /// 日志记录的扩展功能
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// 调试指定的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="message">消息内容</param>
        public static void Debug(this ILogger logger, string message) {
            Logger(logger, LogLevel.Debug, message);
        }

        /// <summary>
        /// 调试指定的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="format">格式化内容</param>
        /// <param name="args">格式化参数</param>
        public static void Debug(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Debug, format, args);
        }

        /// <summary>
        /// 跟踪指定的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="message">消息内容</param>
        public static void Trace(this ILogger logger, string message) {
            Logger(logger, LogLevel.Trace, message);
        }

        /// <summary>
        /// 跟踪指定的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="format">格式化内容</param>
        /// <param name="args">格式化参数</param>
        public static void Trace(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Trace, format, args);
        }

        /// <summary>
        /// 输出指定的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="message">消息内容</param>
        public static void Info(this ILogger logger, string message) {
            Logger(logger, LogLevel.Info, message);
        }

        /// <summary>
        /// 输出指定的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="format">格式化内容</param>
        /// <param name="args">格式化参数</param>
        public static void Info(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Info, format, args);
        }

        /// <summary>
        /// 指定警告的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="message">消息内容</param>
        public static void Warn(this ILogger logger, string message) {
            Logger(logger, LogLevel.Warn, message);
        }

        /// <summary>
        /// 指定警告的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="format">格式化内容</param>
        /// <param name="args">格式化参数</param>
        public static void Warn(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Warn, format, args);
        }

        /// <summary>
        /// 指定警告的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="message">消息内容</param>
        /// <param name="error">异常信息</param>
        public static void Warn(this ILogger logger, string message, Exception error) {
            Logger(logger, LogLevel.Warn, message, error);
        }

        /// <summary>
        /// 指定警告的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="error">异常信息</param>
        public static void Warn(this ILogger logger, Exception error) {
            Logger(logger, LogLevel.Warn, error.Message, error);
        }

        /// <summary>
        /// 指定错误的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="message">消息内容</param>
        public static void Error(this ILogger logger, string message) {
            Logger(logger, LogLevel.Error, message);
        }

        /// <summary>
        /// 指定错误的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="format">格式化内容</param>
        /// <param name="args">格式化参数</param>
        public static void Error(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Error, format, args);
        }

        /// <summary>
        /// 指定错误的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="message">消息内容</param>
        /// <param name="error">异常信息</param>
        public static void Error(this ILogger logger, string message, Exception error) {
            Logger(logger, LogLevel.Error, message, error);
        }

        /// <summary>
        /// 指定错误的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="error">异常信息</param>
        public static void Error(this ILogger logger, Exception error) {
            Logger(logger, LogLevel.Error, error.Message, error);
        }

        /// <summary>
        /// 指定严重的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="message">消息内容</param>
        public static void Fatal(this ILogger logger, string message) {
            Logger(logger, LogLevel.Fatal, message);
        }

        /// <summary>
        /// 指定严重的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="format">格式化内容</param>
        /// <param name="args">格式化参数</param>
        public static void Fatal(this ILogger logger, string format, params object[] args) {
            Logger(logger, LogLevel.Fatal, format, args);
        }

        /// <summary>
        /// 指定严重的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="message">消息内容</param>
        /// <param name="error">异常信息</param>
        public static void Fatal(this ILogger logger, string message, Exception error) {
            Logger(logger, LogLevel.Fatal, message, error);
        }

        /// <summary>
        /// 指定严重的日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="error">异常信息</param>
        public static void Fatal(this ILogger logger, Exception error) {
            Logger(logger, LogLevel.Fatal, error.Message, error);
        }

        /// <summary>
        /// 根据日志级别指定日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="logLevel">日志级别</param>
        /// <param name="message">消息内容</param>
        private static void Logger(ILogger logger, LogLevel logLevel, string message) {
            logger.Log(logLevel, message, null);
        }

        /// <summary>
        /// 根据日志级别指定日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="logLevel">日志级别</param>
        /// <param name="format">格式化内容</param>
        /// <param name="args">格式化参数</param>
        private static void Logger(ILogger logger, LogLevel logLevel, string format, params object[] args) {
            logger.Log(logLevel,
                string.Format(CultureInfo.InvariantCulture, format, args), null);
        }

        /// <summary>
        /// 根据日志级别指定日志消息
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="logLevel">日志级别</param>
        /// <param name="message">消息内容</param>
        /// <param name="error">异常信息</param>
        private static void Logger(ILogger logger, LogLevel logLevel, string message, Exception error) {
            logger.Log(logLevel, message, error);
        }
    }
}