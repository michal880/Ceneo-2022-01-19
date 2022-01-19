using System.Web.Mvc;
using AspMvc.Examples.Common.Client.Command;
using AspMvc.Examples.Common.Client.Impl;
using AspMvc.Infrastructure.PRGSupport;
using Microsoft.Web.Mvc;
using PRGPattern.Models;

namespace PRGPattern.Controllers
{
  public class ClientCreatePrgController : Controller
  {
    private readonly IClientCommandRepository _clientCommandRepository;

    public ClientCreatePrgController() : this(new ClientRepository())
    {

    }

    public ClientCreatePrgController(IClientCommandRepository clientCommandRepository)
    {
      _clientCommandRepository = clientCommandRepository;
    }

    [HttpGet]
    [PersistModelState]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost]
    [PersistModelState]
    public ActionResult Create(ClientModel clientModel)
    {
      if (!ModelState.IsValid)
      {
        return this.RedirectToAction(f => f.New());
      }
      Client client = new Client();
      client.Name = clientModel.Name;
      _clientCommandRepository.Add(client);
      return this.RedirectToAction<HomeController>(f => f.Index());
    }

    [HttpPost]
    [PersistModelState]
    public ActionResult New(ClientModel clientModel)
    {
      if (!ModelState.IsValid)
      {
        return View(clientModel);         
      }
      Client client = new Client();
      client.Name = clientModel.Name;
      _clientCommandRepository.Add(client);
      return this.RedirectToAction<HomeController>(f => f.Index());
    }
  }
}