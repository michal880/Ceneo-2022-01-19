using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace ExamplesMVC5.Controllers._1Routing
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult GetDataFromRoutData()
    {
      var controller = RouteData.Values["controller"];
      var action = RouteData.Values["action"];

      ViewBag.Message = string.Format("Controller : {0}, action : {1}", controller, action);

      return View();
    }

    public ActionResult RedirectToRoute()
    {
      return RedirectToRoute("special", new { action = "Index" });
    }

    public ActionResult LanguageEmeded()
    {
      return Redirect("/en-us/Routing/Index");
    }

    public ActionResult Back()
    {
      return Redirect(Request.UrlReferrer.AbsoluteUri);
    }
  }
}