using System;
using System.Web.Http.Cors;
using System.Web.Mvc;
using AspMvcSec.DataAccess;
using AspMvcSec.Models;
using NWebsec.Mvc.HttpHeaders;

namespace AspMvcSec.Controllers
{
  //// CORS
  [EnableCors("*","","")]
  public class UsersController : Controller
  { 
    private IUserRepository _repository;

    public UsersController() : this(new UserRepository())
    {
      
    }
    public UsersController(IUserRepository repository)
    {
      _repository = repository;
    }

    // GET: UserList
    public ActionResult Index()
    {
      return View(_repository.GetAll());
    }

    [HttpGet]
    [ActionName("Create")]
    public ActionResult CreateGet(User user)
    {
      return View(user);
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
      _repository.Delete(id);
      return RedirectToAction("Index");
    }

    // POST: UserList/Create
    #region // CSRF
    //[ValidateAntiForgeryToken]
    #endregion
    [HttpPost]
    public ActionResult Create(User user)
    {
      try
      {
        _repository.Add(user);

        return RedirectToAction("Index");
      }
      catch(Exception ex)
      {
        return View();
      }
    }
  }
}
