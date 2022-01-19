using System;

namespace RoleObjectDesignPattern
{
  public class Roar : IAnimalSkill
  {
    public string Name { get { return "Roar"; } }

    public void MakeRoar()
    {
      Console.WriteLine("Roar");
    }
  }
}