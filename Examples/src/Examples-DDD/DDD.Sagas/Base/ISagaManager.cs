namespace DDD.Sagas.Base
{
  public interface ISagaManager
  {
    void ProcessMessage<T>(T message);
  }
}