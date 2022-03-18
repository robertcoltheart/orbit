using System.Windows;
using Prism;
using Prism.Ioc;
using Prism.Regions;
using Prism.Regions.Behaviors;

namespace Orbit.Bootstrap.Bootstrappers;

public class PrismBootstrapper : PrismBootstrapperBase, IBootstrapper
{
    private readonly BootstrapperConfiguration configuration;

    public PrismBootstrapper(BootstrapperConfiguration configuration)
    {
        this.configuration = configuration;
    }

    protected override IContainerExtension CreateContainerExtension()
    {
        return configuration.ResolveService<IContainerExtension>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        RegisterRegionAdapters(containerRegistry);
        RegisterRegionAdapterMappings(containerRegistry);
        RegisterRegionBehaviors(containerRegistry);
        RegisterModuleTypes(containerRegistry);
    }

    protected override DependencyObject CreateShell()
    {
        return configuration.WindowFactory();
    }

    protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
    {
        base.ConfigureRegionAdapterMappings(regionAdapterMappings);

        foreach (var (type, adapter) in configuration.RegionAdapters)
        {
            if (Container.Resolve(adapter) is not IRegionAdapter regionAdapter)
            {
                throw new InvalidOperationException($"Type is not a region adapter: '{adapter.Name}'");
            }

            regionAdapterMappings.RegisterMapping(type, regionAdapter);
        }
    }

    private void RegisterRegionAdapters(IContainerRegistry containerRegistry)
    {
        containerRegistry
            .RegisterSingleton<SelectorRegionAdapter>()
            .RegisterSingleton<ItemsControlRegionAdapter>()
            .RegisterSingleton<ContentControlRegionAdapter>();
    }

    private void RegisterRegionAdapterMappings(IContainerRegistry containerRegistry)
    {
        foreach (var (_, adapter) in configuration.RegionAdapters)
        {
            containerRegistry.RegisterSingleton(adapter);
        }
    }

    private void RegisterRegionBehaviors(IContainerRegistry containerRegistry)
    {
        containerRegistry
            .RegisterSingleton<DelayedRegionCreationBehavior>()
            .RegisterSingleton<BindRegionContextToDependencyObjectBehavior>()
            .RegisterSingleton<RegionActiveAwareBehavior>()
            .RegisterSingleton<SyncRegionContextWithHostBehavior>()
            .RegisterSingleton<RegionManagerRegistrationBehavior>()
            .RegisterSingleton<RegionMemberLifetimeBehavior>()
            .RegisterSingleton<ClearChildViewsRegionBehavior>()
            .RegisterSingleton<AutoPopulateRegionBehavior>()
            .RegisterSingleton<DestructibleRegionBehavior>();
    }

    private void RegisterModuleTypes(IContainerRegistry containerRegistry)
    {
        if (configuration.ModuleCatalog == null)
        {
            return;
        }

        foreach (var module in configuration.ModuleCatalog.Modules)
        {
            var type = Type.GetType(module.ModuleType);

            if (type == null)
            {
                throw new TypeLoadException($"Cannot load type: '{module.ModuleType}'");
            }

            containerRegistry.RegisterSingleton(type);
        }
    }
}
