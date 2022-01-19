using System.Web.Helpers;
using System.Web.Mvc;
using AspMvcSec.Infrastructure;
using NWebsec.Mvc.HttpHeaders;
using NWebsec.Mvc.HttpHeaders.Csp;

namespace AspMvcSec
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());

      #region CSP
      //filters.Add(new CspAttribute());
      //filters.Add(new CspDefaultSrcAttribute()
      //{
      //  CustomSources = "localhost:* ws://localhost:* code.jquery.com:*",
      //});
      //filters.Add(new CspScriptSrcAttribute()
      //{
      //  CustomSources = "localhost:* ws://localhost:* code.jquery.com:*",
      //  UnsafeInline = true,
      //});
      //filters.Add(new CspStyleSrcAttribute()
      //{
      //  CustomSources = "localhost:* ws://localhost:* code.jquery.com:*",
      //  UnsafeInline = true,
      //});

      //filters.Add(new CspReportUriAttribute(){ ReportUris  = "http://localhost:50297/Report" });

      #endregion

      #region XFrameOptions

      // XFrameOptions
      //filters.Add(new XFrameOptionsAttribute() { Policy = XFrameOptionsPolicy.Deny });

      #endregion

      #region hsts
      // filters.Add(new RedirectToHttpsAttribute());
      #endregion
    }
  }
}
