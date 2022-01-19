using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspMvc.Examples.Common.Client.Command;
using AspMvc.Examples.Common.Client.Impl;
using AspMvc.Infrastructure.AjaxValidation;
using Microsoft.Web.Mvc;

namespace ValidationFilter.Controllers
{
  public class ClientCreateValidationFilterController : Controller
  {
    private readonly IClientCommandRepository _clientCommandRepository;

    public ClientCreateValidationFilterController() : this(new ClientRepository())
    {

    }

    public ClientCreateValidationFilterController(IClientCommandRepository clientCommandRepository)
    {
      _clientCommandRepository = clientCommandRepository;
    }

    [HttpGet]
    public ActionResult New()
    {
      return View();
    }

    [AjaxOnly]
    [AjaxValidation]
    public ActionResult Create(ClientModel clientModel)
    {
      Client client = new Client();
      client.Name = clientModel.Name;
      _clientCommandRepository.Add(client);
      return this.RedirectToAction<HomeController>(f => f.Index());
    }   
  }
}