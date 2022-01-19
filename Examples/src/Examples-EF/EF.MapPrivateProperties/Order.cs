  using System.ComponentModel.DataAnnotations.Schema;

namespace EF.MapPrivateProperties
{
  public class Order
  {
    [Column]
    private int Id { get; set; }

    [Column]
    private string Data { get; set; }
  }
}