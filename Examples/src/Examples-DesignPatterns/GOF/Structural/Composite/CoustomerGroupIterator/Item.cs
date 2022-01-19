using System.Xml;

namespace GOF.Structural.Composite.CoustomerGroupIterator
{
  public class Item 
  {
    private string Name { get; }

    public Item(string name)
    {
      Name = name;
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement("Item");
      writer.WriteAttributeString("name", Name);
      writer.WriteEndElement();
    }
  }
}