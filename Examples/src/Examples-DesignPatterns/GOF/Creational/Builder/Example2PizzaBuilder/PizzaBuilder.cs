using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOF.Structural.Decorator.Example1;

namespace GOF.Creational.Builder.Example2PizzaBuilder
{
  public class PizzaBuilder : IOnlyGetResult
  {
    private IPizza _pizza;

    private PizzaBuilder(IPizza pizza)
    {
      _pizza = pizza;
    }

    public static PizzaBuilder ThinPizza()
    {
      return new PizzaBuilder(new ThinPizza());
    }

    public IOnlyGetResult WithMozzarella(Action<MozzarellaBuilder> action)
    {
      _pizza = new Mozzarella(_pizza);
      return this;
    }

    public IPizza GetPizza()
    {
      return _pizza;
    }

    public PizzaBuilder WithTomatoSouce()
    {
      _pizza = new TomatoSouce(_pizza);
      return this;
    }
  }
}