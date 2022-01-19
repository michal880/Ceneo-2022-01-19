using System.Web.Mvc;
using AspMvc.Examples.Common.Client.Command;
using AspMvc.Examples.Common.Client.Impl;
using AspMvc.Infrastructure.PRGSupport;
using Microsoft.Web.Mvc;
using PRGPattern.Models;

namespace PRGPattern.Controllers
{
  public class ClientCreatePrgWithOneButtonController : Controller
  {
    private readonly IClientCommandRepository _clientCommandRepository;

    public ClientCreatePrgWithOneButtonController() : this(new ClientRepository())
    {

    }

    public ClientCreatePrgWithOneButtonController(IClientCommandRepository clientCommandRepository)
    {
      _clientCommandRepository = clientCommandRepository;
    }

    [HttpGet]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost]
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