using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspMvc.Examples.Common.Client.Command;
using AspMvc.Infrastructure.ManySubmitButtons;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CommandPattern
{
  public class WindsorInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(
        Classes
          .FromThisAssembly()
          .BasedOn<IController>()
          .If(c => c.Name.EndsWith("Controller"))
          .LifestyleTransient());

      container.Register(Classes.FromThisAssembly()
                                .Where(f => true)
                                .WithService.AllInterfaces()
                                .LifestylePerWebRequest());
    }
  }
}