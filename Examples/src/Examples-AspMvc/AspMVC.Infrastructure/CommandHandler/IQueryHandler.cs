namespace All_In_One.Features.ClientList
{
  public interface IQueryHandler<T>
  {
    T Handle();
  }

  public interface IQueryHandler<T,U>
  {
    T Handle(U query);
  }
}