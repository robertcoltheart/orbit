using Orbit.Framework;
using Serilog;

namespace Orbit.Bootstrap.Logging
{
    public class Log : ILog
    {
        private readonly ILogger _logger;

        public Log(ILogger logger)
        {
            _logger = logger;
        }

        public void Info(string message)
        {
            _logger.Information(message);
        }
    }
}
