using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Transversal.Common
{
    public class NLogLogger : ILogger
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Error(string message, Exception ex = null)
        {
            if (ex == null)
                _logger.Error(message);
            else
                _logger.Error(ex, message);
        }

        public void Fatal(string message, Exception ex = null)
        {
            if (ex == null)
                _logger.Fatal(message);
            else
                _logger.Fatal(ex, message);
        }
    }
}
