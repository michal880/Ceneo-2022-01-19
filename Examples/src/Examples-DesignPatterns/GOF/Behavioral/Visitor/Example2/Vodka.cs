namespace VisitorPattern
{
  public class Vodka
  {
    public double Price { get; private set; }

    public Vodka(double price)
    {
      Price = price;
    }

    public double Accept(IVisitor visitor)
    {
      return visitor.Visit(this);
    }
  }
}
