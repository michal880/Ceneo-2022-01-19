using NHibernate.Mapping.ByStrings;

namespace NHibernate.Mapping.ByMemnto
{
  public class DocumentMe : IStateAccesor<DocumentState>
  {
    private DocumentState _state;

    public DocumentMe(DocumentNumber documentNumber)
    {
      _state = new DocumentState();
      Number = documentNumber;
    }

    public DocumentMe(DocumentState state)
    {
      _state = state;
    }

    public DocumentNumber Number
    {
      get { return _state.Number; }
      private set { _state.Number = value; }
    }

    public int Id { get; set; }

    DocumentState IStateAccesor<DocumentState>.GetState()
    {
      return _state;
    }
  }
}