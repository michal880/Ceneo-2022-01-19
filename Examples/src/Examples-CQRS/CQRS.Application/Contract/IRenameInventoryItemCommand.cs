using System;

namespace CQRS.Application.Contract
{
  public interface IRenameInventoryItemCommand
  {
    Guid InventoryItemId { get; }
    string NewName { get; }
    int? OriginalVersion { get; }    
  }
}