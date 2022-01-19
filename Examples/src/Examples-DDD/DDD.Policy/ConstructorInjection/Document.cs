namespace DDD.Policy.ConstructorInjection
{
  public class Document2 : AggregateRoot
  {
    private readonly int _pages;
    private readonly ICostCalculatorPolicy _costCalculatorPolicy;

    public Document2(int pages, ICostCalculatorPolicy costCalculatorPolicy)
    {
      _pages = pages;
      _costCalculatorPolicy = costCalculatorPolicy;
      _status = DocumentStatus.NEW;
    }

    public void Publish()
    {
      _status = DocumentStatus.PUBLISHED;

      _printingCost = _costCalculatorPolicy.Calculate(_pages);
    }

    private Money _printingCost;

    private DocumentStatus _status;
  }
}