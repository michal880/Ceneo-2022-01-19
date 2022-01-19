namespace GOF.Structural.Decorator.Example1
{
  public class TomatoSouce : IPizza
  {
    private readonly IPizza _pizza;

    public TomatoSouce(IPizza pizza)
    {
      _pizza = pizza;
    }

    public string GetDescription()
    {
      return _pizza.GetDescription() + ", TomatoSouce";
    }

    public decimal GetCost()
    {
      return _pizza.GetCost()+1;
    }
  }
}