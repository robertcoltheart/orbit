using Orbit.Framework;

namespace Orbit.Bootstrap.Container
{
    public static class BootstrapperConfigurationExtensions
    {
        public static void UseUnity(this IBootstrapperConfiguration configuration)
        {
            configuration.RegisterService<IContainer>(() => new Container());
        }
    }
}
