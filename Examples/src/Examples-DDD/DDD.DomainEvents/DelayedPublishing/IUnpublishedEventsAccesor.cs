using System.Collections.Generic;

namespace DDD.DomainEvents.DelayedPublishing
{
  public interface IUnpublishedEventsAccesor
  {
    IEnumerable<IDomainEvent> GetUnpublishedEvents();
  }
}