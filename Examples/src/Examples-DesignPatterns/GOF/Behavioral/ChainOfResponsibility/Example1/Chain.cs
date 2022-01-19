using System;

namespace GOF.Behavioral.ChainOfResponsibility.Example1
{
  public abstract class Chain
  {
    readonly protected Chain _next;

    public Chain(Chain next)
    {
      _next = next;
    }

    public virtual int CalculateNumbers(Numbers numbers)
    {
      if (_next != null)
      {
        return _next.CalculateNumbers(numbers);
      }
      throw new NotSupportedException("CalculationWanted not supported : " + numbers.CalculationWanted);
    }
  }
}