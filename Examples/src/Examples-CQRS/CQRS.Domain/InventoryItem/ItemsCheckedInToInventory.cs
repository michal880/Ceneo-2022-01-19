using System;
using CQRS.Domain.Base;

namespace CQRS.Domain.InventoryItem
{
  public class ItemsCheckedInToInventory : Event
  {
    public Guid Id;
    public readonly int Count;
 
    public ItemsCheckedInToInventory(Guid id, int count)
    {
      Id = id;
      Count = count;
    }
  }
}