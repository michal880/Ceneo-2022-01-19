using System;
using System.Collections.Generic;
using System.Linq;

namespace RoleObjectDesignPattern
{
  public class Animal
  {
    private readonly IList<IAnimalSkill> _roles = new List<IAnimalSkill>();

    public Animal(IList<IAnimalSkill> roles)
    {
      _roles = roles;
    }

    public void AddRole(IAnimalSkill role)
    {
      _roles.Add(role);
    }

    public T Skill<T>() where T : class, IAnimalSkill
    {
      return _roles.FirstOrDefault(x => x is T) as T;
    }

    public bool Can<T>()
    {
      return _roles.Any(f => f is T);
    }
  }
}