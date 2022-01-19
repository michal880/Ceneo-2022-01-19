using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using StructureMap;

namespace CQRS.WCF.Infrastructure.Ioc
{
  public class StructureMapServiceBehavior : IServiceBehavior
  {
    private IContainer _container;

    public StructureMapServiceBehavior(IContainer container)
    {
      _container = container;
    }

    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
      foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
      {
        ChannelDispatcher cd = cdb as ChannelDispatcher;
        if (cd != null)
        {
          foreach (EndpointDispatcher ed in cd.Endpoints)
          {
            ed.DispatchRuntime.InstanceProvider =
              new StructureMapInstanceProvider(serviceDescription.ServiceType, _container);
          }
        }
      }
    }

    public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
    {
    }

    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
    }
  }
}