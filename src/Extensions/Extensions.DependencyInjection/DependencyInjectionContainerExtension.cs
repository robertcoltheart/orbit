using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;

namespace Orbit.Extensions.DependencyInjection;

public class DependencyInjectionContainerExtension : IContainerExtension<IServiceProvider>
{
    private readonly ServiceCollection services = new();

    public DependencyInjectionContainerExtension()
    {
        services.AddSingleton(this);

        //services.AddSingleton<IContainerRegistry>(x => x.GetRequiredService<DependencyInjectionContainerExtension>());
        services.AddSingleton<IContainerExtension>(this);
        //services.AddSingleton<IContainerProvider>(x => x.GetRequiredService<DependencyInjectionContainerExtension>());
        //services.AddSingleton<IServiceProvider>(x => x.GetRequiredService<ContainerExtension>());
        //services.AddSingleton<IServiceScopeFactory>(x => x.GetRequiredService<ContainerExtension>());
    }

    public IServiceProvider Instance { get; private set; }

    public IScopedProvider CurrentScope { get; }

    public object Resolve(Type type)
    {
        return Instance.GetRequiredService(type);
    }

    public object Resolve(Type type, params (Type Type, object Instance)[] parameters)
    {
        throw new NotImplementedException();
    }

    public object Resolve(Type type, string name)
    {
        throw new NotImplementedException();
    }

    public object Resolve(Type type, string name, params (Type Type, object Instance)[] parameters)
    {
        throw new NotImplementedException();
    }

    public IScopedProvider CreateScope()
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry RegisterInstance(Type type, object instance)
    {
        services.AddSingleton(type, instance);

        return this;
    }

    public IContainerRegistry RegisterInstance(Type type, object instance, string name)
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry RegisterSingleton(Type from, Type to)
    {
        services.AddSingleton(from, to);

        return this;
    }

    public IContainerRegistry RegisterSingleton(Type @from, Type to, string name)
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry RegisterSingleton(Type type, Func<object> factoryMethod)
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry RegisterSingleton(Type type, Func<IContainerProvider, object> factoryMethod)
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry RegisterManySingleton(Type type, params Type[] serviceTypes)
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry Register(Type from, Type to)
    {
        services.AddTransient(from, to);

        return this;
    }

    public IContainerRegistry Register(Type @from, Type to, string name)
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry Register(Type type, Func<object> factoryMethod)
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry Register(Type type, Func<IContainerProvider, object> factoryMethod)
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry RegisterMany(Type type, params Type[] serviceTypes)
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry RegisterScoped(Type @from, Type to)
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry RegisterScoped(Type type, Func<object> factoryMethod)
    {
        throw new NotImplementedException();
    }

    public IContainerRegistry RegisterScoped(Type type, Func<IContainerProvider, object> factoryMethod)
    {
        throw new NotImplementedException();
    }

    public bool IsRegistered(Type type)
    {
        return Instance.GetService(type) != null;
    }

    public bool IsRegistered(Type type, string name)
    {
        throw new NotImplementedException();
    }

    public void FinalizeExtension()
    {
        Instance = services.BuildServiceProvider();
    }
}
