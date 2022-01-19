using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace ModelBinders.Controllers
{
  public class PrincipalBadPracticeController : Controller
  {
    // GET: BadExample
    public ActionResult BadExample1()
    {
      return View();
    }

    public ActionResult BadExample2(IPrincipal principal)
    {
      return View(principal);
    }
  }
}