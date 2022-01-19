namespace CommandPattern.Controllers
{
  public interface ICommandDispatcher
  {
    void Handle<T>(T command);
  }
}