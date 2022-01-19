namespace ExamplesAutoFac
{
  public interface ICommandHandler<T>
  {
    void Handle(T obj);
  }
}