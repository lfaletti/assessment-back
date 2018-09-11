using System;
using Insurance.ApiProviders.ILogging;

namespace Insurance.ApiProviders.Logging
{
    /// <summary>
    ///     Implement some logging...
    /// </summary>
    public class LogService : ILogService
    {
        public void Log(string msg)
        {
            throw new NotImplementedException();
        }

        public void Log(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}