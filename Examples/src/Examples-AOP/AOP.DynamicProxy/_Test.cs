using System;
using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace AOP.DynamicProxy
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void DynamicProxy_With_Windsor()
    {
      var container = new WindsorContainer();
      container.Register(Component.For<TransactionAspect>().Named("test"));
      container.Register(Component
        .For<ICommandHandler<MyCommand>>()
        .ImplementedBy<MyCommanHandler>()
        .Interceptors(InterceptorReference.ForKey("test")).Anywhere);

      ICommandHandler<MyCommand> commandHandler = container.Resolve<ICommandHandler<MyCommand>>();

      commandHandler.Handle(new MyCommand());
    }

    [Test]
    public void DynamicProxy_Without_Windsor()
    {
      ICommandHandler<MyCommand> commandHandler = new ProxyGenerator().CreateClassProxy(
        typeof(MyCommanHandler), 
        new Type[]{ typeof(ICommandHandler<MyCommand>) }, 
        ProxyGenerationOptions.Default, 
        new TransactionAspect()) as ICommandHandler<MyCommand>;

      commandHandler.Handle(new MyCommand());
    }
  }
}