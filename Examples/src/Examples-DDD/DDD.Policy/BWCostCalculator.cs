namespace DDD.Policy
{
  public class BWCostCalculator : ICostCalculatorPolicy
  {
    public Money Calculate(int numberOfPages)
    {
      return numberOfPages * 0.80;
    }
  }
}