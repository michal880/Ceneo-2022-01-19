using System;
using System.Linq;
using Moq;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByStrings;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace NHibernate.Mapping.ByMemnto
{
  [TestFixture]
  public class ByMementoTests : TestBase
  {
    [Test]
    public void TestMapping()
    {
      using (ISession session = _sessionFactory.OpenSession())
      {
        DocumentRepository repository = new DocumentRepository(session);
        DocumentMe document = new DocumentMe("DW/12");
        repository.Save(document);
        DocumentMe documentFromDb = repository.Get(document.Id);

        Assert.AreEqual(document.Id, documentFromDb.Id);
      }
    }
  }
}