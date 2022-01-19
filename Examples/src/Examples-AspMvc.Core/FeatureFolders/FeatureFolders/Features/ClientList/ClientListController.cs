using CRM.Areas.ClientList.Models;
using FeatureFolders.Implementation.Client.Impl;
using FeatureFolders.Implementation.Client.Query;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFolders.Features.ClientList
{
  public class ClientListController : Controller
  {
    private readonly IClientQueryRepository _clientQueryRepository;

    public ClientListController(IClientQueryRepository clientQueryRepository)
    {
      _clientQueryRepository = clientQueryRepository;
    }

    public ActionResult Index()
    {
      ClientListQuery clientListQuery = new ClientListQuery();
      clientListQuery.Clients = _clientQueryRepository.GetAll();
      return View(clientListQuery);
    }
  }
}