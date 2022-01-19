using System;

namespace AOP.DynamicProxy
{
  public class MyCommanHandler : ICommandHandler<MyCommand>
  {
    public void Handle(MyCommand obj)
    {
      Console.WriteLine("OK");
    }
  }
}