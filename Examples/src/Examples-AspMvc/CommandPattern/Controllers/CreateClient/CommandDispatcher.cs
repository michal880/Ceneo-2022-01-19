using Castle.Windsor;
using CommandPattern.Controllers;

namespace AspMvc.Infrastructure.CommandHandler
{
  public class CommandDispatcher : ICommandDispatcher
  {
    private IWindsorContainer _container;

    public CommandDispatcher(IWindsorContainer container)
    {
      _container = container;
    }

    public void Handle<T>(T command)
    {
      ICommandHandler<T> commandHandler = _container.Resolve<ICommandHandler<T>>();
      commandHandler.Handle(command);
    }
  }
}