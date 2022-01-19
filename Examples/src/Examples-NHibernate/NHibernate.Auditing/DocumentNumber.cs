
namespace NHibernate.Auditing
{
  public class DocumentNumber : ValueObject
  {
    public const int MaxLen = 128;

    private string _value;

    public DocumentNumber(string value)
    {
      _value = value;
    }

    public static implicit operator DocumentNumber(string number)
    {
      return new DocumentNumber(number);
    }

    public static implicit operator string(DocumentNumber number)
    {
      if (number != null)
      {
        return number._value;
      }
      return null;
    }

    public override string ToString()
    {
      return _value;
    }
  }

  public class ValueObject
  {
  }
}