namespace DDD.DomainEvents.InstantPublishing
{
  public class AggregateRootWithEventPublisher
  {
    public int Id { get; set; }

    protected IDomainEventPublisher EventPublisher { get; private set; }
  }
}