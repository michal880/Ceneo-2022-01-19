namespace AOP.DynamicProxy
{
  public interface ICommandHandler<T>
  {
    void Handle(T obj);
  }
}