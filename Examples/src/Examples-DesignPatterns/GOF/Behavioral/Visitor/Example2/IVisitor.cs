namespace VisitorPattern
{
  public interface IVisitor
  {
    double Visit(Appels appels);
    double Visit(Milk milk);
    double Visit(Vodka vodka);
  }
}