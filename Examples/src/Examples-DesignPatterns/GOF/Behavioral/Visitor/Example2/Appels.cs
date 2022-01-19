namespace VisitorPattern
{
  public class Appels
  {
    public double Price { get; private set; }

    public Appels(double price)
    {
      Price = price;
    }

    public double Accept(IVisitor visitor)
    {
      return visitor.Visit(this);
    }
  }
}