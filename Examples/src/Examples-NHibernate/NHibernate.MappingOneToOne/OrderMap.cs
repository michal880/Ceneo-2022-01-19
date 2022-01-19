using NHibernate.Base;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernate.Mapping.ByStrings
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

      OneToOne(x=>x.OrderDetails, c =>
      {        
        c.Cascade(Cascade.All);
        c.PropertyReference(typeof(OrderDetails).GetProperty("Order"));
      });
    }
  }
}