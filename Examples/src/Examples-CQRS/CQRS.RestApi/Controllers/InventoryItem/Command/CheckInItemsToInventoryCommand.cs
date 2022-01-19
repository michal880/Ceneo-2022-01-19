using System;
using CQRS.Application.Contract;

namespace CQRS.RestApi.Controllers.InventoryItem.Command
{
  public class CheckInItemsToInventoryCommand : ICheckInItemsToInventoryCommand
  {
    public Guid Id { get; set; }
    public Guid InventoryItemId => Id;
    public int Count { get; set; }
  }
}