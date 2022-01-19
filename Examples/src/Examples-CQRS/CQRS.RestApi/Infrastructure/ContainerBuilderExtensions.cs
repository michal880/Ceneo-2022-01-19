using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace CQRS.RestApi.Infrastructure
{
  public static class ContainerBuilderExtensions
  {
    public static void RegisterSelf(this ContainerBuilder builder)
    {
      IContainer container = null;
      builder.Register(c => container).AsSelf();
      builder.RegisterBuildCallback(c => container = c);
    }

  }
}
