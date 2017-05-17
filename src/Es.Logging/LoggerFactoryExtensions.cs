namespace Es.Logging
{
    /// <summary>
    /// Logger Factory Extensions
    /// </summary>
    public static class LoggerFactoryExtensions
    {
        /// <summary>
        /// 创建日志记录实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory"><see cref="ILoggerFactory"/></param>
        /// <returns><see cref="ILogger"/></returns>
        public static ILogger CreateLogger<T>(this ILoggerFactory factory)
        {
            return factory.CreateLogger(typeof(T).FullName);
        }
    }
}