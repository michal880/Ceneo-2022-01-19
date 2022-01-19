namespace GOF.Structural.Decorator.Example1
{
  public class ThinPizza : IPizza
  {
    public string GetDescription()
    {
      return "Thin dough";
    }

    public decimal GetCost()
    {
      return 10;
    }
  }
}