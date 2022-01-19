using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Util;
using NUnit.Framework;

namespace OrderTracking.Ado
{
  [TestFixture]
  public class Test
  {
    private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Ado\data.mdf;Integrated Security=True";

    [Test]
    public void AdoTest()
    {
      AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

      Guid orderId = OrderContext.New();

      IRepository repository = new Repository(ConnectionString);
      repository.Add(1, "Test1");

      IAuditRepository audit = new AuditRepository(ConnectionString);
      IEnumerable<AuditData> result = audit.GetAudit(1);

      Assert.AreEqual(result.First().OrderId, orderId);
    }
  }
}
