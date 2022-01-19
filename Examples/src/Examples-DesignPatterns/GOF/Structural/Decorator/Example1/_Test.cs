using System;
using NUnit.Framework;

namespace GOF.Structural.Decorator.Example1
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void CreateMargaritaPizza()
    {
      IPizza pizza = new TomatoSouce(new TomatoSouce(new Mozzarella(new ThickPizza())));

      Console.WriteLine("Ingredients: " + pizza.GetDescription());
      Console.WriteLine("Cost: " + pizza.GetCost());
    }
  }
}