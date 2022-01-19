using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.FeatureFolders
{
  internal class FeaturesRazorViewEngine : RazorViewEngine
  {
    public FeaturesRazorViewEngine()
    {
      //// Specify formats as consts in order to enable Visual Studio navigation to views
      ViewLocationFormats = new[]
      {
        "~/Features/{1}/{0}.cshtml",
        "~/Features/{1}/{0}.vbhtml",
        "~/Features/Shared/{0}.cshtml",
        "~/Features/Shared/{0}.vbhtml",
      };

      PartialViewLocationFormats = new[]
      {
        "~/Features/{1}/{0}.cshtml",
        "~/Features/{1}/{0}.vbhtml",
        "~/Features/Shared/{0}.cshtml",
        "~/Features/Shared/{0}.vbhtml",
      };
    }
  }
}
