using System;
using CQRS.Application.Contract;
using CQRS.WCF.Concurrency;

namespace CQRS.WCF.Features.InventoryItem
{
  public class RenameInventoryItemCommand : Command, IConcurrencyAware, IRenameInventoryItemCommand
  {
    public Guid Id { get; set; }
    public string ConcurrencyVersion { get; set; }
    public Guid InventoryItemId => Id;
    public string NewName { get; set; }
    public int? OriginalVersion => int.TryParse(ConcurrencyVersion, out var versionNumber) ? (int?)versionNumber : null;
  }
}