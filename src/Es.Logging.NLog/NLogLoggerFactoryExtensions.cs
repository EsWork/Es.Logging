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
        /// <param name="factory"><see cref="LoggerFactory"/></param>
        /// <param name="fileName">Configuration file to be read.</param>
        /// <returns></returns>
        public static LoggerFactory AddNLog(this LoggerFactory factory, string fileName = "")
        {
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                LogManager.Configuration = new XmlLoggingConfiguration(fileName, true);
            }

#if NETFULL
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
        /// <param name="factory"><see cref="LoggerFactory"/></param>
        /// <param name="logFactory"><see cref="LogFactory"/></param>
        /// <returns></returns>
        public static LoggerFactory AddNLog(this LoggerFactory factory, LogFactory logFactory)
        {
            factory.AddProvider(new NLogLoggerProvider(logFactory));
            return factory;
        }
    }
}