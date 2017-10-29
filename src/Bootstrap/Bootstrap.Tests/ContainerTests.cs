using Xunit;

namespace Orbit.Bootstrap
{
    public class ContainerTests
    {
        [Fact]
        public void CanRegisterInstance()
        {
            var container = new Container.Container();
            container.Register<IInterface>(new Class1());
        }

        [Fact]
        public void CanResolveInstance()
        {
            var class1 = new Class1();

            var container = new Container.Container();
            container.Register<IInterface>(class1);

            Assert.Same(class1, container.Resolve<IInterface>());
        }

        [Fact]
        public void RegisteringNewInstancesOverridesExisting()
        {
            var class1 = new Class1();
            var class2 = new Class2();

            var container = new Container.Container();
            container.Register<IInterface>(class1);
            container.Register<IInterface>(class2);

            var value = container.Resolve<IInterface>();

            Assert.Same(class2, value);
        }

        private interface IInterface
        {
        }

        private class Class1 : IInterface
        {
        }

        private class Class2 : IInterface
        {
        }
    }
}
