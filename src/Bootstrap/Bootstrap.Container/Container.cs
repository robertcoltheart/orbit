using Orbit.Framework;
using Unity;

namespace Orbit.Bootstrap.Container
{
    public class Container : IContainer
    {
        private readonly IUnityContainer _container = new UnityContainer();

        public void Register<T>(T instance)
        {
            _container.RegisterInstance(instance);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
