namespace DDD.DomainEvents.InstantPublishing
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