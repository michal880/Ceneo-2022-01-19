using System;
using System.Text;
using Autofac;

namespace Examples.Autofac.WebApi.Tests
{
  public class AutofacModule4Testing : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<TestExternalQuery>().AsImplementedInterfaces();
    }
  }
}
