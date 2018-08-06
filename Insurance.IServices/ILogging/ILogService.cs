using System;

namespace Insurance.Services.Logging
{
    public interface ILogService
    {
        void Log(string msg);
        void Log(Exception ex);
    }
}
