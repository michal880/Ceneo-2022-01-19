namespace GOF.Behavioral.Mediator.Example2.NoMediator
{
  public interface IPongHandler
  {
    string Handle(Pong request);
  }

  class PongHandler : IPongHandler
  {
    public string Handle(Pong request)
    {
      return "Pong";
    }
  }
}