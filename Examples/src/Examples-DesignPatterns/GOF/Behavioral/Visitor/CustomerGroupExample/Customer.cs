using System.Collections.Generic;

namespace GOF.Behavioral.Visitor.CustomerGroupExample
{
  public class Customer : IVisitable
  {
    public string Name { get; }

    private readonly List<Order> _orders = new List<Order>();

    public Customer(string name)
    {
      Name = name;
    }

    public void Accept(IVisitor visitor)
    {
      visitor.Visit(this);

      foreach (var order in _orders)
      {
        order.Accept(visitor);
      }
    }
    
    public void AddOrder(Order order)
    {
      _orders.Add(order);
    }
  }
}
