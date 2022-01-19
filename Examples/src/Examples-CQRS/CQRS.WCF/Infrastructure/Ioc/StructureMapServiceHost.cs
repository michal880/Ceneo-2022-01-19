using System;
using System.ServiceModel;
using StructureMap;

namespace CQRS.WCF.Infrastructure.Ioc
{
  public class StructureMapServiceHost : ServiceHost
  {
    private IContainer Container { get; }

    public StructureMapServiceHost(Type type) : base(type)
    {
      Container = new Container();
      Container.Configure(config =>
      {
        config.For<IContainer>().Use(Container);
        config.AddRegistry<MyRegistry>();
      });
    }

    public StructureMapServiceHost(Type serviceType, params Uri[] baseAddresses)
      : base(serviceType, baseAddresses)
    {
    }

    protected override void OnOpening()
    {
      Description.Behaviors.Add(new StructureMapServiceBehavior(Container));
      base.OnOpening();
    }
  }
}