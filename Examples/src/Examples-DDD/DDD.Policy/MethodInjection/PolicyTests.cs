using DDD.Policy.ConstructorInjection;
using Xunit;

namespace DDD.Policy.MethodInjection
{
  
  public class PolicyTests
  {
    [Fact]
    public void Publish_should_calculate_totalCost()
    {
      ICostCalculatorPolicy costCalculatorPolicy = new CostCalculatorFactory(new InMemoryConfiguration()).Create();
      Document document = new Document(10); //or _repository.Get(aggregateId)

      document.Publish(costCalculatorPolicy);

      //_repository.Save(document);
    }
  }
}