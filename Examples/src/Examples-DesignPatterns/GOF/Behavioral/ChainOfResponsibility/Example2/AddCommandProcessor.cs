using System;

namespace GOF.Behavioral.ChainOfResponsibility.Example2
{
  public class AddCommandProcessor : ProcessorBase
  {
    public AddCommandProcessor(ProcessorBase next)
      : base(next)
    {
    }

    public override object Process(Command request)
    {
      if (request is AddCommand)
      {
        Console.WriteLine("Added");
        return new Response("123");
      }
      return base.Process(request);
    }
  }
}