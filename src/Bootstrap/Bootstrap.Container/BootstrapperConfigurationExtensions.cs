using Orbit.Framework;
using Prism.Ioc;

namespace Orbit.Bootstrap.Container;

public static class BootstrapperConfigurationExtensions
{
    public static void UseUnity(this IBootstrapperConfiguration configuration)
    {
        var container = new Container();

        configuration.RegisterService<IContainer>(() => container);
        configuration.RegisterService<IContainerExtension>(() => container);
    }
}
