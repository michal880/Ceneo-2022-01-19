using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.AjaxValidation
{
  public class AjaxValidationAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      if (filterContext.HttpContext.Request.HttpMethod != "POST" || !filterContext.HttpContext.Request.IsAjaxRequest())
      {
        return;
      }

      if (ValidationDisabled(filterContext.ActionDescriptor))
      {
        return;
      }

      if (filterContext.Controller.ViewData.ModelState.IsValid)
      {
        return;
      }

      var modelState = filterContext.Controller.ViewData.ModelState;
      var errorModel =
        from x in modelState.Keys
        where modelState[x].Errors.Count > 0
        select new
        {
          key = x,
          errors = modelState[x].Errors.
            Select(y => y.ErrorMessage).
            ToArray()
        };
      filterContext.Result = new JsonResult()
      {
        Data = errorModel
      };
      filterContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
      filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

    }

    private static bool ValidationDisabled(ActionDescriptor actionDescriptor)
    {
      return actionDescriptor.GetCustomAttributes(typeof (SkipAjaxValidation), false).Cast<SkipAjaxValidation>().Any();
    }

    public override void OnResultExecuted(ResultExecutedContext filterContext)
    {
      if (filterContext.HttpContext.Response.StatusCode == (int)HttpStatusCode.Redirect
        && filterContext.HttpContext.Request.IsAjaxRequest())
      {
        filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
      }
    }    
  }
}
