using CQRS.Application.Base;
using CQRS.Application.Contract;
using CQRS.Domain.Base;
using CQRS.Domain.InventoryItem;

namespace CQRS.Application.Handlers
{
  public class RenameInventoryItemHandler : IHandler<IRenameInventoryItemCommand>
  {
    private readonly IRepository<InventoryItem> _repository;

    public RenameInventoryItemHandler(IRepository<InventoryItem> repository)
    {
      _repository = repository;
    }

    public void Handle(IRenameInventoryItemCommand message)
    {
      var item = _repository.GetById(message.InventoryItemId);
      item.ChangeName(message.NewName);
      _repository.Save(item, message.OriginalVersion);
    }
  }
}