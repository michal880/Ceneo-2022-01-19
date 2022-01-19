using System;
using CQRS.Application.Contract;

namespace CQRS.WCF.Features.InventoryItem
{
  public class CreateInventoryItemCommand : Command, ICreateInventoryItemCommand
  {
    public Guid? Id { get; set; }

    public Guid InventoryItemId => Id ?? Guid.Empty;

    public string Name { get; set; }
  }
}