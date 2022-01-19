namespace Routing.Models
{
  public class LanguageModel  
  {
    public string Country { get; set; }
    public string Lang { get; set; }

    public LanguageModel(string country, string lang)
    {
      Country = country;
      Lang = lang;      
    }
  }
}