using System.Windows;
using Orbit.Framework;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Orbit.Bootstrap
{
    public class Bootstrapper : IBootstrapper
    {
        private readonly BootstrapperConfiguration configuration;

        public Bootstrapper(BootstrapperConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Run()
        {
            var container = configuration.ResolveService<IContainer>();

            container
                .Register(container)
                .Register(configuration.ModuleCatalog)
                .Register(container.Resolve<IContainerExtension>())
                .Register<IModuleInitializer, ModuleInitializer>()
                .Register<IModuleManager, ModuleManager>()
                .Register<IRegionManager, RegionManager>()
                .Register<IRegionBehaviorFactory, RegionBehaviorFactory>()
                .Register(CreateRegionAdapters(container));

            ContainerLocator.SetContainerExtension(() => container.Resolve<IContainerExtension>());
            
            Application.Current.MainWindow = configuration.WindowFactory();
            Application.Current.MainWindow?.Show();

            container.Resolve<IModuleManager>().Run();
        }

        private RegionAdapterMappings CreateRegionAdapters(IContainer container)
        {
            var mappings = new RegionAdapterMappings();

            foreach (var (type, adapter) in configuration.RegionAdapters)
            {
                mappings.RegisterMapping(type, (IRegionAdapter) container.Resolve(adapter));
            }

            return mappings;
        }
    }
}
