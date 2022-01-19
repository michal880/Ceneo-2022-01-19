using System.Collections.Generic;

namespace RoleObjectDesignPattern
{
  internal class Lion : Animal
  {
    public Lion()
      : base(new List<IAnimalSkill>() { new Roar() })
    {
    }
  }
}