using System;

namespace CQRS.Application.Base
{
  public interface IDependencyResolver
  {
    T Resolve<T>();
  }
}