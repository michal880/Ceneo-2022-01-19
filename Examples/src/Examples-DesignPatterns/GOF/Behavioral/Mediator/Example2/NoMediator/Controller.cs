using System;

namespace GOF.Behavioral.Mediator.Example2.NoMediator
{
  public class Controller
  {
    private IPingHandler _pingHandler;
    private IPongHandler _pongHandler;

    public Controller(IPingHandler pingHandler, IPongHandler pongHandler)
    {
      _pingHandler = pingHandler;
      _pongHandler = pongHandler;
    }

    public void Run()
    {
      string result = _pingHandler.Handle(new Ping());
      Console.WriteLine(result);

      string result2 = _pongHandler.Handle(new Pong());
      Console.WriteLine(result2);
    }
  }
}