namespace GOF.Structural.Decorator.Example1
{
  public class Mozzarella : IPizza
  {
    private readonly IPizza _pizza;

    public Mozzarella(IPizza pizza)
    {
      _pizza = pizza;      
    }

    public string GetDescription()
    {
      return _pizza.GetDescription() + ", Mozzarella";
    }

    public decimal GetCost()
    {
      return _pizza.GetCost() + 2;
    }
  }
}