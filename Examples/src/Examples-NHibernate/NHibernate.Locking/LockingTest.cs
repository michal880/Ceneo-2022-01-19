using System.Linq;
using Moq;
using NHibernate.Cfg;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace NHibernate.Locking
{
  [TestFixture]
  public class LockingTest : TestBase
  {
    [Test]
    public void OptimisticLocking()
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
      }
    }
  }
}