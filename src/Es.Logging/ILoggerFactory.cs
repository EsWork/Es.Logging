namespace Es.Logging
{
    /// <summary>
    /// 日志工厂接口
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// 创建日志记录实例
        /// </summary>
        /// <param name="name">定义日志的名称</param>
        /// <returns><see cref="ILogger"/></returns>
        ILogger CreateLogger(string name);
    }
}