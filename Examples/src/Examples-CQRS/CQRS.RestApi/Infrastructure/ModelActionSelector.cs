using System.Linq;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;

namespace CQRS.RestApi.Infrastructure
{
    public class ModelActionSelector : ActionMethodSelectorAttribute
    {
      public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
      {
        if(routeContext.HttpContext.Request.Headers.ContainsKey("Content-Type"))
        {
          string contentType = routeContext.HttpContext.Request.Headers["Content-Type"];
          if (contentType.Contains("domain-model"))
          {
            var strings = contentType.Split(';').SelectMany(f => f.Split('='));
            if (strings.Any(f => action.Parameters.Any(c => c.ParameterType.Name == f.Trim())))
            {
              return true;
            }
            return false;
          }
        }
        return true;
      }
    }
}
