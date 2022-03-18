using Orbit.Bootstrap;
using Prism.Ioc;

namespace Orbit.Extensions.DependencyInjection;

public static class BootstrapperConfigurationExtensions
{
    public static void UseDependencyInjection(this IBootstrapperConfiguration configuration)
    {
        var container = new DependencyInjectionContainerExtension();

        configuration.RegisterService<IContainerExtension>(() => container);
    }
}
