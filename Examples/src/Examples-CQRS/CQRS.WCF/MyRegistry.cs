using System;
using CQRS.Application.Base;
using CQRS.Domain.Base;
using CQRS.Domain.InventoryItem;
using CQRS.WCF.Infrastructure;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using CQRS.Infrastructure;
using StructureMap;

namespace CQRS.WCF
{
  class MyRegistry : Registry
  {
    public MyRegistry()
    {
      Scan(scanner =>
      {
        scanner.AssembliesFromPath(AppDomain.CurrentDomain.BaseDirectory);
        scanner.AddAllTypesOf(typeof(IHandler<>));
        scanner.AddAllTypesOf(typeof(IQueryHandler<>));        
        scanner.WithDefaultConventions();
      });
     
      For<IRepository<InventoryItem>>().Use<Repository<InventoryItem>>();
    }
  }
}