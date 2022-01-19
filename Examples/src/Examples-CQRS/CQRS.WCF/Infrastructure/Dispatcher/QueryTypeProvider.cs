using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CQRS.WCF.Infrastructure.Dispatcher
{
  internal class QueryTypeProvider
  {
    public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
    {
      return Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(f => typeof(QueryRequest).IsAssignableFrom(f) || typeof(QueryResponse).IsAssignableFrom(f)).ToList();
    }

  }
}