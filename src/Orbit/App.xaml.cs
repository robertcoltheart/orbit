using System.Windows;
using Orbit.Bootstrap;
using Orbit.Extensions.DependencyInjection;
using Orbit.Modules.Layouts;
using Orbit.Modules.MarketData;
using Orbit.Modules.Options;
using Orbit.Modules.Orders;
using Orbit.Modules.Splash;
using Orbit.Modules.Themes;
using Orbit.Modules.Trades;
using Orbit.RegionAdapters;
using Prism.Modularity;

namespace Orbit;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var catalog = new ModuleCatalog()
            .AddModule<LayoutsModule>()
            .AddModule<OptionsModule>()
            .AddModule<SplashModule>()
            .AddModule<ThemesModule>()
            .AddModule<MarketDataModule>()
            .AddModule<OrdersModule>()
            .AddModule<TradesModule>();

        BootstrapFactory.Run(x =>
        {
            x.UseModuleCatalog(catalog);
            x.AddRegionAdapter<Window, WindowRegionAdapter>();

            x.UseDependencyInjection();

            x.WithShell(() => new Shell());
        });
    }
}
