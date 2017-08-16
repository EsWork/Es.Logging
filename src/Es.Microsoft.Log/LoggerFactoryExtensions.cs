using MS = Microsoft.Extensions.Logging;

namespace Es.Logging
{
    public static class LoggerFactoryExtensions
    {
        public static ILoggerFactory AddMicrosoftLog(this ILoggerFactory factory,
            MS.ILoggerFactory logFactory)
        {
            factory.AddProvider(new LoggerProvider(logFactory));
            return factory;
        }
    }
}