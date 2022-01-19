using System;

namespace CQRS.Application.Contract
{
  public interface ICheckInItemsToInventoryCommand
  {
    Guid InventoryItemId { get; }
    int Count { get; }    
  }
}