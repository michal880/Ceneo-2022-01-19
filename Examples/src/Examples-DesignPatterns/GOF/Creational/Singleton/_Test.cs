using NUnit.Framework;

namespace GOF.Creational.Singleton
{
  [TestFixture]
  public class _Test
  {
    public void Test1()
    {
      MySingleton.Instance.DoSth();
    }

    public void Test2()
    {
      MySingleton2.Instance.DoSth();

      MyClass m = new MyClass(MySingleton2.Instance);
    }





    private class MyClass
    {
      private readonly IMySingleton2 _singleton2;

      public MyClass(IMySingleton2 singleton2)
      {
        _singleton2 = singleton2;
      }
    }
  }
}