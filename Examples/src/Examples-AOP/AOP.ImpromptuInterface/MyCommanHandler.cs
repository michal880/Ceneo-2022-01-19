using System;
using System.Transactions;

namespace AOP.ImpromptuInterface
{
  public class MyCommanHandler : ICommandHandler<MyCommand>
  {
    public void Handle(MyCommand obj)
    {
      if (Transaction.Current == null)
      {
        throw new InvalidOperationException("transaction requred");
      }
      Console.WriteLine("OK");
    }
  }
}