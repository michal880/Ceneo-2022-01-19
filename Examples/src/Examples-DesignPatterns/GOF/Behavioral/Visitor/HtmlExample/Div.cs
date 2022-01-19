using System.Xml;

namespace GOF.Behavioral.Visitor.HtmlExample
{
  public class Div : Node
  {
    public override void Accept(IVisitor visitor)
    {
      visitor.BeforeVisit(this);
      base.Accept(visitor);
      visitor.AfterVisit(this);
    }
  }
}