namespace GOF.Structural.Adapter.ObjectAdapter
{
  public class ObjectProcessor
  {
    public void Run(ILogWriter logWriter)
    {
      // robie straszne rzeczy
      logWriter.Write("Step 1 finished", Level.Debug);

      // robie jeszcze straszniejsze rzeczy
      logWriter.Write("Step 2 finished", Level.Trace);

      // OOOO coś sie zepsuło
      logWriter.Write("Something goes wrong, it's Microsoft's fault", Level.Error);
    }
  }
}