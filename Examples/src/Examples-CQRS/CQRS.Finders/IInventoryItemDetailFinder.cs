using System;

namespace CQRS.Finders
{
  public interface IInventoryItemDetailFinder
  {
    InventoryItemDetail GetInventoryItemDetails(Guid id);
  }
}