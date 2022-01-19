using System.Collections.Generic;
using System.Xml;

namespace GOF.Structural.Composite.CoustomerGroupIterator
{
  public class CustomerGroup : IItem
  {
    private readonly List<Customer> _customers = new List<Customer>();

    public void AddCustomer(Customer customer)
    {
      _customers.Add(customer);
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement("CustomerGroup");

      foreach (var customer in _customers)
      {
        customer.WriteXml(writer);
      }

      writer.WriteEndElement();
    }
  }

  public interface IItem
  {
    void WriteXml(XmlWriter writer);
  }
}