using System;

namespace Orbit.Framework
{
    public interface IContainer
    {
        IContainer Register<T, TInstance>()
            where TInstance : T;

        IContainer Register<T>(T instance);

        T Resolve<T>();

        object Resolve(Type type);
    }
}
