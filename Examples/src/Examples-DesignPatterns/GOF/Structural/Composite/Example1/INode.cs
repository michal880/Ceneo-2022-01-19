using System.Xml;

namespace GOF.Structural.Composite.Example1
{
  public interface INode
  {
    void GetHtml(XmlWriter xmlWriter);
  }
}