namespace GOF.Behavioral.ChainOfResponsibility.Example1
{
  public class MultiplyNumbers : Chain
  {
    public MultiplyNumbers(Chain next)
      : base(next)
    {
    }

    public override int CalculateNumbers(Numbers numbers)
    {
      if (numbers.CalculationWanted == "multiply")
      {
        return numbers.Number1 * numbers.Number2;
      }
      return base.CalculateNumbers(numbers);
    }
  }
}