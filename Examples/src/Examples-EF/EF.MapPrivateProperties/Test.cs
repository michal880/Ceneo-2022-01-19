using System;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EF.MapPrivateProperties
{
  [TestFixture]
  public class Test
  {
    [Test]
    public void Test1()
    {
      AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

      using (var ctx = new OrderContext())
      {
        Order order = new Order();

        ctx.Orders.Add(order);
        ctx.SaveChanges();
      }
    }
  }
}
