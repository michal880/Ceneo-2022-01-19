using System.Web.Mvc;
using Routing.Models;

namespace ExamplesMVC5.Controllers._1Routing
{
  public class LanguageRouteController : Controller
  {
    public ActionResult IndexByLanguage(string country, string lang)
    {
      ViewBag.Country = country;
      ViewBag.Lang = lang;
      return View(new LanguageModel(country, lang));
    }


  }
}