using System.Xml;

namespace GOF.Structural.Composite.Example1
{
  public class Div : Node
  {
    public override void GetHtml(XmlWriter xmlWriter)
    {
      xmlWriter.WriteStartElement("div");
      base.GetHtml(xmlWriter);
      xmlWriter.WriteEndElement();
    }
  }
}