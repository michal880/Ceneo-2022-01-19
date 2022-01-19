using System;
using System.IO;
using System.Xml;
using NUnit.Framework;

namespace GOF.Structural.Composite.CoustomerGroupIterator
{
  [TestFixture]
  public class _CompositeTest
  {
    [Test]
    public void WriteToXmlTest()
    {
      Customer c = new Customer("customer1");
      c.AddOrder(new Order("order1", "item1_1"));
      c.AddOrder(new Order("order2", "item2_1"));
      c.AddOrder(new Order("order3", "item3_1"));

      Customer c2 = new Customer("customer2");
      Order o = new Order("order_a");
      o.AddItem(new Item("item_a1"));
      o.AddItem(new Item("item_a2"));
      o.AddItem(new Item("item_a3"));
      c2.AddOrder(o);
      c2.AddOrder(new Order("order_b", "item_b1"));


      CustomerGroup customers = new CustomerGroup();
      customers.AddCustomer(c);
      customers.AddCustomer(c2);

      using(var sw = new StringWriter())
      using (var w = new XmlTextWriter(sw))
      {
        customers.WriteXml(w);

        Console.WriteLine(sw.GetStringBuilder());
      }
    }
  }
}