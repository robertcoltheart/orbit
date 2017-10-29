using Orbit.Framework;
using Serilog;
using Serilog.Core;

namespace Orbit.Bootstrap.Logging
{
    public class Log : ILog
    {
        private readonly Logger _logger = new LoggerConfiguration().CreateLogger();

        public void Info(string message)
        {
            _logger.Information(message);
        }
    }
}
