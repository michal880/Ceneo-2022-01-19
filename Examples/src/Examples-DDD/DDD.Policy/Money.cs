namespace DDD.Policy
{
  public class Money : ValueObject
  {
    private decimal _amount;
    public static Money ZERO = 0.0;

    private Money(decimal amount)
    {
      _amount = amount;
    }

    private Money(double amount)
    {
      _amount = (decimal)amount;
    }

    public static Money operator -(Money x)
    {
      return new Money(-x._amount);
    }

    public static Money operator *(Money money, decimal value)
    {
      return new Money(money._amount * value);
    }

    public static Money operator *(Money money, double value)
    {
      return new Money((decimal)((double)money._amount * value));
    }

    public static Money operator *(double value, Money money)
    {
      return new Money((decimal)((double)money._amount * value));
    }

    public static Money operator *(decimal value, Money money)
    {
      return new Money(money._amount * value);
    }

    public static Money operator +(Money money, Money value)
    {
      return new Money(money._amount + value._amount);
    }

    public static Money operator -(Money money, Money value)
    {
      return new Money(money._amount - value._amount);
    }

    public static bool operator >(Money money, Money value)
    {
      return money._amount > value._amount;
    }

    public static bool operator >=(Money money, Money value)
    {
      return money._amount >= value._amount;
    }

    public static bool operator <(Money money, Money value)
    {
      return money._amount < value._amount;
    }

    public static bool operator <=(Money money, Money value)
    {
      return money._amount <= value._amount;
    }

    public static implicit operator Money(decimal value)
    {
      return new Money(value);
    }

    public static implicit operator Money(double value)
    {
      return new Money(value);
    }

    protected override object[] GetValues()
    {
      return new[] { (object)_amount};
    }
  }
}