using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using WCF.VerticalSlices.Features.AddClient;
using WCF.VerticalSlices.Infrastructure;

namespace WCF.VerticalSlices
{
  class MyRegistry : Registry
  {
    public MyRegistry()
    {
      Scan(scanner =>
      {
        scanner.TheCallingAssembly();
        scanner.AddAllTypesOf(typeof(ICommandHandler<>));
        scanner.AddAllTypesOf(typeof(IQueryHandler<>));
        scanner.WithDefaultConventions();
      });      
    }
  }
}