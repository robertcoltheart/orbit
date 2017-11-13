using System;
using System.Windows;
using Prism.Modularity;
using Prism.Regions;

namespace Orbit.Bootstrap
{
    public interface IBootstrapperConfiguration
    {
        void RegisterService<T>(Func<T> factory);

        void UseModuleCatalog(IModuleCatalog moduleCatalog);

        void WithShell(Func<Window> windowFactory);

        void AddRegionAdapter<T, TAdapter>()
            where T : FrameworkElement
            where TAdapter : IRegionAdapter;
    }
}
