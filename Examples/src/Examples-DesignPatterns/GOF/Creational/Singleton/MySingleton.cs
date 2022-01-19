using System;

namespace GOF.Creational.Singleton
{
  public class MySingleton
  {
    private MySingleton()
    {      
    }

    private static MySingleton _instance;
    public static MySingleton Instance
    {
      get
      {
        if(_instance == null)
        {
          _instance = new MySingleton();
        }
        return _instance;
      }
    }

    public void DoSth()
    {
      Console.WriteLine("ok, done");
    }
  }
}
