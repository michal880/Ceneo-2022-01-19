using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ManySubmitButtons.Models;
using Microsoft.Web.Mvc;

namespace ManySubmitButtons.Controllers
{
  public class BadScenarioController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(AddressModel model, string submit)
    {
      switch (submit)
      {
        case "Ok":
          return this.RedirectToAction<HomeController>(f => f.Index());
        case "Cancel":
          return this.RedirectToAction(f => f.Index());
        default:
          throw new NotSupportedException();
      }      
    }
  }
}