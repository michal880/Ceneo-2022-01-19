namespace DDD.Policy.MethodInjection
{
  public class Document
  {
    private int _pages;

    public Document(int pages)
    {
      _pages = pages;
      _status = DocumentStatus.NEW;
    }

    public void Publish(ICostCalculatorPolicy costCalculatorPolicy)
    {
      _status = DocumentStatus.PUBLISHED;

      _printingCost = costCalculatorPolicy.Calculate(_pages);
    }

    private Money _printingCost;

    private DocumentStatus _status;
  }
}