using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernate.Locking
{
  public class OrderMap : ClassMapping<Order>
  {
    public OrderMap()
    {
      Lazy(false);

      Id(x => x.Id);

      Property("_number", m => { });

      Property("_author", m => { });

      Version("_version", m => { });
    }
  }
}