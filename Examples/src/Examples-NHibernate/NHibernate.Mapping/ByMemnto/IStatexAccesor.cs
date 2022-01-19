namespace NHibernate.Mapping.ByMemnto
{
  public interface IStateAccesor<T>
  {
    T GetState();
  }
}