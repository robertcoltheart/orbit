using System.Windows;
using Orbit.Bootstrap;
using Orbit.Bootstrap.Container;
using Orbit.Bootstrap.Logging;
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

                x.UseUnity();
                x.UseSerilog();
            });
        }
    }
}
