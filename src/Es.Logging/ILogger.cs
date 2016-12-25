using System;

namespace Es.Logging
{
    /// <summary>
    /// 表示一个日志记录接口
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 写到指定的级别日志。
        /// </summary>
        /// <param name="logLevel"><see cref="LogLevel"/></param>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常信息</param>
        void Log(LogLevel logLevel, string message, Exception exception);

        /// <summary>
        /// 检查给定日志级别是否启用。
        /// </summary>
        /// <param name="logLevel"><see cref="LogLevel"/></param>
        /// <returns>指定的日志级别是否启用</returns>
        bool IsEnabled(LogLevel logLevel);
    }
}