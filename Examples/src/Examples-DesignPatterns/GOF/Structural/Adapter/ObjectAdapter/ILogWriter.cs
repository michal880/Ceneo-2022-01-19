namespace GOF.Structural.Adapter.ObjectAdapter
{
  public interface ILogWriter
  {
    void Write(string logEntry, Level level);
  }
}