using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace DDD.Policy.ConstructorInjection
{
  public class InMemoryConfiguration : Dictionary<string,string>, IConfiguration
  {
    public InMemoryConfiguration()
    {
      this["KindOfPrints"] = "BW";
    }
    public IConfigurationSection GetSection(string key)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<IConfigurationSection> GetChildren()
    {
      throw new System.NotImplementedException();
    }

    public IChangeToken GetReloadToken()
    {
      throw new System.NotImplementedException();
    }
  }
}