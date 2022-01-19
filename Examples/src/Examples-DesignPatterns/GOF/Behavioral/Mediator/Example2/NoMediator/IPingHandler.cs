namespace GOF.Behavioral.Mediator.Example2.NoMediator
{
  public interface IPingHandler
  {
    string Handle(Ping request);
  }

  class PingHandler : IPingHandler
  {
    public string Handle(Ping request)
    {
      return "Ping";
    }
  }
}