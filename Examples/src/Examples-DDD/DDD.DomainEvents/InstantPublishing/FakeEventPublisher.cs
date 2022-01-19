using System.Collections.Generic;

namespace DDD.DomainEvents.InstantPublishing
{
  public class FakeEventPublisher : IDomainEventPublisher
  {
    public List<IDomainEvent> UnpublishedEvents { get; } = new List<IDomainEvent>();

    public void Publish<T>(T domainEvent) where T : IDomainEvent
    {
      UnpublishedEvents.Add(domainEvent);
    }
  }
}