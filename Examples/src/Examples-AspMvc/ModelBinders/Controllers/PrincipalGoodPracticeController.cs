using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using ModelBinders.Models;

namespace ModelBinders.Controllers
{
  public class PrincipalGoodPracticeController : Controller
  {
    public ActionResult Index(IPrincipal principal)
    {
      if (principal.Identity.IsAuthenticated)
      {
        return View("Authenticated");
      }
      else
      {
        return View("NotAuthenticated");
      }
    }    
  }
}