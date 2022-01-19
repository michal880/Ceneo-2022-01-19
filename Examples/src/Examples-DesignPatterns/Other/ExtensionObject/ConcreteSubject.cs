using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionObjectPattern
{
  public class ConcreteSubject : Subject
  {
    private Dictionary<Type, Extension> _extensions;

    public ConcreteSubject(IEnumerable<Extension> extensions)
    {
      _extensions = extensions.ToDictionary(f=>f.GetType(), f=> f);      
    }

    public override T GetExtension<T>() 
    {
      if (_extensions.ContainsKey(typeof(T)))
      {
        return _extensions[typeof(T)] as T;
      }

      return base.GetExtension<T>();
    }
  }
}