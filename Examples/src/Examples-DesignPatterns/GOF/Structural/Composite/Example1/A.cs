using System.Xml;

namespace GOF.Structural.Composite.Example1
{
  public class A : INode
  {
    private readonly string _href;

    public A(string href)
    {
      _href = href;
    }

    public void GetHtml(XmlWriter xmlWriter)
    {
      xmlWriter.WriteStartElement("a");
      xmlWriter.WriteAttributeString("href", _href);
      xmlWriter.WriteEndElement();
    }
  }
}