namespace GOF.Behavioral.ChainOfResponsibility.Example1
{
  class SubstractNumber : Chain
  {
    public SubstractNumber(Chain next)
      : base(next)
    {
    }

    public override int CalculateNumbers(Numbers numbers)
    {
      if (numbers.CalculationWanted == "substract")
      {
        return numbers.Number1 - numbers.Number2;
      }
      return base.CalculateNumbers(numbers);
    }
  }
}