namespace Es.Logging
{
    /// <summary>
    /// 此类不是作为单元测试来使用，当使用<see cref="LoggerManager"/>.GetLogger创建日志记录时候，
    /// 可能会遇到预先在类的内部定义了静态的ILogger实例对象，
    /// 如果没有默认的Logger处理器实例，<see cref="LoggerFactory"/>.CreateLogger创建的实例是不带任何Provider的，
    /// 那后面追加Providers也不会更新这个静态的ILogger实例对象
    /// </summary>
    internal class EmptyLoggerProvider : ILoggerProvider
    {

        internal static EmptyLoggerProvider Instance = new EmptyLoggerProvider();

        /// <summary>
        /// 创建一个新的<see cref="EmptyLogger"/>实例
        /// </summary>
        /// <param name="name">日志名</param>
        /// <returns>返回<see cref="ILogger"/></returns>
        public ILogger CreateLogger(string name) {
            return EmptyLogger.Instance;
        }

        /// <summary>
        /// nothing
        /// </summary>
        public void Dispose() {
        }
    }
}