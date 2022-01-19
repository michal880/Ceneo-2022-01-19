namespace DDD.DomainEvents.EventSourcing
{
  public class DocumentCreated : IDomainEvent
  {
    public int Id { get; set; }

    public DocumentCreated()
    {
    }

    public DocumentCreated(int id)
    {
      Id = id;
    }
  }
}