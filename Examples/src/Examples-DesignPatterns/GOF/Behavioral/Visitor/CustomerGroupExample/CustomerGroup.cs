using System.Collections.Generic;

namespace GOF.Behavioral.Visitor.CustomerGroupExample
{
  public class CustomerGroup : IVisitable
  {
    private readonly List<Customer> _customers = new List<Customer>();

    public void Accept(IVisitor visitor)
    {
      foreach (var customer in _customers)
      {
        customer.Accept(visitor);
      }
    }

    public void AddCustomer(Customer customer)
    {
      _customers.Add(customer);
    }
  }
}