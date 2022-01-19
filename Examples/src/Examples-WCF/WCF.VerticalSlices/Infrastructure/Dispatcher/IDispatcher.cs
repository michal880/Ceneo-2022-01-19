using System.ServiceModel;

namespace WCF.VerticalSlices.Infrastructure.Dispatcher
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