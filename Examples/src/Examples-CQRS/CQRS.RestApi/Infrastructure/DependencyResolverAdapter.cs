using Autofac;
using CQRS.Application.Base;

namespace CQRS.RestApi.Infrastructure
{
    class DependencyResolverAdapter : IDependencyResolver
    {
      private readonly IContainer _container;

      public DependencyResolverAdapter(IContainer container)
      {
        _container = container;
      }

      public T Resolve<T>()
      {
        return _container.Resolve<T>();        
      }
    }
}
