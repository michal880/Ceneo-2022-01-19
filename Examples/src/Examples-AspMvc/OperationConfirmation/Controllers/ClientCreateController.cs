using System.Web.Mvc;
using AspMvc.Examples.Common.Client.Command;
using AspMvc.Examples.Common.Client.Impl;
using AspMvc.Infrastructure.Alerts;
using Microsoft.Web.Mvc;
using OperationConfirmation.Models;

namespace OperationConfirmation.Controllers
{
  public class ClientCreateController : Controller
  {
    private readonly IClientCommandRepository _clientCommandRepository;

    public ClientCreateController() : this(new ClientRepository())
    {
      
    }
    public ClientCreateController(IClientCommandRepository clientCommandRepository)
    {
      _clientCommandRepository = clientCommandRepository;
    }

    [HttpGet]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(ClientModel clientModel)
    {
      if (!ModelState.IsValid)
      {
        return View("New", clientModel);
      }
      Client client = new Client();
      client.Name = clientModel.Name;
      _clientCommandRepository.Add(client);
      return this.RedirectToAction<HomeController>(f => f.Index()).WithSuccess("Client added");
    }
  }
}