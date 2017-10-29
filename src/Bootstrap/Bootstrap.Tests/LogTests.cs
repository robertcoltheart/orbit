using NSubstitute;
using Serilog;
using Xunit;

namespace Orbit.Bootstrap
{
    public class LogTests
    {
        [Fact]
        public void InfoWritesToClient()
        {
            var innerLog = Substitute.For<ILogger>();

            var log = new Logging.Log(innerLog);
            log.Info("msg");

            innerLog.Received().Information("msg");
        }
    }
}
