using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate.Cfg;
using NHibernate.DependencyInjection.BytecodeProvider;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Util;
using NUnit.Framework;
using Component = Castle.MicroKernel.Registration.Component;

namespace NHibernate.DependencyInjection
{
  [TestFixture]
  public class Tests : TestBase
  {
    protected override void Configure(Configuration configuration)
    {
      var container = new WindsorContainer();

      container.Register(Component.For<ITaxCalculator>().ImplementedBy<TaxCalculator>());
      var types = Assembly.GetEntryAssembly().GetTypes()
        .Where(f => typeof(ClassMapping<>).IsAssignableFrom(f));

      types.ForEach(f=>container.Register(Component.For(f)));
      
      Environment.BytecodeProvider = new MyBytecodeProvider(container);      
    }

    [SetUp]
    public void Setup()
    {
      log4net.Config.XmlConfigurator.Configure();
    }

    [Test]
    public void TestMapping()
    {
      SetupBase();

      Order order = new Order(new TaxCalculator());
      
      using (ISession session = _sessionFactory.OpenSession())
      {
        session.Save(order);
      }

      using (ISession session = _sessionFactory.OpenSession())
      {
        Order orderFromDb = session.Get<Order>(order.Id);

        Assert.IsNotNull(orderFromDb.GetTaxCalculator());        
      }
    }
  }
}