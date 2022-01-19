using System;
using System.Collections.Generic;
using System.IO;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using GOF.Behavioral.Mediator.Example2.NoMediator;
using GOF.Behavioral.Mediator.Example2.WithMediator;
using MediatR;
using NUnit.Framework;
using Ping = GOF.Behavioral.Mediator.Example2.WithMediator.Ping;
using PingHandler = GOF.Behavioral.Mediator.Example2.NoMediator.PingHandler;
using PongHandler = GOF.Behavioral.Mediator.Example2.NoMediator.PongHandler;

namespace GOF.Behavioral.Mediator.Example2
{
  [TestFixture]
  public class _Test
  {
    [Test] 
    public void TestWithMediator()
    {
      IMediator mediator = BuildMediator();
      ControllerWithMediator controller = new ControllerWithMediator(mediator); 

      controller.Run();           
    }

    [Test]
    public void TestWithoutMediator()
    {
      Controller controller = new Controller(new PingHandler(), new PongHandler());

      controller.Run();
    }

    private static IMediator BuildMediator()
    {
      var container = new WindsorContainer();
      container.Register(Component.For<IMediator>().ImplementedBy<MediatR.Mediator>());
      container.Register(Classes.FromAssemblyContaining<Ping>().Pick().WithServiceAllInterfaces());
      container.Register(Component.For<TextWriter>().Instance(Console.Out));
      container.Register(Component.For<SingleInstanceFactory>().UsingFactoryMethod<SingleInstanceFactory>(k => t => k.Resolve(t)));
      container.Register(Component.For<MultiInstanceFactory>().UsingFactoryMethod<MultiInstanceFactory>(k => t => (IEnumerable<object>)k.ResolveAll(t)));

      var mediator = container.Resolve<IMediator>();

      return mediator;
    }
  }
}