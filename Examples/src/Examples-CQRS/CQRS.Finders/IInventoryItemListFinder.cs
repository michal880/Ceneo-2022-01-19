using System.Collections.Generic;

namespace CQRS.Finders
{
  public interface IInventoryItemListFinder
  {
    IEnumerable<InventoryItemList> GetInventoryItems();
  }
}