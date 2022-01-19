using System;

namespace CQRS.Finders
{
  public class InventoryItemList
  {
    public InventoryItemList(Guid id, string name)
    {
      Id = id;
      Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
  }
}