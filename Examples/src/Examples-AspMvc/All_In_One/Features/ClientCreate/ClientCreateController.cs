using System.Web.Mvc;
using All_In_One.Features.ClientCreate.Command;
using All_In_One.Features.ClientList;
using All_In_One.Features.Home;
using AspMvc.Examples.Common.Client.Impl;
using AspMvc.Infrastructure.CommandHandler;
using Microsoft.Web.Mvc;

namespace All_In_One.Features.ClientCreate
{
  public class ClientCreateController : Controller
  {
    private readonly ICommandHandler<ClientCreateCommand> _createClientCommandHandler;

    public ClientCreateController(ICommandHandler<ClientCreateCommand> createClientCommandHandler)
    {
      _createClientCommandHandler = createClientCommandHandler;
    }

    [HttpGet]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(ClientCreateCommand clientCreateCommand)
    {
      _createClientCommandHandler.Handle(clientCreateCommand);

      return this.RedirectToAction<ClientListController>(f => f.Index());
    }
  }
}