using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AspMvc.Examples.Common
{
  public class WindsorInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(Classes.FromThisAssembly()
                                .Where(f => true)
                                .WithService.AllInterfaces()
                                .LifestylePerWebRequest());         
    }
  }
}