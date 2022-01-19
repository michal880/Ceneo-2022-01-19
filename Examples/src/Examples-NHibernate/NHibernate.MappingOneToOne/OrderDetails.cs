namespace NHibernate.Mapping.ByStrings
{
  public class OrderDetails
  {
    public Order Order { get; set; }
    public int Id { get; set; }
    public string Data { get; set; }    

    protected OrderDetails()
    {}

    public OrderDetails(Order order)
    {
      Order = order;      
    } 
  }
}