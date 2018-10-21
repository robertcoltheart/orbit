using System.Windows;
using CommonServiceLocator;
using Orbit.Bootstrap.Logging;
using Orbit.Bootstrap.Services;
using Orbit.Framework;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Regions;

namespace Orbit.Bootstrap
{
    public class Bootstrapper : IBootstrapper
    {
        private readonly BootstrapperConfiguration _configuration;

        public Bootstrapper(BootstrapperConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Run()
        {
            var container = _configuration.ResolveService<IContainer>();

            container
                .Register(container)
                .Register(_configuration.ModuleCatalog)
                .Register<IServiceLocator, ServiceProvider>()
                .Register(container as IContainerExtension)
                .Register<ILoggerFacade, LoggerFacade>()
                .Register<IModuleInitializer, ModuleInitializer>()
                .Register<IModuleManager, ModuleManager>()
                .Register<IRegionManager, RegionManager>()
                .Register<IRegionBehaviorFactory, RegionBehaviorFactory>()
                .Register(CreateRegionAdapters(container));

            ServiceLocator.SetLocatorProvider(() => container.Resolve<IServiceLocator>());
            
            Application.Current.MainWindow = _configuration.WindowFactory();
            Application.Current.MainWindow?.Show();

            container.Resolve<IModuleManager>().Run();
        }

        private RegionAdapterMappings CreateRegionAdapters(IContainer container)
        {
            var mappings = new RegionAdapterMappings();

            foreach (var pair in _configuration.RegionAdapters)
                mappings.RegisterMapping(pair.Key, (IRegionAdapter) container.Resolve(pair.Value));

            return mappings;
        }
    }
}
