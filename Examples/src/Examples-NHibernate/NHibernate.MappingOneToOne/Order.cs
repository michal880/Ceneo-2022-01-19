
namespace NHibernate.Mapping.ByStrings
{
  public class Order 
  {
    public Order()
    {
    }
    
    public int Id { get; set; }
    public OrderDetails OrderDetails { get; set; }
  }
}