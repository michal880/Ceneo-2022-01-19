using System.Collections.Generic;
using System.Xml;

namespace GOF.Structural.Composite.CoustomerGroupIterator
{
  public class Order
  {
    public string Name { get; }
    public IList<Item> Items { get; } = new List<Item>();

    public Order(string name)
    {
      Name = name;
    }

    public Order(string name, string itemName)
    {
      Name = name;
      AddItem(new Item(itemName));
    }

    public void AddItem(Item item)
    {
      Items.Add(item);
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement("Order");
      writer.WriteAttributeString("name", Name);

      foreach (var order in Items)
      {
        order.WriteXml(writer);
      }

      writer.WriteEndElement();
    }
  }
}