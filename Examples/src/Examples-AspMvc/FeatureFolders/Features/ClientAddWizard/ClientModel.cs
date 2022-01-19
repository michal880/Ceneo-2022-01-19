using System.ComponentModel.DataAnnotations;
using AspMvc.Examples.Common.Client.Command;

namespace FeatureFolders.Features.ClientAddWizard
{
  public class ClientModel 
  {
    public ClientModel()
    {      
    }

    public ClientModel(Client client)
    {
      Id = client.Id;
      Name = client.Name;
    }

    [Required]
    public int Id { get; set; }
    [MinLength(3)]
    [MaxLength(128)]
    [Required]
    public string Name { get; set; }

    public void Update(Client client)
    {
      client.Name = Name;
    }
  }  
}