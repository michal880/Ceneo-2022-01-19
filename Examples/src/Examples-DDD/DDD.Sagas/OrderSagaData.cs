using Automatonymous;
using DDD.Sagas.Base;

namespace DDD.Sagas
{
  public class OrderSagaData : ISagaData
  {
    public State CurrentState { get; set; }
    public string DocumentId { get; set; }
  }
}