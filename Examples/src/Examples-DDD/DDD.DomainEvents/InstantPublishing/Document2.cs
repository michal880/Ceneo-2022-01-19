namespace DDD.DomainEvents.InstantPublishing
{
  public class Document2 : AggregateRootWithEventPublisher
  {
    public enum DocumentStatus
    {
      New,
      Accepted
    }

    private DocumentStatus _status;

    public Document2(DocumentStatus status = DocumentStatus.New)
    {
      _status = status;
    }

    public void Accept()
    {
      _status = DocumentStatus.Accepted;
      EventPublisher.Publish(new DocumentAccepted(Id));
    }
  }
}