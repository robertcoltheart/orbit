using System;
using System.Collections.Generic;
using System.Windows;
using Prism.Modularity;
using Prism.Regions;

namespace Orbit.Bootstrap
{
    public class BootstrapperConfiguration : IBootstrapperConfiguration
    {
        private readonly Dictionary<Type, Delegate> _factories = new Dictionary<Type, Delegate>();

        public IModuleCatalog ModuleCatalog { get; private set; }

        public Func<Window> WindowFactory { get; private set; }

        public Dictionary<Type, Type> RegionAdapters { get; } = new Dictionary<Type, Type>();

        public void RegisterService<T>(Func<T> factory)
        {
            _factories[typeof(T)] = factory;
        }

        public T ResolveService<T>()
        {
            return (T) _factories[typeof(T)].DynamicInvoke();
        }

        public void UseModuleCatalog(IModuleCatalog moduleCatalog)
        {
            ModuleCatalog = moduleCatalog;
        }

        public void WithShell(Func<Window> windowFactory)
        {
            WindowFactory = windowFactory;
        }

        public void AddRegionAdapter<T, TAdapter>()
            where T : FrameworkElement
            where TAdapter : IRegionAdapter
        {
            RegionAdapters[typeof(T)] = typeof(TAdapter);
        }
    }
}
