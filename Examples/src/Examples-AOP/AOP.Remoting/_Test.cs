using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AOP.Remoting
{
  public class _Test
  {
    [Test]
    public void Proxy()
    {
      ICommandHandler<MyCommand> commandHandler  
        = LoggingProxy<ICommandHandler<MyCommand>>.Create(new MyCommandHandler());
       
      commandHandler.Handle(new MyCommand());

      IFoo f = LoggingProxy<IFoo>.Create(new Foo());

      f.Add();
      f.Delete();
    }

    public interface ICommandHandler<T>
    {
      void Handle(T obj);
    }

    public class MyCommandHandler : ICommandHandler<MyCommand>
    {
      public void Handle(MyCommand obj)
      {
        Console.WriteLine("OK");
      }
    }

    public class MyCommand
    {
    }

    public class LoggingProxy<T> : RealProxy
    {
      private readonly T _instance;

      private LoggingProxy(T instance)
          : base(typeof(T))
      {
        _instance = instance;
      }

      public static T Create(T instance) // ICommandHandler<MyCOmmand>
      {
        return (T)new LoggingProxy<T>(instance).GetTransparentProxy();
      }

      public override IMessage Invoke(IMessage msg)
      {
        var methodCall = (IMethodCallMessage)msg;
        var method = (MethodInfo)methodCall.MethodBase;

        try
        {
          Console.WriteLine("Before invoke: " + method.Name);
          var result = method.Invoke(_instance, methodCall.InArgs);
          Console.WriteLine("After invoke: " + method.Name);
          return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
        }
        catch (Exception e)
        {
          Console.WriteLine("Exception: " + e);
          if (e is TargetInvocationException && e.InnerException != null)
          {
            return new ReturnMessage(e.InnerException, msg as IMethodCallMessage);
          }

          return new ReturnMessage(e, msg as IMethodCallMessage);
        }
      }
    }
  }

  public interface IFoo
  {
    void Add();
    void Delete();
  }

  public class Foo : IFoo
  {
    public void Add()
    {
      
    }

    public void Delete()
    {
    }
  }
}
