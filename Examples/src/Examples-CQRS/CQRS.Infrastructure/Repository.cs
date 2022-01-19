using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Domain;
using CQRS.Domain.Base;

namespace CQRS.Infrastructure
{
  public class Repository<T> : IRepository<T> where T : AggregateRoot, new() //shortcut you can do as you see fit with new()
  {
    private readonly IEventStore _storage;
    private readonly IEventPublisher _publisher;

    public Repository(IEventStore storage, IEventPublisher publisher)
    {
      _storage = storage;
      _publisher = publisher;
    }

    public void Save(T aggregate, int? expectedVersion)
    {
      IEnumerable<Event> events = aggregate.GetUncommittedChanges(); 
      _storage.SaveEvents(aggregate.Id, events, expectedVersion);
      foreach (var e in events)
      {
        _publisher.Publish(e);
      }
    }

    public T GetById(Guid id)
    {
      var obj = new T();//lots of ways to do this
      var e = _storage.GetEventsForAggregate(id);
      obj.LoadsFromHistory(e);
      return obj;
    }
  }
}

