namespace DDD.DomainEvents.InstantPublishing
{
  public interface IDependencyInjector
  {
    void InjectDependencies(AggregateRootWithEventPublisher aggregateRoot);
  }
}