using System;

namespace GOF.Creational.Singleton
{
  public class MySingleton2 : IMySingleton2
  {
    private MySingleton2()
    {
    }

    //[ThreadStatic] ???
    private static MySingleton2 _instance;

    public static IMySingleton2 Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new MySingleton2();
        }
        return _instance;
      }
    }

    public void DoSth()
    {
      Console.WriteLine("ok, done");
    }
  }

  public interface IMySingleton2
  {
    void DoSth();
  }

  internal class MyClass
  {
    private readonly IMySingleton2 _singleton2;

    public MyClass(IMySingleton2 singleton2)
    {
      _singleton2 = singleton2;
    }
  }
}