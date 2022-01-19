namespace DDD.Policy
{
  public class ColorCostCalculator : ICostCalculatorPolicy
  {
    public Money Calculate(int numberOfPages)
    {
      return numberOfPages * 1.50;
    }
  }
}