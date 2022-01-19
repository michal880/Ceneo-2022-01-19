namespace AspMvc.Infrastructure.CommandHandler
{
  public interface ICommandHandler<T>
  {
    void Handle(T command);
  }
}