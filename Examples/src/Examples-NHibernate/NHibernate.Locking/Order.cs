namespace NHibernate.Locking
{
  public class Order 
  {
    private string _number;
    private string _author;
    private int _version;

    protected Order()
    {
    }

    public Order(DocumentNumber number)
    {
      _number = number;
    }

    public int Id { get; set; }

    public void Sign(string author)
    {
      _author = author;
    }
  }
}