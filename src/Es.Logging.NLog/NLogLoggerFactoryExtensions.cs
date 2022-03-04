using System.IO;
using System.Reflection;
using NLog;
using NLog.Config;

namespace Es.Logging
{
    /// <summary>
    /// NLogLoggerFactoryExtensions
    /// </summary>
    public static class NLogLoggerFactoryExtensions
    {
        /// <summary>
        /// Enable NLog as logging provider
        /// </summary>
        /// <param name="factory"><see cref="ILoggerFactory"/></param>
        /// <param name="fileName">Configuration file to be read.</param>
        /// <returns></returns>
        public static ILoggerFactory AddNLog(this ILoggerFactory factory, string fileName = "")
        {
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                LogManager.Configuration = new XmlLoggingConfiguration(fileName);
            }

#if NET462
            LogManager.AddHiddenAssembly(typeof(NLogLoggerFactoryExtensions).Assembly);
#else
            LogManager.AddHiddenAssembly(typeof(NLogLoggerFactoryExtensions).GetTypeInfo().Assembly);
#endif

            using (var provider = new NLogLoggerProvider())
            {
                factory.AddProvider(provider);
            }

            return factory;
        }

        /// <summary>
        /// Enable NLog as logging provider
        /// </summary>
        /// <param name="factory"><see cref="ILoggerFactory"/></param>
        /// <param name="logFactory"><see cref="LogFactory"/></param>
        /// <returns></returns>
        public static ILoggerFactory AddNLog(this ILoggerFactory factory, LogFactory logFactory)
        {
            factory.AddProvider(new NLogLoggerProvider(logFactory));
            return factory;
        }
    }
}