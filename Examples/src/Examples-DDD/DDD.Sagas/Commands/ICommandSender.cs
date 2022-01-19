namespace DDD.Sagas.Commands
{
  public interface ICommandSender
  {
    void Send(ICommand cmd);
  }
}