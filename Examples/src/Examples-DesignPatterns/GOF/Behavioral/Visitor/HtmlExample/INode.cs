using System.Xml;

namespace GOF.Behavioral.Visitor.HtmlExample
{
  public interface INode
  {
    void Accept(IVisitor visitor);
  }

  public interface IVisitor
  {
    void BeforeVisit(Html node);
    void AfterVisit(Html node);
    void BeforeVisit(Head node);
    void AfterVisit(Head node);
    void BeforeVisit(Div div);
    void AfterVisit(Div div);
    void BeforeVisit(Body node);
    void AfterVisit(Body node);
    void BeforeVisit(A node);
    void AfterVisit(A node);
  }
}