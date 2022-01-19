using System;
using System.Dynamic;
using System.Linq;
using System.Transactions;
using ImpromptuInterface;

namespace AOP.ImpromptuInterface
{
  public class TransactionAspect<T> : DynamicObject
    where T : class
  {
    private readonly T _decorated;
    
    private TransactionAspect(T decorated)
    {
      _decorated = decorated;
    }

    public static T Create(T decorated)
    {
      return new TransactionAspect<T>(decorated).ActLike<T>();
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    {
      var method = _decorated.GetType().GetMethod(binder.Name, args.Select(x => x.GetType()).ToArray());
      using (TransactionScope ts = new TransactionScope())
      {
        result = method.Invoke(_decorated, args);
        ts.Complete();
      }
      return true;
    }
  }
}