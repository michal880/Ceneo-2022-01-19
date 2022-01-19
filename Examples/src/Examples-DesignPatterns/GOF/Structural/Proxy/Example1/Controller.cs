namespace ProxyDesignPattern
{
  public class Controller
  {
    private readonly IService _service;

    public Controller(IService service)
    {
      _service = service;
    }

    public void ValidateClient()
    {
      //do something
      Address address = _service.ParseAddress("lu. Pomorska 123/4 12-342 Kozia Wulka");

      // run some validation logic
    }
  }
}