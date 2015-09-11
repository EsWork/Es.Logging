namespace Es.Logging
{
    public static class Log4Extensions
    {
        public static ILoggerFactory AddLog4net(this ILoggerFactory factory) {
            factory.AddProvider(new Log4LoggerProvider());
            return factory;
        }
    }
}