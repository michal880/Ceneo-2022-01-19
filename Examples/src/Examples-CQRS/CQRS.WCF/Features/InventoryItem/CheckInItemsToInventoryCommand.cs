using System;
using CQRS.Application.Contract;

namespace CQRS.WCF.Features.InventoryItem
{
  public class CheckInItemsToInventoryCommand : Command, ICheckInItemsToInventoryCommand
  {
    public Guid Id { get; set; }
    public Guid InventoryItemId => Id;
    public int Count { get; set; }
  }
}