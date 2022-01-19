namespace AspMvc.Examples.Common.Client.Command
{
  public class Client
  {
    public int Id { get; set; }

    public string Name{ get; set; }
    public string TaxId { get; set; }
    public string Email { get; set; }

    public Address Address { get; set; }
  }
}