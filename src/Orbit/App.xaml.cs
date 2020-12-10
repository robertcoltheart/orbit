using System.Windows;
using Orbit.Bootstrap;
using Orbit.Bootstrap.Container;
using Orbit.Modules.MarketData;
using Orbit.Modules.Orders;
using Orbit.Modules.Trades;
using Orbit.RegionAdapters;
using Prism.Modularity;

namespace Orbit
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var catalog = new ModuleCatalog()
                .AddModule<MarketDataModule>()
                .AddModule<OrdersModule>()
                .AddModule<TradesModule>();

            BootstrapFactory.Run(x =>
            {
                x.UseModuleCatalog(catalog);
                x.AddRegionAdapter<Window, WindowRegionAdapter>();

                x.UseUnity();

                x.WithShell(() => new Shell());
            });
        }
    }
}
