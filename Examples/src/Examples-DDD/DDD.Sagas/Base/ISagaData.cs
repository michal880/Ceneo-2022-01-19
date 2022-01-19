using Automatonymous;

namespace DDD.Sagas.Base
{
  public interface ISagaData
  {
    State CurrentState { get; set; }
  }
}