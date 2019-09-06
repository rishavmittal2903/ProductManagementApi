using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using System.Web.Mvc;

namespace ProductManagement.Models
{
    public class DependencyResolverHandler : System.Web.Http.Dependencies.IDependencyResolver, IDependencyScope, System.Web.Mvc.IDependencyResolver
    {
       public Container _container { get; private set; }
        public DependencyResolverHandler(Container container)
        {
            if(container==null)
            {
                throw new ArgumentException("container");
               
            }
            this._container = container;
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._container.GetAllInstances(serviceType);
        }
        public object GetService(Type serviceType)
        {
            if (!serviceType.IsAbstract && typeof(IController).IsAssignableFrom(serviceType))
            {
                return this._container.GetInstance(serviceType);
            }
            return ((IServiceProvider)this._container).GetService(serviceType);
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }
        IEnumerable<object> IDependencyScope.GetServices(Type serviceType)
        {
            IServiceProvider provider = _container;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            var services = (IEnumerable<object>)provider.GetService(collectionType);
            return services??Enumerable.Empty<object>();
        }
        public void Dispose(){}
    }
}