using System;

namespace Insurance.ApiProviders.ILogging
{
    public interface ILogService
    {
        void Log(string msg);
        void Log(Exception ex);
    }
}