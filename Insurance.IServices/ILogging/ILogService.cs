using System;

namespace Insurance.IServices.ILogging
{
    public interface ILogService
    {
        void Log(string msg);
        void Log(Exception ex);
    }
}