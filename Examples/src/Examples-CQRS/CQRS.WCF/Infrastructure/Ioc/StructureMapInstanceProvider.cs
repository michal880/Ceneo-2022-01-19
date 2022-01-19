using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using StructureMap;

namespace CQRS.WCF.Infrastructure.Ioc
{
  public class StructureMapInstanceProvider : IInstanceProvider
  {
    private readonly Type _serviceType;
    private readonly IContainer _container;

    public StructureMapInstanceProvider(Type serviceType, IContainer container)
    {
      _serviceType = serviceType;
      _container = container;
    }

    public object GetInstance(InstanceContext instanceContext)
    {
      return GetInstance(instanceContext, null);
    }

    public object GetInstance(InstanceContext instanceContext, Message message)
    {
      return _container.GetInstance(_serviceType);
    }

    public void ReleaseInstance(InstanceContext instanceContext, object instance)
    {
    }
  }
}