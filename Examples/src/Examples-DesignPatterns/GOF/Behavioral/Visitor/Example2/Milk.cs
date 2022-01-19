namespace VisitorPattern
{
  public class Milk : IVisitable
  {
    public double Price { get; private set; }

    public Milk(double price)
    {
      Price = price;
    }

    public double Accept(IVisitor visitor)
    {
      return visitor.Visit(this);
    }
  }
}