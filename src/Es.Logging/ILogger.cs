using System;

namespace Es.Logging
{
    /// <summary>
    /// Provides logging interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes the specified log level.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Log(LogLevel logLevel, string message, Exception exception);

        /// <summary>
        /// Checks if the given LogLevel is enabled.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <returns><c>true</c> if the specified log level is enabled; otherwise, <c>false</c>.</returns>
        bool IsEnabled(LogLevel logLevel);
    }
}