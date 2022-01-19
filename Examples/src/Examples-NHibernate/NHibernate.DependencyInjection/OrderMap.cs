using NHibernate.Base;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernate.DependencyInjection
{
  public class OrderMap : ClassMapping<Order>
  {
    public OrderMap()
    {
      Lazy(false);

      Id(x => x.Id, m =>
        {
          m.Column("Id");
          m.Generator(Generators.Identity);
        });

      Property(x=>x.Data);
    }
  }
}