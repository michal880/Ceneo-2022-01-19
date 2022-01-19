using System.Web.Mvc;
using AspMvc.Examples.Common.Client.Impl;
using AspMvc.Examples.Common.Client.Query;

namespace OperationConfirmation.Controllers
{
  public class HomeController : Controller
  {
    private readonly IClientQueryRepository _clientQueryRepository;

    public HomeController() : this(new ClientRepository())
    {
      
    }
    public HomeController(IClientQueryRepository clientQueryRepository)
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