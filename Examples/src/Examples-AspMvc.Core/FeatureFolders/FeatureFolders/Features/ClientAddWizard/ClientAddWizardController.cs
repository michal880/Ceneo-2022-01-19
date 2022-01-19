
using FeatureFolders.Implementation.Client.Command;
using FeatureFolders.Implementation.Client.Impl;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFolders.Features.ClientAddWizard
{
  public class ClientAddWizardController : Controller
  {
    private readonly IClientCommandRepository _clientCommandRepository;
    
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
      return RedirectToAction("Index","ClientList");
    }
  }
}