using System;

namespace GOF.Behavioral.Visitor.CustomerGroupExample
{
  public class Report : IVisitor
  {
    private int _customersNo;
    private int _ordersNo;
    private int _itemsNo;

    public void Visit(Customer customer)
    {
      Console.WriteLine(customer.Name);
      _customersNo++;
    }
    public void Visit(Order order)
    {
      Console.WriteLine(order.Name);
      _ordersNo++;
    }
    public void Visit(Item item)
    {
      Console.WriteLine(item.Name);
      _itemsNo++;
    }

    public void DisplayResults()
    {
      Console.WriteLine("Nr of customers:" + _customersNo);
      Console.WriteLine("Nr of orders:   " + _ordersNo);
      Console.WriteLine("Nr of itemss:   " + _itemsNo);
    }
  }
}