using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AspMvc.Examples.Common.Client.Command;
using AspMvc.Infrastructure.FeatureFolders;
using AspMvc.Infrastructure.IoC.CastleWindsor;

namespace All_In_One
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      FeatureFoldersConfig.Configure(ViewEngines.Engines);
      IocConfig.Configure();
    }
  }
}
