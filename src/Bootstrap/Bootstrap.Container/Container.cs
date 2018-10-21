using System;
using Orbit.Framework;
using Prism.Ioc;
using Unity;

namespace Orbit.Bootstrap.Container
{
    public class Container : IContainer, IContainerExtension<IUnityContainer>
    {
        public IUnityContainer Instance { get; } = new UnityContainer();

        public bool SupportsModules => true;

        public IContainer Register<T, TInstance>()
            where TInstance : T
        {
            Instance.RegisterType<T, TInstance>();

            return this;
        }

        public IContainer Register<T>(T instance)
        {
            Instance.RegisterInstance(instance);

            return this;
        }

        public T Resolve<T>()
        {
            return Instance.Resolve<T>();
        }

        public void RegisterInstance(Type type, object instance)
        {
            Instance.RegisterInstance(type, instance);
        }

        public void RegisterSingleton(Type from, Type to)
        {
            Instance.RegisterSingleton(from, to);
        }

        public void Register(Type from, Type to)
        {
            Instance.RegisterType(from, to);
        }

        public void Register(Type from, Type to, string name)
        {
            Instance.RegisterType(from, to, name);
        }

        public object Resolve(Type type)
        {
            return Instance.Resolve(type);
        }

        public object Resolve(Type type, string name)
        {
            return Instance.Resolve(type, name);
        }

        public void FinalizeExtension()
        {
        }

        public object ResolveViewModelForView(object view, Type viewModelType)
        {
            return Instance.Resolve(viewModelType);
        }
    }
}
