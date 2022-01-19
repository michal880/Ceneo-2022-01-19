using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.PassParametersDuringRedirect
{
  public class PassParametersDuringRedirect : IActionFilter
  {
    internal const string StoredParametersKey = "__StoredParameters__";

    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
      var storedParameterValues = filterContext.Controller.TempData[StoredParametersKey] as Dictionary<string, object>;
      if (storedParameterValues == null || !storedParameterValues.Any())
      {
        return;
      }

      var parameters = filterContext.ActionDescriptor.GetParameters();

      foreach (var parameter in parameters)
      {
        object storedParameterValue;
        if (storedParameterValues.TryGetValue(parameter.ParameterName, out storedParameterValue))
        {
          filterContext.ActionParameters[parameter.ParameterName] = storedParameterValue;
        }
      }
    }

    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
      RedirectToRouteResult redirectToRouteResult = filterContext.Result as RedirectToRouteResult;
      if (redirectToRouteResult == null)
      {
        return;
      }

      var parametersToStore = redirectToRouteResult.RouteValues
        .Where(pair => 
          !string.Equals(pair.Key, "action", StringComparison.InvariantCultureIgnoreCase) && 
          !string.Equals(pair.Key, "controller", StringComparison.CurrentCultureIgnoreCase) &&
          !pair.Value.GetType().IsValueType)
        .ToDictionary(pair => pair.Key, pair => pair.Value);

      foreach (KeyValuePair<string, object> keyValuePair in parametersToStore)
      {
        redirectToRouteResult.RouteValues.Remove(keyValuePair.Key);
      }

      filterContext.Controller.TempData[StoredParametersKey] = parametersToStore;
    }
  }
}
