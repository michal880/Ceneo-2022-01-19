using NHibernate.Base;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernate.Mapping.ByStrings
{
  public class OrderMap : ClassMapping<Order>
  {
    public OrderMap()
    {
      Lazy(false);

      Id(x => x.Id);

      Property("_number", m =>
      {
        m.Length(DocumentNumber.MaxLen);
        m.Type(new ValueTypeAsStringType<DocumentNumber>());
      });
      Property("_created", m => m.Type(new ValueTypeAsStringType<Date>()));
      Property("_status", m => { });
    }
  }
}