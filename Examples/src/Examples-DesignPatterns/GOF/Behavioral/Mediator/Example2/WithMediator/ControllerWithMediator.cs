using System;
using System.Diagnostics;
using MediatR;

namespace GOF.Behavioral.Mediator.Example2.WithMediator
{
  public class ControllerWithMediator
  {
    private readonly IMediator _mediator;

    public ControllerWithMediator(IMediator mediator)
    {
      _mediator = mediator;
    }

    public void Run()
    {
      var response = _mediator.Send(new Ping());
      Console.WriteLine(response);

      var response2 = _mediator.Send(new Pong());
      Console.WriteLine(response2);
    }
  }
}
