using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace AspMvc.Infrastructure.FormExtensions
{
  public static class HtmlHelperExtensions
  {
    public static MvcForm BeginForm<TController>(this HtmlHelper htmlHelper,
      Expression<Action<TController>> action, object htmlAttributes = null) where TController : Controller
    {
      RouteValueDictionary trouteValues = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression<TController>(action);
      return htmlHelper.BeginForm(trouteValues["Action"].ToString(), trouteValues["Controller"].ToString(), trouteValues, FormMethod.Post, htmlAttributes);
    }
  }
}