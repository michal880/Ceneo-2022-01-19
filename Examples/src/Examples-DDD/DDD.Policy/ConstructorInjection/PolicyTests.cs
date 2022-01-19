using Xunit;

namespace DDD.Policy.ConstructorInjection
{
  
  public class PolicyTests
  {
    [Fact]
    public void Publish_should_calculate_totalCost()
    {
      Document2 document = new DocumentFactory().Create(10);

      document.Publish();

      //_repository.Save(document);
    }
  }
}