using System.Xml;

namespace GOF.Behavioral.Visitor.HtmlExample
{
  public class A : INode
  {
    public string Href { get; }

    public A(string href)
    {
      Href = href;
    }

    public void Accept(IVisitor visitor)
    {
      visitor.BeforeVisit(this);
      visitor.AfterVisit(this);
    }
  }
}