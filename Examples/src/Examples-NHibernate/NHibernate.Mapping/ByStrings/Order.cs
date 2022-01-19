
namespace NHibernate.Mapping.ByStrings
{
  public class Order 
  {
    private DocumentNumber _number;
    private OrderStatus _status;
    private Date _created;

    protected Order()
    {
    }

    public Order(DocumentNumber number)
    {
      _number = number;
      _status = OrderStatus.New;
      _created = Date.Today;
    }

    public int Id { get; set; }
  }
}