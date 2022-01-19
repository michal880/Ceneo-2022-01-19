using System.Xml;

namespace GOF.Structural.Composite.Example1
{
  public class Head : Node
  {
    public void GetHtml(XmlWriter xmlWriter)
    {
      xmlWriter.WriteStartElement("head");
      base.GetHtml(xmlWriter);
      xmlWriter.WriteEndElement();
    }
  }
}