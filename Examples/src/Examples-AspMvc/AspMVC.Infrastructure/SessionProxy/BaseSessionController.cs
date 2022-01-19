using System;
using System.Web;
using System.Web.Mvc;
using Castle.DynamicProxy;

namespace AspMvc.Infrastructure.SessionProxy
{
  public class SessionController<ISessionProxy> : Controller where ISessionProxy : class
  {
    private static readonly ProxyGenerator generator = CreateProxyGenerator();

    public SessionController()
    {
      if (!typeof(ISessionProxy).IsInterface)
      {
        throw new InvalidOperationException("T must be an interface");
      }
      Session = Create(() => base.Session);
    }

    public new ISessionProxy Session { get; set; }

    private ISessionProxy Create(Func<HttpSessionStateBase> session)
    {
      return generator.CreateInterfaceProxyWithoutTarget(typeof(ISessionProxy), new Interceptor(session)) as ISessionProxy;
    }

    private static ProxyGenerator CreateProxyGenerator()
    {
      return new ProxyGenerator();
    }

    private class Interceptor : IInterceptor
    {
      private readonly Func<HttpSessionStateBase> _session;

      public Interceptor(Func<HttpSessionStateBase> session)
      {
        _session = session;
      }

      public void Intercept(IInvocation invocation)
      {
        if (invocation.Method.Name.StartsWith("set_"))
        {
          string key = "_" + invocation.Method.DeclaringType.FullName + invocation.Method.Name.Replace("set", "");
          _session()[key] = invocation.Arguments[0];
        }
        if (invocation.Method.Name.StartsWith("get_"))
        {
          string key = "_" + invocation.Method.DeclaringType.FullName + invocation.Method.Name.Replace("get", "");
          invocation.ReturnValue = _session()[key];
        }
      }
    }
  }
}