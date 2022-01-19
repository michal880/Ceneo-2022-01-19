using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspMvc.Infrastructure.ManySubmitButtons;
using ManySubmitButtons.Models;
using Microsoft.Web.Mvc;

namespace ManySubmitButtons.Controllers
{
  public class GoodScenarioController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }
    
    [HttpPost]
    public ActionResult Ok(AddressModel address)
    {
      return this.RedirectToAction<HomeController>(f => f.Index());
    }
    
    [HttpPost]
    public ActionResult Cancel()
    {
      return this.RedirectToAction(f => f.Index());
    }
  }
}