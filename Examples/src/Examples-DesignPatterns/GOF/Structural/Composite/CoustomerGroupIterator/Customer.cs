using System.Collections.Generic;
using System.Xml;

namespace GOF.Structural.Composite.CoustomerGroupIterator
{
  public class Customer 
  {
    public string Name { get; }

    private readonly List<Order> _orders = new List<Order>();

    public Customer(string name)
    {
      Name = name;
    }

    public void AddOrder(Order order)
    {
      _orders.Add(order);
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement("Customer");
      writer.WriteAttributeString("name",Name);

      foreach (var order in _orders)
      {
        order.WriteXml(writer);
      }

      writer.WriteEndElement();
    }
  }
}
