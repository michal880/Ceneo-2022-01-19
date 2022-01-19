using System.Collections.Generic;

namespace Examples.Autofac.WebApi.Controllers
{
  public interface IExternalQuery
  {
    IEnumerable<string> Get();
  }
}