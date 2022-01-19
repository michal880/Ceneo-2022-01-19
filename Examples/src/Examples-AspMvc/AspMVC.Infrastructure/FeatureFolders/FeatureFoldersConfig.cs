using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.FeatureFolders
{
  /// <summary>
  /// http://timgthomas.com/2013/10/feature-folders-in-asp-net-mvc/
  /// </summary>
  public class FeatureFoldersConfig
  {
    public static void Configure(ViewEngineCollection engines)
    {
      var razorEngine = engines.FirstOrDefault(f => f.GetType() == typeof (RazorViewEngine));
      if (razorEngine != null)
      {
        engines.Remove(razorEngine);
      }
      engines.Add(new FeaturesRazorViewEngine());
    }

    public static string[] GetControllerNamespaces()
    {
      var controllers = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IController)));
      var controllerNamespaces = controllers.Select(c => c.Namespace).Distinct().ToArray();
      return controllerNamespaces;
    }
  }
}
