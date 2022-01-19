using System;

namespace CQRS.Application.Contract
{
  public interface ICreateInventoryItemCommand
  {
    Guid InventoryItemId { get; }
    string Name { get; }	      
  }
}