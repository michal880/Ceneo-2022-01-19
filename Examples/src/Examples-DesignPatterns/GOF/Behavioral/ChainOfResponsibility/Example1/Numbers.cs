namespace GOF.Behavioral.ChainOfResponsibility.Example1
{
  public class Numbers
  {
    public string CalculationWanted { get; private set; }
    public int Number1 { get; private set; }
    public int Number2 { get; private set; }

    public Numbers(int number1, int number2, string calculationWanted)
    {
      Number1 = number1;
      Number2 = number2;
      CalculationWanted = calculationWanted;
    }


  }
}
