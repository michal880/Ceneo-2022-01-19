using System;
using System.Security.Principal;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.PrincipalBinding
{
  public class PrincipalModelBinder : IModelBinder
  {
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
      if (controllerContext == null)
      {
        throw new ArgumentNullException("controllerContext");
      }
      if (bindingContext == null)
      {
        throw new ArgumentNullException("bindingContext");
      }
      IPrincipal p = controllerContext.HttpContext.User;
      return p;
    }
  }
}