using System;
using StructureMap;

namespace WCF.VerticalSlices.Infrastructure.Dispatcher
{
  internal class Dispatcher : IDispatcher
  {
    private readonly IContainer _container;

    public Dispatcher(IContainer container)
    {
      _container = container;
    }
    public void Send(Command command)
    {
      Type handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
      var handler = _container.GetInstance(handlerType);
      handler.AsDynamic().Handle(command);
    }

    public QueryResponse Query(QueryRequest query)
    {
      Type handlerType = typeof(IQueryHandler<>).MakeGenericType(query.GetType());
      var handler = _container.GetInstance(handlerType);
      return handler.AsDynamic().Handle(query);
    }
  }  
}