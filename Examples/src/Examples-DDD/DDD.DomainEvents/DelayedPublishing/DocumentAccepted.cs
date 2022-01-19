namespace DDD.DomainEvents.DelayedPublishing
{
  public class DocumentAccepted : IDomainEvent
  {
    public int Id { get; }

    public DocumentAccepted(int id)
    {
      Id = id;      
    }
  }
}