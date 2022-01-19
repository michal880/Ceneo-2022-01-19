using System.ComponentModel.DataAnnotations;

namespace All_In_One.Features.ClientCreate.Command
{
  public class ClientCreateCommand
  {
    [MinLength(3)]
    [MaxLength(128)]
    [Required]
    public string Name { get; set; }
  }
}