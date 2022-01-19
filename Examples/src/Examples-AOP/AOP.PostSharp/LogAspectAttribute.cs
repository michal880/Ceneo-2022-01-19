using System;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace AOP.PostSharp
{
  [PSerializable]
  [LinesOfCodeAvoided(5)]
  public sealed class LogAspectAttribute : MethodInterceptionAspect
  {
    public override void OnInvoke(MethodInterceptionArgs args)
    {
      Console.WriteLine("Before");
      args.Proceed();
      Console.WriteLine("After");    
    }
  }
}