using System.Web.Mvc;

namespace FeatureFolders.Features.Home
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }    
  }
}