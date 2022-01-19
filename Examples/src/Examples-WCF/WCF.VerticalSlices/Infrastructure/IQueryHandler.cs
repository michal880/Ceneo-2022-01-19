using WCF.VerticalSlices.Infrastructure.Dispatcher;

namespace WCF.VerticalSlices.Infrastructure
{
  public interface IQueryHandler<in TQuery>
  {
    QueryResponse Handle(TQuery request);
  }
}