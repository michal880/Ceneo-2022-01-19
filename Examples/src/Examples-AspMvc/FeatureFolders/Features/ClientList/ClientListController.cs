using System.Web.Mvc;
using AspMvc.Examples.Common.Client.Impl;
using AspMvc.Examples.Common.Client.Query;
using CRM.Areas.ClientList.Models;
using Microsoft.Web.Mvc;

namespace FeatureFolders.Features.ClientList
{
  public class ClientListController : Controller
  {
    private readonly IClientQueryRepository _clientQueryRepository;

    public ClientListController() : this(new ClientRepository())
    {
      
    }
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