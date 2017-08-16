namespace Es.Logging
{
    /// <summary>
    /// 日志记录管理
    /// </summary>
    [System.Obsolete("请使用Es.Logging.LoggerFactory实例")]
    public sealed class LoggerManager
    {

#if NETFULL || NETSTANDARD2_0

        /// <summary>
        /// 根据当前类名创建一个日志记录实例
        /// </summary>
        /// <returns><see cref="ILogger"/></returns>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public static ILogger GetCurrentClassLogger() {
            System.Diagnostics.StackFrame frame = new System.Diagnostics.StackFrame(1, false);
            return LoggerFactory.Factory.CreateLogger(frame.GetMethod().DeclaringType.FullName);
        }

#endif


        /// <summary>
        /// 提供全局单<see cref="LoggerFactory"/>实例使用
        /// </summary>
        public static LoggerFactory Factory {
            get {
                return LoggerFactory.Factory;
            }
        }

        /// <summary>
        /// 根据名称创建一个日志记录实例
        /// </summary>
        /// <param name="name">日志名称</param>
        /// <returns><see cref="ILogger"/></returns>
        public static ILogger GetLogger(string name)
        {
            return LoggerFactory.Factory.CreateLogger(name);
        }

        /// <summary>
        /// 根据泛型参数类型创建一个日志记录实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="ILogger"/></returns>
        public static ILogger GetLogger<T>()
        {
            return LoggerFactory.Factory.CreateLogger<T>();
        }
    }
}