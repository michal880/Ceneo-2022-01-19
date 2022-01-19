
namespace NHibernate.DependencyInjection
{
  public class Order 
  {
    private readonly ITaxCalculator _taxCalculator;

    public Order(ITaxCalculator taxCalculator)
    {
      _taxCalculator = taxCalculator;
    }
    
    public virtual int Id { get; set; }

    public virtual string Data { get; set; }

    public ITaxCalculator GetTaxCalculator()
    {
      return _taxCalculator;
    }
  }
}