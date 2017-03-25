namespace Es.Logging
{
    public class Log4LoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string name) {
            return new Log4(log4net.LogManager.GetLogger("Default", name));
        }

        public void Dispose() {
            log4net.LogManager.Shutdown();
        }
    }
}