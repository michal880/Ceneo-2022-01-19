using MediatR;

namespace GOF.Behavioral.Mediator.Example2.WithMediator
{
  public class PingHandler : IRequestHandler<Ping, string>
  {
    public string Handle(Ping request)
    {
      return "Ping";
    }
  }
}