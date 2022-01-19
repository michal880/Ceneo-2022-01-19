using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using AspMvcSec.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace AspMvcSec.Controllers
{
  public class AccountController : Controller
  {
    private IUserRepository _userRespository;

    public AccountController() : this(new UserRepository())
    {
      
    }

    public AccountController(IUserRepository userRespository)
    {
      _userRespository = userRespository;
    }

    // GET: Login
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Login(string login, string password)
    {
      if (_userRespository.Login(login, password))
      {
        var ident = new ClaimsIdentity(
          new[] { 
              // adding following 2 claim just for supporting default antiforgery provider
              new Claim(ClaimTypes.NameIdentifier, login),
              new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),

              new Claim(ClaimTypes.Name,login)              
          },
          DefaultAuthenticationTypes.ApplicationCookie);

        HttpContext.GetOwinContext().Authentication.SignIn(
           new AuthenticationProperties { IsPersistent = false }, ident);

        return RedirectToAction("Index", "Home");
      }
      ModelState.AddModelError("login", "Invalid login or password");
      return View();
    }

    public ActionResult Logoff()
    {
      HttpContext.GetOwinContext().Authentication.SignOut();
      return RedirectToAction("Login");
    }
  }
}