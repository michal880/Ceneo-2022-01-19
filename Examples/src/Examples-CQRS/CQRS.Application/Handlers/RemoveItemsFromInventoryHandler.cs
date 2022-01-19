using CQRS.Application.Base;
using CQRS.Application.Contract;
using CQRS.Domain.Base;
using CQRS.Domain.InventoryItem;

namespace CQRS.Application.Handlers
{
  public class RemoveItemsFromInventoryHandler : IHandler<IRemoveItemsFromInventoryCommand>
  {
    private readonly IRepository<InventoryItem> _repository;

    public RemoveItemsFromInventoryHandler(IRepository<InventoryItem> repository)
    {
      _repository = repository;
    }

    public void Handle(IRemoveItemsFromInventoryCommand message)
    {
      var item = _repository.GetById(message.InventoryItemId);
      item.Remove(message.Count);
      _repository.Save(item, null);
    }
  }
}


