using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Microsoft.Web.Mvc;
using ExpressionHelper = Microsoft.Web.Mvc.Internal.ExpressionHelper;

namespace AspMvc.Infrastructure.ManySubmitButtons
{
  public static class HtmlExtensions
  {
    public static MvcHtmlString SubmitActionButton<TController>(this HtmlHelper htmlHelper, Expression<Action<TController>> action, string text, object htmlAttributes = null) where TController : Controller
    {
      RouteValueDictionary routeValuesFromExpression = ExpressionHelper.GetRouteValuesFromExpression(action);
      return htmlHelper.SubmitButton(SubmitActionNameConsts.SubmittedActionNamePrefix + routeValuesFromExpression["Action"], text, htmlAttributes);
    }

    public static MvcForm BeginActionForm(this HtmlHelper htmlHelper)
    {
      return BeginActionForm(htmlHelper, FormMethod.Post, null);
    }

    public static MvcForm BeginActionForm(this HtmlHelper htmlHelper, FormMethod formMethod, object htmlAttributes)
    {
      return htmlHelper.BeginForm(Guid.NewGuid().ToString(),
        htmlHelper.ViewContext.RouteData.GetRequiredString("controller"), formMethod, htmlAttributes);
    }
  }
}
