using System.Collections.Generic;
using DDD.DomainEvents.DelayedPublishing;

namespace DDD.DomainEvents.EventSourcing
{
  public interface IHaveEvents
  {
    void LoadFromHistory(IEnumerable<IDomainEvent> events);

    IEnumerable<IDomainEvent> GetEvents();
  }
}