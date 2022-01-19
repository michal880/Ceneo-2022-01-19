using CQRS.Application.Base;
using CQRS.Application.Contract;
using CQRS.Domain.Base;
using CQRS.Domain.InventoryItem;

namespace CQRS.Application.Handlers
{
  public class CreateInventoryItemHandler : IHandler<ICreateInventoryItemCommand>
  {
    private readonly IRepository<InventoryItem> _repository;

    public CreateInventoryItemHandler(IRepository<InventoryItem> repository)
    {
      _repository = repository;
    }

    public void Handle(ICreateInventoryItemCommand message)
    {
      var item = new InventoryItem(message.InventoryItemId, message.Name);
      _repository.Save(item, null);
    }
  }
}