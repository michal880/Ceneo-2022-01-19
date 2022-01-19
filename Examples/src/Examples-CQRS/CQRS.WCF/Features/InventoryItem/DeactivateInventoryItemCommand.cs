using System;
using CQRS.Application.Contract;
using CQRS.WCF.Concurrency;

namespace CQRS.WCF.Features.InventoryItem
{
  public class DeactivateInventoryItemCommand : Command, IConcurrencyAware, IDeactivateInventoryItemCommand
  {
    public Guid Id { get; set; }
    public string ConcurrencyVersion { get; set; }
    public Guid InventoryItemId => Id;

    public int? OriginalVersion => int.TryParse(ConcurrencyVersion, out var versionNumber) ? (int?) versionNumber : null;
  }
}