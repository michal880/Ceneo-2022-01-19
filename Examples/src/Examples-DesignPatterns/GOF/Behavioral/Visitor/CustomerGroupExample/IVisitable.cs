namespace GOF.Behavioral.Visitor.CustomerGroupExample
{
  public interface IVisitable
  {
    void Accept(IVisitor visitor);
  }
}