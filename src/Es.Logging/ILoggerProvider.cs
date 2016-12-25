using System;

namespace Es.Logging
{
    /// <summary>
    /// 用于创建日志记录实例
    /// </summary>
    public interface ILoggerProvider : IDisposable
    {
        /// <summary>
        /// 创建一个新的<see cref="ILogger"/>实例
        /// </summary>
        /// <param name="name">日志名</param>
        /// <returns>返回<see cref="ILogger"/></returns>
        ILogger CreateLogger(string name);
    }
}