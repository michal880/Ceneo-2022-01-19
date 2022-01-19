using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace KRD.Infrastructure.AspMvc.AntiForgeryTokens
{
  public class AntiForgeryTokensConfig
  {
    /// <summary>
    /// Configures the anti-forgery tokens. See 
    /// http://www.asp.net/mvc/overview/security/xsrfcsrf-prevention-in-aspnet-mvc-and-web-pages
    /// </summary>
    public static void Configure()
    {
      // Rename the Anti-Forgery cookie from "__RequestVerificationToken" to "f". This adds a little security 
      // through obscurity and also saves sending a few characters over the wire. Sadly there is no way to change 
      // the form input name which is hard coded in the @Html.AntiForgeryToken helper and the 
      // ValidationAntiforgeryTokenAttribute to  __RequestVerificationToken.
      // <input name="__RequestVerificationToken" type="hidden" value="..." />
      AntiForgeryConfig.CookieName = "f";

      // If you have enabled SSL. Uncomment this line to ensure that the Anti-Forgery 
      // cookie requires SSL to be sent across the wire. 
      AntiForgeryConfig.RequireSsl = true;
    }  
  }
}
