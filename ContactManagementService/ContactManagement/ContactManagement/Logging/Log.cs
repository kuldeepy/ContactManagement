using System;
using System.Web;
using NLog;

namespace ContactManagement.Logging
{
    public class Log : ILog
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        void ILog.Log(Exception exception)
        {
            logger.Error(exception);
        }
    }
}
