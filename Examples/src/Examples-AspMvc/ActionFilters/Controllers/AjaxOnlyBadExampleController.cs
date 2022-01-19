using System.Web.Mvc;
using Microsoft.Web.Mvc;

namespace ExamplesMVC5.Controllers.ActionFilters
{
  public class AjaxOnlyBadExampleController : Controller
  {
    [HttpGet]
    public ActionResult PageWithAjaxCall()
    {
      if (Request.IsAjaxRequest())
      {
        return PartialView("AjaxCallView");
      }
      else
      {
        return View("PageWithAjaxCall");
      }
    }

    
  }
}