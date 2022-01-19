using System.Web.Mvc;
using Microsoft.Web.Mvc;

namespace ExamplesMVC5.Controllers.ActionFilters
{
  public class AjaxOnlyGoodExampleController : Controller
  {
    [AjaxOnly]
    public ActionResult AjaxCall()
    {
      return PartialView("AjaxCallView");
    }

    [HttpGet]
    public ActionResult PageWithAjaxCall()
    {
      return View();
    }   
  }
}