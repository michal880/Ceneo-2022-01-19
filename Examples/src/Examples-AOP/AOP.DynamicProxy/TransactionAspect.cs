using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Castle.DynamicProxy;

namespace AOP.DynamicProxy
{
  public class TransactionAspect : IInterceptor
  {
    public void Intercept(IInvocation invocation)
    {
      using (TransactionScope scope = new TransactionScope(
        TransactionScopeOption.Required,
        new TransactionOptions()
        {
          IsolationLevel = IsolationLevel.ReadCommitted
        }))
      {
        invocation.Proceed();
        scope.Complete();
      }
    }
  }
}
