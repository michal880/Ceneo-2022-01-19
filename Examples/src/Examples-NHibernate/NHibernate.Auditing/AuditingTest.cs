using System.Linq;
using NHibernate.Cfg;
using NHibernate.Envers.Configuration.Fluent;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace NHibernate.Auditing
{
  [TestFixture]
  public class AuditingTest : TestBase
  {
    [Test]
    public void Check_audit_tabels_work()
    {
      SetupBase();
      using (ISession session = _sessionFactory.OpenSession())
      {
        Order order = new Order("12");
        session.Save(order);
        session.Flush();

        Order orderFromDb = session.Get<Order>(order.Id);
        orderFromDb.Sign("Jola");

        session.Save(orderFromDb);
        session.Flush();

        order.Sign("Ala");
        session.Save(order);
        session.Flush();

        order.Assert("12", "Ala", 3);
      }
    }
  }
}