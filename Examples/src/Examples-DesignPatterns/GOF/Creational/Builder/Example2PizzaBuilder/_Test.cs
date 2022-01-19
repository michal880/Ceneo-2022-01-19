using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF.Creational.Builder.Example2PizzaBuilder
{
  internal class _Test
  {
    public void Test1()
    {
      PizzaBuilder pizzaBuilder = PizzaBuilder
        .ThinPizza()
        .WithMozzarella()
        .WithTomatoSouce();

      var pizza = pizzaBuilder.GetPizza();

      pizza.GetCost();
      pizza.GetDescription();
    }
  }
}