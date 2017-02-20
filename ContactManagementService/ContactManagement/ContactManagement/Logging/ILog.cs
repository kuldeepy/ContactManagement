using System;
using System.Web;

namespace ContactManagement.Logging
{
    public interface ILog
    {
        void Log(Exception exception);
    }
}
