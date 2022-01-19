using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using CQRS.Application.Base;
using Event = CQRS.Domain.Base.Event;

namespace CQRS.Infrastructure
{
  public class EventPublisher : IEventPublisher
  {
    private readonly Dictionary<Type, List<Action<object>>> _routes = new Dictionary<Type, List<Action<object>>>();

    public void RegisterHandler<T>(Action<T> handler)
    {
      if (!_routes.TryGetValue(typeof(T), out var handlers))
      {
        handlers = new List<Action<object>>();
        _routes.Add(typeof(T), handlers);
      }
      handlers.Add(DelegateAdjuster.CastArgument<object, T>(x => handler(x)));
    }

    public void Publish<T>(T @event) where T : Event
    {
      if (!_routes.TryGetValue(@event.GetType(), out var handlers)) return;
      foreach (var handler in handlers)
      {
        //dispatch on thread pool for added awesomeness
        var handler1 = handler;
        handler1(@event);
      }
    }
  }

  internal class DelegateAdjuster
  {
    public static Action<BaseT> CastArgument<BaseT, DerivedT>(Expression<Action<DerivedT>> source) where DerivedT : BaseT
    {
      if (typeof(DerivedT) == typeof(BaseT))
      {
        return (Action<BaseT>)((Delegate)source.Compile());

      }
      ParameterExpression sourceParameter = Expression.Parameter(typeof(BaseT), "source");
      var result = Expression.Lambda<Action<BaseT>>(
        Expression.Invoke(
          source,
          Expression.Convert(sourceParameter, typeof(DerivedT))),
        sourceParameter);
      return result.Compile();
    }
  }
}
