using Microsoft.Extensions.Configuration;

namespace DDD.Policy
{
  public class CostCalculatorFactory
  {
    private readonly IConfiguration _configuration;

    public CostCalculatorFactory(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public ICostCalculatorPolicy Create()
    {
      string value = _configuration["KindOfPrints"];
      if (value == "BW")
      {
        return new BWCostCalculator();
      }
      else
      {
        return new ColorCostCalculator();
      }
    }
  }
}