using Es.Logging;
using Xunit;

namespace LoggingTest
{
    public class LoggerTest
    {
        [Fact]
        public void Can_AddProvider_Create_Logger()
        {
            var factory = new LoggerFactory();

            var provicer1 = new ConsoleLoggerProvider(LogLevel.Error);
            var provicer2 = new ConsoleLoggerProvider(LogLevel.Debug);

            factory.AddProvider(new[] { provicer1, provicer2 });

            var logger = factory.CreateLogger(this.GetType().Name);

            Assert.True(logger.IsEnabled(LogLevel.Debug));
        }

        [Fact]
        public void Can_Create_Logger_And_Append_Provider_()
        {
            var factory = new LoggerFactory();

            var provicer1 = new ConsoleLoggerProvider(LogLevel.Debug);

            factory.AddProvider(provicer1);

            var logger = factory.CreateLogger<LoggerTest>();

            Assert.True(logger.IsEnabled(LogLevel.Debug));

            var provicer2 = new ConsoleLoggerProvider(LogLevel.Warn);

            //append provider
            factory.AddProvider(provicer2);

            Assert.True(logger.IsEnabled(LogLevel.Warn));
        }
    }
}