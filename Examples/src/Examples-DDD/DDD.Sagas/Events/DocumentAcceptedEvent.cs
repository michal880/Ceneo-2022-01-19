namespace DDD.Sagas.Events
{
  public class DocumentAcceptedEvent
  {
    public DocumentAcceptedEvent(string documentId)
    {
      DocumentId = documentId;
    }

    public string DocumentId { get; set; }
  }
}