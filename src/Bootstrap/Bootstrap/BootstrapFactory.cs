using System;

namespace Orbit.Bootstrap
{
    public static class BootstrapFactory
    {
        public static void Run(Action<IBootstrapperConfiguration> configurationAction)
        {
            var configuration = new BootstrapperConfiguration();
            configurationAction(configuration);

            var bootstrapper = new Bootstrapper(configuration);
            bootstrapper.Run();
        }
    }
}
