namespace CQRS.Application.Base
{
  public interface IHandler<in T>
  {
    void Handle(T command);
  }
}