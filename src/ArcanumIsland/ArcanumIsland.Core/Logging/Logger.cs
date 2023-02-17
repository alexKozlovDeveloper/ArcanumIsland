using log4net.Config;
using log4net.Core;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.Logging
{
    public class Logger : ILogger
    {
        private static ILog _logger;

        public Logger() 
        {
            if (_logger == null) 
            {
                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
                _logger = LogManager.GetLogger(typeof(LoggerManager));
            }
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(Exception e)
        {
            _logger.Error(e.Message);
        }
    }
}
