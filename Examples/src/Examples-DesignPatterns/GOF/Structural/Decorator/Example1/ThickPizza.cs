namespace GOF.Structural.Decorator.Example1
{
  public class ThickPizza : IPizza
  {
    public string GetDescription()
    {
      return "Thick doug";
    }

    public decimal GetCost()
    {
      return 20;
    }
  }
}