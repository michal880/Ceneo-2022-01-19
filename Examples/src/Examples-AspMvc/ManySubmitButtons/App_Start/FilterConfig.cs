using System.Web;
using System.Web.Mvc;
using AspMvc.Infrastructure.ManySubmitButtons;

namespace ManySubmitButtons
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
      //filters.Add(new HttpMethodNameSubmitAttribute());
    }
  }
}
