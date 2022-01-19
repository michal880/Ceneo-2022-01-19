using MediatR;

namespace GOF.Behavioral.Mediator.Example2.WithMediator
{
  public class PongHandler : IRequestHandler<Pong, string>
  {
    public string Handle(Pong request)
    {
      return "Pong";
    }
  }
}