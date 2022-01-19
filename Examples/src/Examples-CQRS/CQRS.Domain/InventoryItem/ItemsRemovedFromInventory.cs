using System;
using CQRS.Domain.Base;

namespace CQRS.Domain.InventoryItem
{
  public class ItemsRemovedFromInventory : Event
  {
    public Guid Id;
    public readonly int Count;

    public ItemsRemovedFromInventory(Guid id, int count)
    {
      Id = id;
      Count = count;
    }
  }
}

