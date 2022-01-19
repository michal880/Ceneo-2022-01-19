using System;
using System.Reflection;
using System.Web.Mvc;
using AspMvc.Infrastructure.ManySubmitButtons;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace AspMvc.Infrastructure.IoC.CastleWindsor
{
  public class IocConfig
  {
    public static void Configure(params Assembly[] assembliesOfTypesToRegister)
    {
      IWindsorContainer container = new WindsorContainer();
      DependencyResolver.SetResolver(new WindsorDependencyResolver(container));

      container.Install(FromAssembly.InDirectory(new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory)));
      container.Install(FromAssembly.InDirectory(new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory + "\\bin")));

      foreach (Assembly assembly in assembliesOfTypesToRegister)
      {
        container.Install(FromAssembly.Instance(assembly));
      }

      RegisterTypes(container);
    }

    private static void RegisterTypes(IWindsorContainer container)
    {
      container.Register(
        Component
          .For<IFilterProvider>()
          .ImplementedBy<FilterProvider>());

      Component
        .For<IActionInvoker>()
        .Instance(new SubmitActionNameActionInvoker(new ControllerActionInvoker()));

      if (!container.Kernel.HasComponent(typeof (IWindsorContainer)))
      {
        container.Register(
          Component.For<IWindsorContainer>().Instance(container));
      }
    }
  }
}