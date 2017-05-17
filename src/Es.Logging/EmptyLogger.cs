using System;

namespace Es.Logging
{
    /// <summary>
    /// EmptyLogger
    /// </summary>
    internal class EmptyLogger : ILogger
    {
        internal static EmptyLogger Instance = new EmptyLogger();

        /// <summary>
        /// nothing
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel)
        {
            return false;
        }

        /// <summary>
        /// nothing
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Log(LogLevel logLevel, string message, Exception exception)
        {
        }
    }
}