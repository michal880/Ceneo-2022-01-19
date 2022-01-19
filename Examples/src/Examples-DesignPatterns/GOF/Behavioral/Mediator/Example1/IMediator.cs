using System.Collections.Generic;

namespace GOF.Behavioral.Mediator.Example1
{
  public interface IMediator<T>
  {
    List<IChatClient<T>> ColleagueList { get; }

    void DistributeMessage(IChatClient<T> sender, T message);

    void Register(IChatClient<T> chatClient);
  }
}