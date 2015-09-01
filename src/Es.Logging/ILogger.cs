// ==++==
//
//  Copyright (c) . All rights reserved.
//
// ==--==
/* ---------------------------------------------------------------------------
 *
 * Author			: v.la
 * Email			: v.la@live.cn
 * Created			: 2015-09-01
 * Class			: ILogger.cs
 *
 * ---------------------------------------------------------------------------
 * */

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
        void Write(LogLevel logLevel, string message, Exception exception);

        /// <summary>
        /// Determines whether the specified log level is enabled.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <returns><c>true</c> if the specified log level is enabled; otherwise, <c>false</c>.</returns>
        bool IsEnabled(LogLevel logLevel);
    }
}