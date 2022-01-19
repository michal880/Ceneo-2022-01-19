using System;
using CQRS.Domain.Base;

namespace CQRS.Domain.InventoryItem
{
  public class InventoryItemRenamed : Event
  {
    public readonly Guid Id;
    public readonly string NewName;
 
    public InventoryItemRenamed(Guid id, string newName)
    {
      Id = id;
      NewName = newName;
    }
  }
}