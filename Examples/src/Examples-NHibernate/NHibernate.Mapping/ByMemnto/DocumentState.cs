using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernate.Mapping.ByMemnto
{
  public class DocumentState
  {
    public int Id;
    public string Number;
  }

  public class DocumentStateMap : ClassMapping<DocumentState>
  {
    public DocumentStateMap()
    {
      Lazy(false);

      Id(x => x.Id);

      Property(x => x.Number);
    }
  }
}