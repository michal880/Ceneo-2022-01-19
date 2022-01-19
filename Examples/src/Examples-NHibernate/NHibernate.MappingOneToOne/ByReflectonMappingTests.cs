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
      SetupBase();

      Order order = new Order();
      Order order2 = new Order();

      OrderDetails details = new OrderDetails(order)
      {
        //Id = 123123,
        Data = "test122"
      };

      order.OrderDetails = details;

      using (ISession session = _sessionFactory.OpenSession())
      {
        session.Save(order2);
        session.Save(order);
      }

      using (ISession session = _sessionFactory.OpenSession())
      {
        Order orderFromDb = session.Get<Order>(order.Id);

        Assert.AreEqual(order.Id, orderFromDb.Id);
        Assert.IsNotNull(orderFromDb.OrderDetails);
        Assert.AreEqual(order.OrderDetails.Data, orderFromDb.OrderDetails.Data);
      }
    }
  }
}