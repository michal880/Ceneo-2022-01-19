namespace Examples.Autofac.Core
{
  public interface ICommandHandler<T>
  {
    void Handle(T obj);
  }
}