using System.Windows;
using Orbit.Bootstrap;
using Orbit.Bootstrap.Container;
using Orbit.Bootstrap.Logging;
using Orbit.RegionAdapters;
using Prism.Modularity;

namespace Orbit
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var catalog = new ModuleCatalog();

            BootstrapFactory.Run(x =>
            {
                x.UseModuleCatalog(catalog);
                x.AddRegionAdapter<Window, WindowRegionAdapter>();

                x.UseUnity();
                x.UseSerilog();

                x.WithShell(() => new Shell());
            });
        }
    }
}
