using System.ServiceModel;

namespace CQRS.WCF.Infrastructure.Dispatcher
{
  [ServiceContract]
  internal interface IDispatcher
  {
    [OperationContract]
    [ServiceKnownType("GetKnownTypes", typeof(CommandTypeProvider))]
    void Send(Command command);

    [OperationContract]
    [ServiceKnownType("GetKnownTypes", typeof(QueryTypeProvider))]
    QueryResponse Query(QueryRequest query);
  }
}