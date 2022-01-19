using System;

namespace GOF.Behavioral.Mediator.Example1
{
  public class ChatClient<T> : IChatClient<T>
  {
    private string _name;

    public ChatClient(string name)
    {
      _name = name;
    }

    void IChatClient<T>.SendMessage(IMediator<T> mediator, T message)
    {
      mediator.DistributeMessage(this, message);
    }

    void IChatClient<T>.ReceiveMessage(T message)
    {
      Console.WriteLine(_name + " received " + message);
    }
  }
}