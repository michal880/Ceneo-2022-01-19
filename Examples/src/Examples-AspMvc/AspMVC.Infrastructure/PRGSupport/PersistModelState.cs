using System.Web.Mvc;

namespace AspMvc.Infrastructure.PRGSupport
{
  public class PersistModelState : ActionFilterAttribute
  {
    protected static readonly string Key = typeof(PersistModelState).FullName;

    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
      if (filterContext.HttpContext.Request.HttpMethod == "POST")
      {
        //Only export when ModelState is not valid
        if (!filterContext.Controller.ViewData.ModelState.IsValid)
        {
          //Export if we are redirecting
          if ((filterContext.Result is RedirectResult) || (filterContext.Result is RedirectToRouteResult))
          {
            filterContext.Controller.TempData[Key] = filterContext.Controller.ViewData.ModelState;
          }
        }
      }

      if (filterContext.HttpContext.Request.HttpMethod == "GET")
      {
        ModelStateDictionary modelState = filterContext.Controller.TempData[Key] as ModelStateDictionary;

        if (modelState != null)
        {
          //Only Import if we are viewing
          if (filterContext.Result is ViewResult)
          {
            filterContext.Controller.ViewData.ModelState.Merge(modelState);
          }
          else
          {
            //Otherwise remove it.
            filterContext.Controller.TempData.Remove(Key);
          }
        }
      }

      base.OnActionExecuted(filterContext);
    }
  }
}