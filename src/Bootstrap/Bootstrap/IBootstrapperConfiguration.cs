using Prism.Modularity;

namespace Orbit.Bootstrap
{
    public interface IBootstrapperConfiguration
    {
        void UseModuleCatalog(IModuleCatalog moduleCatalog);
    }
}
