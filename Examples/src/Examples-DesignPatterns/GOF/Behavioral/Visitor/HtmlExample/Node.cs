using System.Collections.Generic;
using System.Xml;

namespace GOF.Behavioral.Visitor.HtmlExample
{
  public abstract class Node : INode
  {
    private readonly List<INode> _nodes = new List<INode>();

    public virtual void Add(INode node)
    {
      _nodes.Add(node);
    }

    public virtual void Accept(IVisitor visitor)
    {
      foreach (INode node in _nodes)
      {
        node.Accept(visitor);
      }
    }
  }
}