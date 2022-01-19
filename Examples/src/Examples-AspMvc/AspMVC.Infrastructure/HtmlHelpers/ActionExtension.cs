using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace AspMvc.Infrastructure.HtmlHelpers
{
  public static class ActionExtension
  {
    public static MvcHtmlString Action<TController>(this HtmlHelper htmlHelper,
        Expression<Action<TController>> action,
        RouteValueDictionary routeValues) where TController : Controller
    {
      RouteValueDictionary trouteValues = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression<TController>(action);
      return htmlHelper.Action(trouteValues["action"].ToString(), trouteValues["controller"].ToString(), routeValues);     
    }

    public static MvcHtmlString Action<TController>(this HtmlHelper htmlHelper,
        Expression<Action<TController>> action) where TController : Controller
    {
      RouteValueDictionary trouteValues = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression<TController>(action);
      return htmlHelper.Action(trouteValues["Action"].ToString(), trouteValues["Controller"].ToString(),trouteValues);
    }
  }
}