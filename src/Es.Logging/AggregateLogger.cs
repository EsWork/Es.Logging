using System;
using System.Collections.Generic;

namespace Es.Logging
{
    /// <summary>
    /// 日志记录的聚合类
    /// </summary>
    internal class AggregateLogger : ILogger
    {
        private readonly string _logName;

        public AggregateLogger(ILoggerProvider[] providers, string logName)
        {
            _logName = logName;
            AddProvider(providers);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            List<Exception>? exceptions = null;
            foreach (var logger in Loggers)
            {
                try
                {
                    if (logger.IsEnabled(logLevel))
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    exceptions ??= new List<Exception>();
                    exceptions.Add(ex);
                }
            }
            if (exceptions != null && exceptions.Count > 0)
            {
                throw new AggregateException(
                    message: "An error occurred while writing to logger(s).",
                    innerExceptions: exceptions);
            }
            return false;
        }

        public void Log(LogLevel logLevel, string message, Exception? exception)
        {
            List<Exception>? exceptions = null;
            foreach (var logger in Loggers)
            {
                try
                {
                    logger.Log(logLevel, message, exception);
                }
                catch (Exception ex)
                {
                    exceptions ??= new List<Exception>();
                    exceptions.Add(ex);
                }
            }
            if (exceptions != null && exceptions.Count > 0)
            {
                throw new AggregateException(
                    message: "An error occurred while writing to logger(s).", innerExceptions: exceptions);
            }
        }

        internal List<ILogger> Loggers { get; } = new List<ILogger>();

        /// <summary>
        /// 添加新的日志记录，如果当前日志记录器已经创建，
        /// 后期可能会追加新的<see cref="ILoggerProvider"/>并且根据日志名创建不同的日志记录方式
        /// </summary>
        /// <param name="providers"></param>
        internal void AddProvider(ILoggerProvider[] providers)
        {
            foreach (var provider in providers)
                Loggers.Add(provider.CreateLogger(_logName));
        }
    }
}