using System.IO;
using System.Xml;

namespace GOF.Behavioral.Visitor.HtmlExample
{
  public class HtmlVisitor : IVisitor
  {
    private readonly StringWriter _stringWriter;
    private readonly XmlWriter _xmlWriter;

    public HtmlVisitor()
    {
      _stringWriter = new StringWriter();
      _xmlWriter = new XmlTextWriter(_stringWriter);
    }
    public string PrintHtml()
    {
      if (_xmlWriter.WriteState != WriteState.Closed)
      {
        _xmlWriter.Close();
      }
      return _stringWriter.GetStringBuilder().ToString();
    }

    public void BeforeVisit(Html node)
    {
      _xmlWriter.WriteStartElement("html");
    }

    public void AfterVisit(Html node)
    {
      _xmlWriter.WriteEndElement();
    }

    public void BeforeVisit(Head node)
    {
      _xmlWriter.WriteStartElement("head");
    }

    public void AfterVisit(Head node)
    {
      _xmlWriter.WriteEndElement();
    }

    public void BeforeVisit(Div div)
    {
      _xmlWriter.WriteStartElement("div");
    }

    public void AfterVisit(Div div)
    {
      _xmlWriter.WriteEndElement();
    }

    public void BeforeVisit(Body node)
    {
      _xmlWriter.WriteStartElement("body");
    }

    public void AfterVisit(Body node)
    {
      _xmlWriter.WriteEndElement();
    }

    public void BeforeVisit(A node)
    {
      _xmlWriter.WriteStartElement("a");
      _xmlWriter.WriteAttributeString("href", node.Href);
    }

    public void AfterVisit(A node)
    {
      _xmlWriter.WriteEndElement();
    }
  }
}