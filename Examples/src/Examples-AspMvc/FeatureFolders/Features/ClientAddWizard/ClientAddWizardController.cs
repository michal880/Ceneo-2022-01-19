using System.Web.Mvc;
using AspMvc.Examples.Common.Client.Command;
using AspMvc.Examples.Common.Client.Impl;
using FeatureFolders.Features.ClientList;
using FeatureFolders.Features.Home;
using Microsoft.Web.Mvc;

namespace FeatureFolders.Features.ClientAddWizard
{
  public class ClientAddWizardController : Controller
  {
    private readonly IClientCommandRepository _clientCommandRepository;

    public ClientAddWizardController() : this(new ClientRepository())
    {

    }
    public ClientAddWizardController(IClientCommandRepository clientCommandRepository)
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
      return this.RedirectToAction<ClientListController>(f => f.Index());
    }
  }
}