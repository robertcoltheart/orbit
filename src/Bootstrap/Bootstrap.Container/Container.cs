using System;
using Orbit.Framework;
using Prism.Ioc;
using Prism.Unity;
using Unity;

namespace Orbit.Bootstrap.Container
{
    public class Container : IContainer, IContainerExtension<IUnityContainer>
    {
        public UnityContainerExtension Extension { get; } = new UnityContainerExtension();

        public IUnityContainer Instance => Extension.Instance;

        public IScopedProvider CurrentScope => Extension.CurrentScope;

        public object Resolve(Type type, params (Type Type, object Instance)[] parameters)
       {
           return Extension.Resolve(type, parameters);
       }

       public object Resolve(Type type, string name)
       {
           return Extension.Resolve(type, name);
       }

       public object Resolve(Type type, string name, params (Type Type, object Instance)[] parameters)
       {
           return Extension.Resolve(type, name, parameters);
       }

       public IScopedProvider CreateScope()
       {
           return Extension.CreateScope();
       }

       public IContainer Register<T, TInstance>()
           where TInstance : T
       {
           Extension.Register<T, TInstance>();

           return this;
       }

       public IContainer Register<T>(T instance)
       {
           Extension.RegisterInstance(instance);

           return this;
       }

       public T Resolve<T>()
       {
           return Extension.Resolve<T>();
       }

       public object Resolve(Type type)
       {
           return Extension.Resolve(type);
       }

       public IContainerRegistry RegisterInstance(Type type, object instance)
       {
           return Extension.RegisterInstance(type, instance);
       }

       public IContainerRegistry RegisterInstance(Type type, object instance, string name)
       {
           return Extension.RegisterInstance(type, instance, name);
       }

       public IContainerRegistry RegisterSingleton(Type from, Type to)
       {
           return Extension.RegisterSingleton(from, to);
       }

       public IContainerRegistry RegisterSingleton(Type from, Type to, string name)
       {
           return Extension.RegisterSingleton(from, to, name);
       }

       public IContainerRegistry RegisterSingleton(Type type, Func<object> factoryMethod)
       {
           return Extension.RegisterSingleton(type, factoryMethod);
       }

       public IContainerRegistry RegisterSingleton(Type type, Func<IContainerProvider, object> factoryMethod)
       {
           return Extension.RegisterSingleton(type, factoryMethod);
       }

       public IContainerRegistry RegisterManySingleton(Type type, params Type[] serviceTypes)
       {
           return Extension.RegisterManySingleton(type, serviceTypes);
       }

       public IContainerRegistry Register(Type from, Type to)
       {
           return Extension.Register(from, to);
       }

       public IContainerRegistry Register(Type from, Type to, string name)
       {
           return Extension.Register(from, to, name);
       }

       public IContainerRegistry Register(Type type, Func<object> factoryMethod)
       {
           return Extension.Register(type, factoryMethod);
       }

       public IContainerRegistry Register(Type type, Func<IContainerProvider, object> factoryMethod)
       {
           return Extension.Register(type, factoryMethod);
       }

       public IContainerRegistry RegisterMany(Type type, params Type[] serviceTypes)
       {
           return Extension.RegisterMany(type, serviceTypes);
       }

       public IContainerRegistry RegisterScoped(Type from, Type to)
       {
           return Extension.RegisterScoped(from, to);
       }

       public IContainerRegistry RegisterScoped(Type type, Func<object> factoryMethod)
       {
           return Extension.RegisterScoped(type, factoryMethod);
       }

       public IContainerRegistry RegisterScoped(Type type, Func<IContainerProvider, object> factoryMethod)
       {
           return Extension.RegisterScoped(type, factoryMethod);
       }

       public bool IsRegistered(Type type)
       {
           return Extension.IsRegistered(type);
       }

       public bool IsRegistered(Type type, string name)
       {
           return Extension.IsRegistered(type, name);
       }

       public void FinalizeExtension()
       {
           Extension.FinalizeExtension();
       }
    }
}
