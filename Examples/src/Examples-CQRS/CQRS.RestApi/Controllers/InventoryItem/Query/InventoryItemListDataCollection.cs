using System.Collections.Generic;
using System.Linq;
using CQRS.Finders;
using CQRS.RestApi.Concurrency;

namespace CQRS.RestApi.Controllers.InventoryItem.Query
{
  public class InventoryItemListDataCollection : List<InventoryItemList>, IConcurrencyAware
  {

    public InventoryItemListDataCollection()
    {

    }

    public InventoryItemListDataCollection(IEnumerable<InventoryItemList> dtos)
    {
      AddRange(dtos.Select(x => new InventoryItemList(x.Id, x.Name)));
    }

    string IConcurrencyAware.ConcurrencyVersion
    {
      get { return null; }
      set
      {
        // nothing!
      }
    }
  }
}