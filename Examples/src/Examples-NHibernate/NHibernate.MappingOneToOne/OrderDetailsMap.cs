using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernate.Mapping.ByStrings
{
  public class OrderDetailsMap : ClassMapping<OrderDetails>
  {
    public OrderDetailsMap()
    {
      Lazy(false);

      Id(x => x.Id, m =>
      {
        m.Column("Id");
        m.Generator(Generators.Identity);
      });

      Property(x=>x.Data);

      ManyToOne(x => x.Order, c =>
      {
        c.Column("OrderId");
        c.NotNullable(true);
        c.Unique(true);
        c.Cascade(Cascade.None);
      });
    }
  }
}