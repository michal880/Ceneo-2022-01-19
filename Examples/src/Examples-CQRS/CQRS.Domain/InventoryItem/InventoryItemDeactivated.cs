using System;
using CQRS.Domain.Base;

namespace CQRS.Domain.InventoryItem
{
  public class InventoryItemDeactivated : Event
  {
    public readonly Guid Id;

    public InventoryItemDeactivated(Guid id)
    {
      Id = id;
    }
  }
}