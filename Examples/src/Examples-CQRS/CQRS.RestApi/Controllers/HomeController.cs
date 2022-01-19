using Microsoft.AspNetCore.Mvc;

namespace CQRS.RestApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("index.html");
        }        
    }
}
