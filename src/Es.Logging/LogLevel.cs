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
 * Class			: LogLevel.cs
 *
 * ---------------------------------------------------------------------------
 * */

namespace Es.Logging
{
    /// <summary>
    /// Defines available log levels.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Trace log level.
        /// </summary>
        Trace = 1,

        /// <summary>
        /// Debug log level.
        /// </summary>
        Debug = 2,

        /// <summary>
        /// Info log level.
        /// </summary>
        Info = 3,

        /// <summary>
        /// Warn log level.
        /// </summary>
        Warn = 4,

        /// <summary>
        /// Error log level.
        /// </summary>
        Error = 5,

        /// <summary>
        /// Fatal log level.
        /// </summary>
        Fatal = 6,
    }
}