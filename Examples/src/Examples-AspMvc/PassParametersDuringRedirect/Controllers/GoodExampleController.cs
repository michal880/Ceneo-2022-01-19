using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using PassParametersDuringRedirect.Models;

namespace PassParametersDuringRedirect.Controllers
{
  public class GoodExampleController : Controller
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

      return this.RedirectToAction(f=>f.MyAction(m));
    }

    public ActionResult MyAction(ClientModel model)
    {
      return View("ClientModelView", model);
    }

    public ActionResult Scenario2_ValueTypes_though_QueryString()
    {
      ClientModel m = new ClientModel()
      {
        Age = 23,
        Name = "Ala Makotowska",
        Sex = Sex.Unknown
      };

      return this.RedirectToAction(f => f.MyAction2(m.Name, m.Age,m.Sex));
    }

    public ActionResult MyAction2(string name, int age, Sex sex)
    {
      return View("ClientModelView", new ClientModel()
      {
        Name = name,
        Age = age,
        Sex = sex
      });
    }
  }


}