using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF.Behavioral.Observer
{
  internal class Order
  {
    private Observer _observer;

    public void Submit()
    {
      _observer.NotifyObservers(new OrderSubmited());
    }
  }

  internal class OrderSubmited
  {
  }

  internal class Observer
  {
    private List<IHandler> _handlers = new List<IHandler>();

    public void RegisterHandler(IHandler handler)
    {
      _handlers.Add(handler);
    }

    public void NotifyObservers(object arg)
    {
      foreach (var handler in _handlers)
      {
        handler.Handle(arg);
      }
    }
  }

  internal interface IHandler
  {
    object Handle(object arg);
  }
}