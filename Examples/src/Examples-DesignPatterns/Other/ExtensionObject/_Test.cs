using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ExtensionObjectPattern
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void Test1()
    {
      ConcreteSubject concreteSubject = new ConcreteSubject(new[] { new SomeExtension() });
      
      SomeExtension extension = concreteSubject.GetExtension<SomeExtension>();

      extension.DoSth();
    }    
  }
}