using System;

namespace GOF.Behavioral.State.Example2
{
  public class Money
  {
    private decimal _value;

    public Money(decimal value)
    {
      _value = value;
    }

    public static bool operator <(Money x, Money y)
    {
      return x._value < y._value;
    }

    public static bool operator <=(Money x, Money y)
    {
      return x._value <= y._value;
    }

    public static bool operator >(Money x, Money y)
    {
      return x._value > y._value;
    }

    public static bool operator >=(Money x, Money y)
    {
      return x._value >= y._value;
    }

    public static Money operator -(Money x, Money y)
    {
      if (x >= y)
      {
        return new Money(x._value - y._value);
      }
      throw new InvalidOperationException("Amount cannot be negative");
    }
  }
}