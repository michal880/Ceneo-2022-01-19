using System.Collections.Generic;

namespace GOF.Behavioral.Mediator.Example1
{
  public class ConcreteMediator<T> : IMediator<T>
  {
    private List<IChatClient<T>> colleagueList = new List<IChatClient<T>>();

    List<IChatClient<T>> IMediator<T>.ColleagueList
    {
      get { return colleagueList; }
    }

    void IMediator<T>.Register(IChatClient<T> chatClient)
    {
      colleagueList.Add(chatClient);
    }

    void IMediator<T>.DistributeMessage(IChatClient<T> sender, T message)
    {
      foreach (IChatClient<T> c in colleagueList)
        if (c != sender)    //don't need to send message to sender
          c.ReceiveMessage(message);
    }
  }
}