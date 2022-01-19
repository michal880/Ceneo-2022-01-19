using System.Xml;

namespace GOF.Structural.Composite.Example1
{
  public class Body : Node
  {
    public override void GetHtml(XmlWriter xmlWriter)
    {
      xmlWriter.WriteStartElement("body");
      base.GetHtml(xmlWriter);
      xmlWriter.WriteEndElement();
    }
  }
}