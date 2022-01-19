namespace GOF.Behavioral.ChainOfResponsibility.Example1
{
  class AddNumber : Chain
  {
    public AddNumber(Chain next)
      : base(next)
    {
    }

    public override int CalculateNumbers(Numbers numbers)
    {
      if (numbers.CalculationWanted == "add")
      {
        return numbers.Number1 + numbers.Number2;
      }
      return base.CalculateNumbers(numbers);
    }
  }
}