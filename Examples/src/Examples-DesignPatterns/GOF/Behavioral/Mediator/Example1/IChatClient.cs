namespace GOF.Behavioral.Mediator.Example1
{
  public interface IChatClient<T>
  {
    void SendMessage(IMediator<T> mediator, T message);

    void ReceiveMessage(T message);
  }
}