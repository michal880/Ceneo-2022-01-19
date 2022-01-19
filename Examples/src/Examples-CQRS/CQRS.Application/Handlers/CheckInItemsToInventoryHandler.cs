using CQRS.Application.Base;
using CQRS.Application.Contract;
using CQRS.Domain.Base;
using CQRS.Domain.InventoryItem;

namespace CQRS.Application.Handlers
{
  public class CheckInItemsToInventoryHandler : IHandler<ICheckInItemsToInventoryCommand>
  {
    private readonly IRepository<InventoryItem> _repository;

    public CheckInItemsToInventoryHandler(IRepository<InventoryItem> repository)
    {
      _repository = repository;
    }

    public void Handle(ICheckInItemsToInventoryCommand command)
    {
      var item = _repository.GetById(command.InventoryItemId);
      item.CheckIn(command.Count);
      _repository.Save(item, null);
    }

  }
}