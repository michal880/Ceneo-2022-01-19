namespace DDD.DomainEvents.DelayedPublishing
{
  public class Document : AggregateRootWithEventList
  {
    public enum DocumentStatus
    {
      New,
      Accepted
    }

    private DocumentStatus _status;

    public void Accept()
    {
      _status = DocumentStatus.Accepted;
      PublishEvent(new DocumentAccepted(Id));
    }
  }
}