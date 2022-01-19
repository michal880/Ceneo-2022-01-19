using DDD.Sagas.Base;
using DDD.Sagas.Commands;
using DDD.Sagas.Events;

namespace DDD.Sagas
{
  public class OrderSagaManager : SagaManager<DocumentSaga, OrderSagaData>
  {
    public OrderSagaManager(ISagaRepository<OrderSagaData> sagaRepository, ICommandSender commandSender)
      : base(new DocumentSaga(commandSender), sagaRepository)
    {
      CorrelateEvent<DocumentAcceptedEvent>(f => f.DocumentId);
      CorrelateEvent<DocumentCreatedEvent>(f => f.DocumentId);
    }
  }
}