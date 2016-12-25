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

        /// <summary>
        /// 添加创建日志记录实例的提供者
        /// </summary>
        /// <param name="providers">用于创建日志记录实例的提供者</param>
        void AddProvider(ILoggerProvider[] providers);
    }
}