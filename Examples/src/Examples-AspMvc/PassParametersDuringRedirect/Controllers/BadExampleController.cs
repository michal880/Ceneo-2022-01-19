using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using PassParametersDuringRedirect.Models;

namespace PassParametersDuringRedirect.Controllers
{
  public class BadExampleController : Controller
  {
    // GET: BadExample
    public ActionResult Scenario1()
    {
      ClientModel m = new ClientModel()
      {
        Age = 23,
        Name = "Ala Makotowska",
        Sex = Sex.Unknown
      };

      Session["x"] = m;

      return this.RedirectToAction(f=>f.MyAction());
    }

    public ActionResult MyAction()
    {
      ClientModel model = Session["x"] as ClientModel;

      return View("ClientModelView", model);
    }

    public ActionResult Scenario2()
    {
      ClientModel m = new ClientModel()
      {
        Age = 23,
        Name = "Ala Makotowska",
        Sex = Sex.Unknown
      };

      TempData["x"] = m;

      return this.RedirectToAction(f => f.MyAction2());
    }

    public ActionResult MyAction2()
    {
      ClientModel model = TempData["x"] as ClientModel;

      return View("ClientModelView",model);
    }
  }
}