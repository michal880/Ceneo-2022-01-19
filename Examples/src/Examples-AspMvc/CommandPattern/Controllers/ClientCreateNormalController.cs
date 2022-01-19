using System.Web.Mvc;
using AspMvc.Examples.Common.Client.Command;
using AspMvc.Examples.Common.Client.Impl;
using CommandPattern.Models;
using Microsoft.Web.Mvc;

namespace CommandPattern.Controllers
{
  public class ClientCreateNormalController : Controller
  {
    private readonly IClientCommandRepository _clientCommandRepository;

    public ClientCreateNormalController() : this(new ClientRepository())
    {
      
    }
    public ClientCreateNormalController(IClientCommandRepository clientCommandRepository)
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
      return this.RedirectToAction<HomeController>(f => f.Index());
    }
  }
}