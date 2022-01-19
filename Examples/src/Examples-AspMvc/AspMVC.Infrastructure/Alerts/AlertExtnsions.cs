using System.Collections.Generic;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.Alerts
{
  public static class AlertExtensions
  {
    public const string Alerts = "_alerts";

    public static List<Alert> GetAlerts(this TempDataDictionary tempData)
    {
      if (!tempData.ContainsKey(Alerts))
      {
        tempData[Alerts] = new List<Alert>();
      }

      return (List<Alert>) tempData[Alerts];
    }

    public static ActionResult WithSuccess(this ActionResult result, string message)
    {
      return new AlertDecoratorResult(result, "alert-success", message);
    }

    public static ActionResult WithError(this ActionResult result, string message)
    {
      return new AlertDecoratorResult(result, "alert-danger", message);
    }

    public static ActionResult WithWarning(this ActionResult result, string message)
    {
      return new AlertDecoratorResult(result, "alert-warning", message);
    }

    public static ActionResult WithInfo(this ActionResult result, string message)
    {
      return new AlertDecoratorResult(result, "alert-info", message);
    }

  }
}