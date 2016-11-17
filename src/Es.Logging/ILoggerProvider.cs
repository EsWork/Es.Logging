using System;

namespace Es.Logging
{
    /// <summary>
    /// Used to create logger instances
    /// </summary>
    public interface ILoggerProvider : IDisposable
    {
        /// <summary>
        /// Creates a new ILogger instance of the given name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ILogger.</returns>
        ILogger CreateLogger(string name);
    }
}