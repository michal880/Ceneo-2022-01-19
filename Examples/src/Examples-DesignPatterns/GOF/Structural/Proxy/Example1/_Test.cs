using NUnit.Framework;

namespace ProxyDesignPattern
{
  [TestFixture]
  public class _Test
  {
    public void Test()
    {
      IService proxy = new ServiceProxy("localhost:8090");

      IService service = new Service();

      HttpListener httpListener = new HttpListener(8090, service);

      httpListener.Listen();


      Controller controller = new Controller(proxy);

      controller.ValidateClient();
    }
  }
}