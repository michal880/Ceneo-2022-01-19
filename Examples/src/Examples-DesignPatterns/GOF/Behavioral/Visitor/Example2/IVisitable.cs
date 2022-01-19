namespace VisitorPattern
{
  public interface IVisitable
  {
    double Accept(IVisitor visitor);
  }
}