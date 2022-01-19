namespace MementoDesignPattern
{
  public class Memento // previous window state
  {
    public string State { get; private set; }

    public Memento(string state)
    {
      State = state;
    }
  }
}