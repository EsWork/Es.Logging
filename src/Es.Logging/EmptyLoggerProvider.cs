namespace Es.Logging
{
    /// <summary>
    /// Used Take
    /// </summary>
    public class EmptyLoggerProvider : ILoggerProvider
    {
        /// <summary>
        /// nothing
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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