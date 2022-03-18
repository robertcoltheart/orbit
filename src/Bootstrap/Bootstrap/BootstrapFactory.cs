using System.Diagnostics;
using System.Reactive.Subjects;
using Orbit.Bootstrap.Bootstrappers;
using Orbit.Framework;

namespace Orbit.Bootstrap;

public static class BootstrapFactory
{
    public static void Run(Action<IBootstrapperConfiguration> configurationAction)
    {
        var configuration = new BootstrapperConfiguration();
        configurationAction(configuration);

        var bootstrapper = CreateBootstrapper(configuration);
        bootstrapper.Run();
    }

    private static IBootstrapper CreateBootstrapper(BootstrapperConfiguration configuration)
    {
        var shellEvents = new Subject<ShellEvent>();
        var errorEvents = new Subject<Exception>();

        var bootstrapper = CreatePrismBootstrapper(configuration);

        if (!Debugger.IsAttached)
        {
            bootstrapper = new UnhandledExceptionBootstrapper(bootstrapper, errorEvents.OnNext);
            bootstrapper = new UnobservedTaskExceptionBootstrapper(bootstrapper, errorEvents.OnNext);
        }

        return bootstrapper;
    }

    private static IBootstrapper CreatePrismBootstrapper(BootstrapperConfiguration configuration)
    {
        return new PrismBootstrapper(configuration);
    }
}
