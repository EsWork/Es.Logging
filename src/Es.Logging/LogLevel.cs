namespace Es.Logging
{
    /// <summary>
    /// 定义了可用的日志级别
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 包含最详细的日志信息。这些消息可能包含敏感的应用程序数据。这些消息都是默认禁用的,不应该在生产环境中启用。
        /// </summary>
        Trace = 1,

        /// <summary>
        /// 在开发过程中日志用于交互式调查。这些日志应该主要包含有用的调试信息。
        /// </summary>
        Debug = 2,

        /// <summary>
        /// 日志跟踪应用程序的通用流。这些日志应该长期显示。
        /// </summary>
        Info = 3,

        /// <summary>
        /// 应用程序流的异常或意外事件,但不会导致应用程序停止执行。
        /// </summary>
        Warn = 4,

        /// <summary>
        /// 强调在当前流的执行停止时由于失败。这些应该显示当前活动的失败,不是一个应用程序失败。
        /// </summary>
        Error = 5,

        /// <summary>
        /// 日志描述一个不可恢复的应用程序或系统崩溃,或者一个灾难性故障,需要立即注意。
        /// </summary>
        Fatal = 6,
    }
}