namespace AspMvc.Infrastructure.CommandHandler
{
  public interface IQueryDispatcher
  {
    T Handle<T>();
    T Handle<T,U>(U query);
  }
}