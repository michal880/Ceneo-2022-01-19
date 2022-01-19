using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCoupling
{
  public class ListOfCars
  {
    private Honda _honda;
    private Mazda _mazda;

    public ListOfCars(Honda honda, Mazda mazda)
    {
      _honda = honda;
      _mazda = mazda;
    }

    public void Display()
    {
      Console.WriteLine(_honda);
      Console.WriteLine(_mazda);
    }
  }

  public class Honda
  {
    private string _type;

    public Honda(string type)
    {
      _type = type;
    }

    public override string ToString()
    {
      return "Honda " + _type;      
    }
  }

  public class Mazda
  {
    private string _type;

    public Mazda(string type)
    {
      _type = type;
    }

    public override string ToString()
    {
      return "Mazda " + _type;
    }
  }
}
