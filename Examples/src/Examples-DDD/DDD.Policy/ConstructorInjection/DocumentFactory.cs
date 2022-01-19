namespace DDD.Policy.ConstructorInjection
{
  public class DocumentFactory 
  {
    public Document2 Create(int pagesCount)
    {
      Document2 result = new Document2(pagesCount, new CostCalculatorFactory(new InMemoryConfiguration()).Create());
      return result;
    }
  }
}