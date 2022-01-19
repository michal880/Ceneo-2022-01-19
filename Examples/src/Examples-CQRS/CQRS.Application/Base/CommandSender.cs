using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CQRS.Domain.Base;

namespace CQRS.Application.Base
{
  public class CommandSender : ICommandSender
  {
    private readonly IDependencyResolver _dependencyResolver;
    
    public CommandSender(IDependencyResolver dependencyResolver)
    {
      _dependencyResolver = dependencyResolver;
    }
    
    public void Send<T>(T command) 
    {
      IHandler<T> handler = _dependencyResolver.Resolve<IHandler<T>>();
      handler.Handle(command);
    }
  }
}
