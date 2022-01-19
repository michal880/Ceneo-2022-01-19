using System.Web;
using System.Web.Mvc;

namespace PassParametersDuringRedirect
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
      filters.Add(new AspMvc.Infrastructure.PassParametersDuringRedirect.PassParametersDuringRedirect());
    }
  }
}
