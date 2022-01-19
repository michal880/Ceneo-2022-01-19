namespace AOP.ImpromptuInterface
{
  public interface ICommandHandler<T>
  {
    void Handle(T obj);
  }
}