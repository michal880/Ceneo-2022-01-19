using System.Security.Principal;
using System.Web.Mvc;
using AspMvc.Infrastructure.PrincipalBinding;

namespace ModelBinders
{
  public class ModelBinderConfig
  {
    public static void Configure(ModelBinderDictionary binders)
    {
      binders[typeof(IPrincipal)] = new PrincipalModelBinder();      
    }
  }

  
}