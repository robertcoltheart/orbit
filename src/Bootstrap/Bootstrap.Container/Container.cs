using System;
using System.Linq;
using Orbit.Framework;
using Prism.Ioc;
using Unity;
using Unity.Resolution;

namespace Orbit.Bootstrap.Container
{
    public class Container : IContainer, IContainerExtension<IUnityContainer>
    {
        public IUnityContainer Instance { get; } = new UnityContainer();

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

        public IContainerRegistry RegisterInstance(Type type, object instance, string name)
        {
            Instance.RegisterInstance(type, name, instance);

            return this;
        }

        public IContainerRegistry RegisterSingleton(Type from, Type to)
        {
            Instance.RegisterSingleton(from, to);

            return this;
        }

        public IContainerRegistry RegisterSingleton(Type from, Type to, string name)
        {
            Instance.RegisterSingleton(from, to, name);

            return this;
        }

        public IContainerRegistry Register(Type from, Type to)
        {
            Instance.RegisterType(from, to);

            return this;
        }

        public IContainerRegistry Register(Type from, Type to, string name)
        {
            Instance.RegisterType(from, to, name);

            return this;
        }

        public bool IsRegistered(Type type)
        {
            return Instance.IsRegistered(type);
        }

        public bool IsRegistered(Type type, string name)
        {
            return Instance.IsRegistered(type, name);
        }

        public IContainerRegistry RegisterInstance(Type type, object instance)
        {
            Instance.RegisterInstance(type, instance);

            return this;
        }

        public object Resolve(Type type)
        {
            return Instance.Resolve(type);
        }

        public object Resolve(Type type, params (Type Type, object Instance)[] parameters)
        {
            var overrides = parameters
                .Select(p => new DependencyOverride(p.Type, p.Instance))
                .Cast<ResolverOverride>()
                .ToArray();

            return Instance.Resolve(type, overrides);
        }

        public object Resolve(Type type, string name)
        {
            return Instance.Resolve(type, name);
        }

        public object Resolve(Type type, string name, params (Type Type, object Instance)[] parameters)
        {
            var overrides = parameters
                .Select(p => new DependencyOverride(p.Type, p.Instance))
                .Cast<ResolverOverride>()
                .ToArray();

            return Instance.Resolve(type, name, overrides);
        }

        public void FinalizeExtension()
        {
        }
    }
}
