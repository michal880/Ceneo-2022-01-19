using System.ComponentModel.DataAnnotations;

namespace CommandPattern.Controllers.CreateClient
{
  public class ClientCreateCommand
  {
    [MinLength(3)]
    [MaxLength(128)]
    [Required]
    public string Name { get; set; }
  }
}