namespace Orbit.Framework
{
    public interface IContainer
    {
        void Register<T>(T instance);

        T Resolve<T>();
    }
}
