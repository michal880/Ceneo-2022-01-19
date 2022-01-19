using FeatureFolders.Implementation.Client.Command;
using System;
using System.ComponentModel.DataAnnotations;

namespace FeatureFolders.Features.ClientAddWizard
{
  public class ClientModel 
  {
    public ClientModel()
    {      
    }

    public ClientModel(Client client)
    {      
      Name = client.Name;
    }
    
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