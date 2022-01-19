using System.Web.Mvc;
using AspMvc.Infrastructure.SessionProxy;
using ExamplesMVC5.Controllers.Session;
using SessionWrapper.Models;

namespace SessionWrapper.Controllers
{
  public class MySessionController : SessionController<IMySessionAccess>
  {
    public ActionResult SaveValueToSession()
    {
      Session.StringProp = "alamakota";
      return View();
    }

    public ActionResult ShowValueFromSession()
    {
      return View((object)Session.StringProp);
    }
  }
}