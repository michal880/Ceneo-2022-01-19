using System.Collections.Generic;

namespace Examples.Autofac.WebApi.Controllers
{
  public class ExternalQuery : IExternalQuery
  {
    public IEnumerable<string> Get()
    {
      return new[] { "Value1", "Value2" };
    }
  }
}