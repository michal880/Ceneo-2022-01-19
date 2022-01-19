using System.Collections.Generic;
using System.Xml;

namespace GOF.Structural.Composite.Example1
{
  public class Node : INode
  {
    private List<INode> _nodes = new List<INode>();

    public virtual void Add(INode node)
    {
      _nodes.Add(node);
    }

    public virtual void GetHtml(XmlWriter xmlWriter)
    {
      foreach (INode node in _nodes)
      {
        node.GetHtml(xmlWriter);
      }
    }
  }
}