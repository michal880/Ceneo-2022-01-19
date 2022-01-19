using System.Xml;

namespace GOF.Structural.Composite.Example1
{
  public class Html : Node
  {
    public override void GetHtml(XmlWriter xmlWriter)
    {
      xmlWriter.WriteStartElement("html");
      base.GetHtml(xmlWriter);
      xmlWriter.WriteEndElement();
    }
  }
}