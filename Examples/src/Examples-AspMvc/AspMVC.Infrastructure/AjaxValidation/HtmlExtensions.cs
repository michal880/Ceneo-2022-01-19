using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.WebPages;
using Microsoft.Web.Mvc;

namespace AspMvc.Infrastructure.AjaxValidation
{
  public static class HtmlHelperExtensions
  {
    public static MvcForm BeginAjaxValidationForm<TController>(this HtmlHelper htmlHelper,
      Expression<Action<TController>> action, object htmlAttributes = null) where TController : Controller
    {
      RouteValueDictionary attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
      attributes["id"] = "AjaxValidationForm";
      
      
      return htmlHelper.BeginForm<TController>(action, FormMethod.Post, attributes);
    }

    public static string GetScriptFromResource()
    {
      Assembly assembly = typeof (HtmlHelperExtensions).Assembly;
      string tempResourceName = assembly.GetManifestResourceNames().ToList().FirstOrDefault(f => f.EndsWith("AjaxValidation.js"));
      StreamReader sr = new StreamReader(assembly.GetManifestResourceStream(tempResourceName));
      try
      {
        return sr.ReadToEnd();
      }
      finally
      {
        sr.Dispose();
      }
    }

    public static MvcHtmlString RenderAjaxValidationScript(this HtmlHelper htmlHelper)
    {
      return new MvcHtmlString("<script type=\"text/javascript\">"+ GetScriptFromResource() + "</script>");
    }
  }
}