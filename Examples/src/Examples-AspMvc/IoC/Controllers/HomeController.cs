using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspMvc.Infrastructure.CommandHandler;

namespace IoC.Controllers
{
  public class HomeController : Controller
  {
    private ICommandHandler<string> _commandHandler;

    public HomeController(ICommandHandler<string> commandHandler)
    {
      _commandHandler = commandHandler;
    }

    public ActionResult Index()
    {
      return View();
    }
  }
}