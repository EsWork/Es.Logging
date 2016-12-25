using NLog;

namespace Es.Logging
{
    public static class NLogLoggerFactoryExtensions
    {
        public static ILoggerFactory AddNLog(this ILoggerFactory factory) {
            factory.AddProvider(new NLogLoggerProvider());
            return factory;
        }

        public static ILoggerFactory AddNLog(this ILoggerFactory factory, LogFactory logFactory) {
            factory.AddProvider(new NLogLoggerProvider(logFactory));
            return factory;
        }
    }
}