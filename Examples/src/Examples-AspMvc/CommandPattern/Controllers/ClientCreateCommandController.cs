using System.Web.Mvc;
using AspMvc.Examples.Common.Client.Impl;
using AspMvc.Infrastructure.CommandHandler;
using AspMvc.Infrastructure.PRGSupport;
using Castle.MicroKernel;
using CommandPattern.Controllers.CreateClient;
using CommandPattern.Models;
using Microsoft.Web.Mvc;

namespace CommandPattern.Controllers
{
  public class ClientCreateCommandController : Controller
  {
    private readonly ICommandHandler<ClientCreateCommand> _createClientCommandHandler;

    // Shoud be IoC. Simplified for this example
    public ClientCreateCommandController() : this(new ClientCreateCommandHandler(new ClientRepository()))
    {
      
    }
    public ClientCreateCommandController(ICommandHandler<ClientCreateCommand> createClientCommandHandler)
    {
      _createClientCommandHandler = createClientCommandHandler;     
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
      _createClientCommandHandler.Handle(clientCreateCommand);

      return this.RedirectToAction<HomeController>(f => f.Index());
    }
  }

  public class TransactionDecorator<T> : ICommandHandler<T>
  {
    private ICommandHandler<T> _handler;

    public void Handle(T command)
    {
      //beginTran
      _handler.Handle(command);
      //commit
    }
  }
}