using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.ManySubmitButtons
{
  public class SubmitActionNameActionInvoker : IActionInvoker
  {
    private readonly IActionInvoker _actionInvoker;

    public SubmitActionNameActionInvoker(IActionInvoker actionInvoker)
    {
      if (actionInvoker == null)
      {
        throw new ArgumentNullException("actionInvoker");
      }

      _actionInvoker = actionInvoker;
    }

    public bool InvokeAction(ControllerContext controllerContext, string actionName)
    {
      var submittedAction = controllerContext.HttpContext.Request.Form.AllKeys.FirstOrDefault(key => key != null && key.StartsWith(SubmitActionNameConsts.SubmittedActionNamePrefix));
      if (submittedAction != null)
      {
        var submittedActionName = submittedAction.Substring(SubmitActionNameConsts.SubmittedActionNamePrefix.Length).ToLower();
        controllerContext.RouteData.Values["action"] = submittedActionName;
        return _actionInvoker.InvokeAction(controllerContext, submittedActionName);
      }

      return _actionInvoker.InvokeAction(controllerContext, actionName);
    }
  }
}
