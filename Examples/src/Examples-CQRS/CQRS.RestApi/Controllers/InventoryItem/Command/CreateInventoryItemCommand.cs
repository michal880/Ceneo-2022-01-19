using System;
using CQRS.Application.Contract;

namespace CQRS.RestApi.Controllers.InventoryItem.Command
{
  public class CreateInventoryItemCommand : ICreateInventoryItemCommand
  {
    public Guid? Id { get; set; }

    public Guid InventoryItemId => Id ?? Guid.Empty;

    public string Name { get; set; }
  }
}