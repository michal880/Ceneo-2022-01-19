using System;

namespace GOF.Behavioral.ChainOfResponsibility.Example2
{
  public class ProcessorBase
  {
    protected ProcessorBase _next;

    public ProcessorBase(ProcessorBase next)
    {
      _next = next;
    }

    public virtual object Process(Command command)
    {
      if (_next != null)
      {
        return _next.Process(command);
      }
      throw new NotSupportedException();
    }
  }
}