
namespace NHibernate.Auditing
{
  public class Order 
  {
    public int Id { get; set; }
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

    public void Sign(string author)
    {
      _author = author;
    }

    public void Assert(string number, string author, int version)
    {
      NUnit.Framework.Assert.AreEqual(number, _number);
      NUnit.Framework.Assert.AreEqual(author, _author);
      NUnit.Framework.Assert.AreEqual(version, _version);
    }
  }
}