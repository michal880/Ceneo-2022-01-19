using System;

namespace CQRS.Application.Contract
{
  public interface IDeactivateInventoryItemCommand
  {
    Guid InventoryItemId { get; }
    int? OriginalVersion { get; }    
  }
}