namespace DDD.Sagas.Events
{
  public class DocumentCreatedEvent
  {
    public DocumentCreatedEvent(string documentId)
    {
      DocumentId = documentId;
    }

    public string DocumentId { get; set; }
  }
}