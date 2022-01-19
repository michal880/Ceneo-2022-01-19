using System.Collections.Generic;
using Examples.Autofac.WebApi.Controllers;

namespace Examples.Autofac.WebApi.Tests
{
  public class TestExternalQuery : IExternalQuery
  {
    public IEnumerable<string> Get()
    {
      return new[] { "TestValue1", "TestValue2" };
    }
  }
}