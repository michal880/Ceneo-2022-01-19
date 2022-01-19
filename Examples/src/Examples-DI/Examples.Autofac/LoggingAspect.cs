using System;
using Castle.DynamicProxy;

namespace ExamplesAutoFac
{
  public class LoggingAspect : IInterceptor
  {
    public static int ExecutionCounter = 0;

    public void Intercept(IInvocation invocation)
    {
      Console.WriteLine("Start ... ");      
      invocation.Proceed();
      Console.WriteLine("Finished");
      ExecutionCounter++;
    }
  }
}