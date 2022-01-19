using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AOP.PostSharp
{
  public class _Test
  {
    [Test]
    public void PostSharp()
    {
      TestMethod();
    }

    [LogAspect]
    private void TestMethod()
    {
      Console.WriteLine("TestMethod");
    }
  }
}
