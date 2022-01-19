namespace Examples.Autofac.Core
{
  public class Repository : IRepository
  {
    private readonly IConfiguration _configuration;

    public Repository(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public void Add()
    {
      
    }
  }
}