using System.Web.Mvc;
using All_In_One.Features.ClientList.Query;

namespace All_In_One.Features.ClientList
{
  public class ClientListController : Controller
  {
    private readonly IQueryHandler<ClientListQuery> _queryHandler;
    
    public ClientListController(IQueryHandler<ClientListQuery> queryHandler)
    {
      _queryHandler = queryHandler;
    }

    public ActionResult Index()
    {
      return View(_queryHandler.Handle());
    }
  }
}