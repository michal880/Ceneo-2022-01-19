namespace DDD.Sagas.Commands
{
  public interface ICommand
  {
    string CorrelationId { get; set; }
  }
}