using System.Windows;
using Prism;
using Prism.Ioc;
using Prism.Regions;
using Prism.Regions.Behaviors;

namespace Orbit.Extensions.DependencyInjection;

public abstract class PrismApplication : PrismApplicationBase
{
    protected sealed override IContainerExtension CreateContainerExtension()
    {
        return new DependencyInjectionContainerExtension();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        ExceptionExtensions.RegisterFrameworkExceptionType(typeof(InvalidOperationException));

        containerRegistry
            .RegisterSingleton<SelectorRegionAdapter>()
            .RegisterSingleton<ItemsControlRegionAdapter>()
            .RegisterSingleton<ContentControlRegionAdapter>()
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
}
