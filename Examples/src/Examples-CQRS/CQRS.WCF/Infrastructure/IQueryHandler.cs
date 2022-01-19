using CQRS.WCF.Infrastructure.Dispatcher;

namespace CQRS.WCF.Infrastructure
{
  public interface IQueryHandler<in TQuery>
  {
    QueryResponse Handle(TQuery request);
  }
}