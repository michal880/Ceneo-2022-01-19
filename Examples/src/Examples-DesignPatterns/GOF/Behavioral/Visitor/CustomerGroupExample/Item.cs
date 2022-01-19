namespace GOF.Behavioral.Visitor.CustomerGroupExample
{
  public class Item : IVisitable
  {
    public string Name { get; }

    public void Accept(IVisitor visitor)
    {
      visitor.Visit(this);
    }

    public Item(string name)
    {
      Name = name;
    }
  }
}