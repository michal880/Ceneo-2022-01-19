using System.Web;
using System.Web.Mvc;
using AspMvc.Infrastructure.AjaxValidation;

namespace All_In_One
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
      filters.Add(new AjaxValidationAttribute());
    }
  }
}
