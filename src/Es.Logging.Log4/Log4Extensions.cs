namespace Es.Logging
{
    public static class Log4Extensions
    {
        public static LoggerFactory AddLog4net(this LoggerFactory factory)
        {
            factory.AddProvider(new Log4LoggerProvider());
            return factory;
        }
    }
}