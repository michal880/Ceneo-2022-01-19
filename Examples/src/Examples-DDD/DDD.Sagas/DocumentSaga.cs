using Automatonymous;
using DDD.Sagas.Commands;
using DDD.Sagas.Events;

namespace DDD.Sagas
{
  public class DocumentSaga : AutomatonymousStateMachine<OrderSagaData>
  {
    private ICommandSender _commandSender;

    public DocumentSaga(ICommandSender commandSender)
    {
      _commandSender = commandSender;

      Event(() => DocumentCreatedEvent);
      Event(() => DocumentAcceptedEvent);

      Initially(
        When(DocumentCreatedEvent)
          .Then(ctx => ctx.Instance.DocumentId = ctx.Data.DocumentId)
          .TransitionTo(DocumentCreated));

      During(DocumentCreated,
        When(DocumentAcceptedEvent)
          .Then(ctx =>
          {
            _commandSender.Send(new PrintDocumentCommand(ctx.Instance.DocumentId));
          })
          .TransitionTo(DocumentAccepted));
    }

    public State DocumentCreated { get; set; }
    public State DocumentAccepted { get; set; }

    public Event<DocumentCreatedEvent> DocumentCreatedEvent { get; set; }
    public Event<DocumentAcceptedEvent> DocumentAcceptedEvent { get; set; }
  }
}