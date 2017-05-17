using MS = Microsoft.Extensions.Logging;

namespace Es.Logging
{
    public static class LoggerFactoryExtensions
    {
        public static LoggerFactory AddMicrosoftLog(this LoggerFactory factory,
            MS.LoggerFactory logFactory)
        {
            factory.AddProvider(new LoggerProvider(logFactory));
            return factory;
        }
    }
}