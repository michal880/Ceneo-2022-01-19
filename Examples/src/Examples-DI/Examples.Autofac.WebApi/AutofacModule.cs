using Autofac;
using Examples.Autofac.WebApi.Controllers;

namespace Examples.Autofac.WebApi
{
  public class AutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<ExternalQuery>().AsImplementedInterfaces();
    }
  }
}