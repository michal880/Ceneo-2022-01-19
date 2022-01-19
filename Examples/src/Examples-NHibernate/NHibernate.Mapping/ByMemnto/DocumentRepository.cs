namespace NHibernate.Mapping.ByMemnto
{
  public class DocumentRepository 
  {
    private readonly ISession _session;

    public DocumentRepository(ISession session)
    {
      _session = session;
    }

    public DocumentMe Get(int id)
    {
      return new DocumentMe(_session.Get<DocumentState>(id));
    }

    public void Delete(DocumentMe aggregateRoot)
    {
      DocumentState state = (aggregateRoot as IStateAccesor<DocumentState>).GetState();
      _session.Delete(state);
    }

    public void Save(DocumentMe aggregateRoot)
    {
      DocumentState state = (aggregateRoot as IStateAccesor<DocumentState>).GetState();
      _session.SaveOrUpdate(state);      
    }
  }
}