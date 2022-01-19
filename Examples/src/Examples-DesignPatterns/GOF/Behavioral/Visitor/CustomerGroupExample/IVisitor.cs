namespace GOF.Behavioral.Visitor.CustomerGroupExample
{
  public interface IVisitor
  {
    void Visit(Customer customer);
    void Visit(Order order);
    //void Visit(Item item);
  }
}