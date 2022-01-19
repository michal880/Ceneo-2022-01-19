using System;

namespace CQRS.Application.Contract
{
  public interface IRemoveItemsFromInventoryCommand 
  {
    Guid InventoryItemId { get; }
    int Count { get; }    
  }
}
