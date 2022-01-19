using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LowCoupling
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void DisplayCars()
    {
      Honda honda = new Honda("Accord");
      Mazda mazda = new Mazda("6");

      ListOfCars listOfCars = new ListOfCars(honda, mazda);

      listOfCars.Display();
    }

    [Test]
    public void DisplayCars2()
    {
      Honda2 honda2 = new Honda2("Accord");
      Mazda2 mazda2 = new Mazda2("6");

      ListOfCars2 listOfCars2 = new ListOfCars2();
      listOfCars2.Add(honda2);
      listOfCars2.Add(mazda2);
      

      listOfCars2.Display();
    }
  }

}
    

