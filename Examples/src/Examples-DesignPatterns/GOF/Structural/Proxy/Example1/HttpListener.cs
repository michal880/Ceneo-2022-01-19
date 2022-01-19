using System;

namespace ProxyDesignPattern
{
  public class HttpListener
  {
    private readonly int _port;
    private readonly IService _service;

    public HttpListener(int port, IService service)
    {
      _port = port;
      _service = service;
    }

    public void Listen()
    {
      Console.WriteLine("listener Started");
    }

    public void RunWhenMessageComes(string address)
    {
        
    }
  }
}