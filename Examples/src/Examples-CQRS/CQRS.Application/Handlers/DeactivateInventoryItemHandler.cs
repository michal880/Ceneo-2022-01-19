using CQRS.Application.Base;
using CQRS.Application.Contract;
using CQRS.Domain.Base;
using CQRS.Domain.InventoryItem;

namespace CQRS.Application.Handlers
{
  public class DeactivateInventoryItemHandler : IHandler<IDeactivateInventoryItemCommand>
  {
    private readonly IRepository<InventoryItem> _repository;

    public DeactivateInventoryItemHandler(IRepository<InventoryItem> repository)
    {
      _repository = repository;
    }

    public void Handle(IDeactivateInventoryItemCommand message)
    {
      var item = _repository.GetById(message.InventoryItemId);
      item.Deactivate();
      _repository.Save(item, message.OriginalVersion);
    }
  }
}