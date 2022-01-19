using System.Web.Mvc;

namespace AspMvcSec.Infrastructure
{
  public class RedirectToHttpsAttribute : ActionFilterAttribute, IActionFilter
  {
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      if (!filterContext.HttpContext.Request.IsSecureConnection)
      {
        var url = filterContext.HttpContext.Request.Url.ToString().Replace("http:", "https:");
        filterContext.Result = new RedirectResult(url);
      }
    }
  }
}