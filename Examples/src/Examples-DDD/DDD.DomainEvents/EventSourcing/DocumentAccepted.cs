namespace DDD.DomainEvents.EventSourcing
{
  public class DocumentAccepted : IDomainEvent
  {
    public int Id { get; }

    public DocumentAccepted()
    { }

    public DocumentAccepted(int id)
    {
      Id = id;
    }
  }
}