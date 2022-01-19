using System;

namespace GOF.Behavioral.ChainOfResponsibility.Example2
{
  public class RemoveCommandProcessor : ProcessorBase
  {
    public RemoveCommandProcessor(ProcessorBase processor)
      : base(processor)
    {
    }

    public override object Process(Command command)
    {
      if (command is RemoveCommand)
      {
        DoSth(command as RemoveCommand);
      }
      return base.Process(command);
    }

    private void DoSth(RemoveCommand command)
    {
      Console.WriteLine("RemoveCommand - Dosth");
    }
  }
}