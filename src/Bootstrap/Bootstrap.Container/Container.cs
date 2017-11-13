using System;
using Orbit.Framework;
using Unity;

namespace Orbit.Bootstrap.Container
{
    public class Container : IContainer
    {
        private readonly IUnityContainer _container = new UnityContainer();

        public IContainer Register<T, TInstance>()
            where TInstance : T
        {
            _container.RegisterType<T, TInstance>();

            return this;
        }

        public IContainer Register<T>(T instance)
        {
            _container.RegisterInstance(instance);

            return this;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
