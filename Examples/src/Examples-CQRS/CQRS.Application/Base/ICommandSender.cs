namespace CQRS.Application.Base
{
  public interface ICommandSender
  {
    void Send<T>(T command);

  }
}