using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCoupling
{
  public class ListOfCars2
  {
    List<ICar> _list = new List<ICar>(); 

    public void Add(ICar car)
    {
      _list.Add(car);
    }

    public void Display()
    {
      _list.ForEach(c => Console.WriteLine(c.GetName()));
    }
  }

  public interface ICar
  {
    string GetName();
  }

  public class Honda2 : ICar
  {
    private string _type;

    public Honda2(string type)
    {
      _type = type;
    }

    public string GetName()
    {
      return "Honda " + _type;      
    }
  }

  public class Mazda2 : ICar
  {
    private string _type;

    public Mazda2(string type)
    {
      _type = type;
    }

    public string GetName()
    {
      return "Mazda " + _type;
    }
  }
}
