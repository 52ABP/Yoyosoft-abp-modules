using System;
using System.IO;
using System.Xml;
using Abp.Reflection.Extensions;
using Castle.Core.Logging;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace YoYo.Castle.Logging.Log4Net
{
    /// <summary>
    /// 
    /// </summary>
    public class Log4NetLoggerFactory : AbstractLoggerFactory
    {
        internal const string DefaultConfigFileName = "log4net.config";
        private readonly ILoggerRepository _loggerRepository;

        /// <summary>
        /// 
        /// </summary>
        public Log4NetLoggerFactory()
            : this(DefaultConfigFileName)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFileName"></param>
        public Log4NetLoggerFactory(string configFileName)
        {
            _loggerRepository = LogManager.CreateRepository(
                typeof(Log4NetLoggerFactory).GetAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy)
            );

            var log4NetConfig = new XmlDocument();
            log4NetConfig.Load(File.OpenRead(configFileName));
            XmlConfigurator.Configure(_loggerRepository, log4NetConfig["log4net"]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFileName"></param>
        /// <param name="reloadOnChange"></param>
        public Log4NetLoggerFactory(string configFileName, bool reloadOnChange)
        {
            _loggerRepository = LogManager.CreateRepository(
                typeof(Log4NetLoggerFactory).GetAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy)
            );

            if (reloadOnChange)
            {
                XmlConfigurator.ConfigureAndWatch(_loggerRepository, new FileInfo(configFileName));
            }
            else
            {
                var log4NetConfig = new XmlDocument();
                log4NetConfig.Load(File.OpenRead(configFileName));
                XmlConfigurator.Configure(_loggerRepository, log4NetConfig["log4net"]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override ILogger Create(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new Log4NetLogger(LogManager.GetLogger(_loggerRepository.Name, name), this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public override ILogger Create(string name, LoggerLevel level)
        {
            throw new NotSupportedException("Logger levels cannot be set at runtime. Please review your configuration file.");
        }
    }
}