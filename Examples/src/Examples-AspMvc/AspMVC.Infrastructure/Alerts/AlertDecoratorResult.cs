using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.Alerts
{

  public class AlertDecoratorResult : ActionResult
  {
    public ActionResult InnerActionResult { get; }
    public string AlertClass { get; }
    public string Message { get; }

    public AlertDecoratorResult(ActionResult innerActionResult, string alertClass, string message)
    {
      InnerActionResult = innerActionResult;
      AlertClass = alertClass;
      Message = message;
    }

    public override void ExecuteResult(ControllerContext context)
    {
      var alerts = context.Controller.TempData.GetAlerts();
      alerts.Add(new Alert(AlertClass, Message));
      InnerActionResult.ExecuteResult(context);
    }
  }
}
