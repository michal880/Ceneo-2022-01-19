using System.Collections.Generic;

namespace GOF.Behavioral.Visitor.CustomerGroupExample
{
  public class Order : IVisitable
  {
    public string Name { get; }
    public IList<Item> Items { get; } = new List<Item>();

    public Order(string name)
    {
      Name = name;
    }

    public Order(string name, string itemName)
    {
      Name = name;
      AddItem(new Item(itemName));
    }

    public void Accept(IVisitor visitor)
    {
      visitor.Visit(this);

      foreach (var item in Items)
      {
        item.Accept(visitor);
      }
    }


    public void AddItem(Item item)
    {
      Items.Add(item);
    }
  }
}