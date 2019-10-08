using Prism.Ioc;
using Prism.Modularity;

namespace Orbit.Modules.Orders
{
    public class OrdersModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.IsRegistered(typeof(object));
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }
    }
}
