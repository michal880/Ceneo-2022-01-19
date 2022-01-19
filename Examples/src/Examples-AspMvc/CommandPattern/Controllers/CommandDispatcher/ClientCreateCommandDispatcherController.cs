using System.Web.Mvc;
using AspMvc.Examples.Common.Client.Impl;
using AspMvc.Infrastructure.PRGSupport;
using CommandPattern.Controllers.CreateClient;
using CommandPattern.Models;
using Microsoft.Web.Mvc;

namespace CommandPattern.Controllers
{
  public class ClientCreateCommandDispatcherController : Controller
  {
    private readonly ICommandDispatcher _commandDispatcher;

    public ClientCreateCommandDispatcherController(ICommandDispatcher commandDispatcher)
    {
      _commandDispatcher = commandDispatcher;     
    }

    [HttpGet]
    [PersistModelState]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost]
    [PersistModelState]
    public ActionResult Create(ClientCreateCommand clientCreateCommand)
    {
      if (!ModelState.IsValid)
      {
        return this.RedirectToAction(f => f.New());
      }
      _commandDispatcher.Handle(clientCreateCommand);

      return this.RedirectToAction<HomeController>(f => f.Index());
    }
  }
}