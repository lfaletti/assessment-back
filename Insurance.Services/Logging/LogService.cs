using System;
using Insurance.IServices.ILogging;

namespace Insurance.Services.Logging
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