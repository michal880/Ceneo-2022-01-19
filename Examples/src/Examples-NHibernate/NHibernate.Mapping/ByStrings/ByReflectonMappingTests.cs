using System.IO;
using Moq;
using NUnit.Framework;

namespace NHibernate.Mapping.ByStrings
{
  [TestFixture]
  public class ByReflectonMappingTests : TestBase
  {
    [Test]
    public void TestMapping()
    {
      using (ISession session = _sessionFactory.OpenSession())
      {
        Order order = new Order("12");
        session.Save(order);
        Order orderFromDb = session.Get<Order>(order.Id);

        Assert.AreEqual(order.Id, orderFromDb.Id);
      }
    }
  }
}