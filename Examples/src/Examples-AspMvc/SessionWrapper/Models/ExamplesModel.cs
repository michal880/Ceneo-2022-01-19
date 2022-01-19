using System;
using System.Collections.Generic;
using System.Linq;

namespace SessionWrapper.Models
{
  public class ExamplesModel  
  {
    private readonly Type _controllerType;

    public ExamplesModel(Type controllerType)
    {
      _controllerType = controllerType;      
    }

    public string Controller
    {
      get { return _controllerType.Name.Replace("Controller",""); }
    }

    public IEnumerable<string> GetActions()
    {
      var actions =
        _controllerType.GetMethods()
                       .Where(m => m.DeclaringType == _controllerType)
                       .Select(f => f.Name)
                       .ToList();
      return actions;
    }
  }
}