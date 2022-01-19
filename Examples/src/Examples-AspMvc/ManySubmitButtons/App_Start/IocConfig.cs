using System.Web.Mvc;
using AspMvc.Infrastructure.IoC.CastleWindsor;
using AspMvc.Infrastructure.ManySubmitButtons;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace ManySubmitButtons
{
  public class IocConfig
  {  
    public static void Register()
    {
      IWindsorContainer container = new WindsorContainer();
      DependencyResolver.SetResolver(new WindsorDependencyResolver(container));

      RegisterTypes(container);
    }

    private static void RegisterTypes(IWindsorContainer container)
    {
      container.Register(
        Classes
          .FromThisAssembly()
          .BasedOn<IController>()
          .If(c => c.Name.EndsWith("Controller"))
          .LifestyleTransient(),
        Component
          .For<IActionInvoker>()
          .Instance(new SubmitActionNameActionInvoker(new ControllerActionInvoker())));
    }
  }
}