namespace DDD.Sagas.Base
{
  public interface ISagaRepository<TSagaData>
  {
    void Save(string id, TSagaData sagaData);

    TSagaData Load(string id);
  }
}