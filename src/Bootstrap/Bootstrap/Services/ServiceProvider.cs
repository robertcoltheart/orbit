using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Orbit.Framework;

namespace Orbit.Bootstrap.Services
{
    public class ServiceProvider : ServiceLocatorImplBase
    {
        private readonly IContainer _container;

        public ServiceProvider(IContainer container)
        {
            _container = container;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return _container.Resolve(serviceType);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return new[] { _container.Resolve(serviceType) };
        }
    }
}
