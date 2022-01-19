using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CQRS.Domain;
using CQRS.Domain.Base;
using CQRS.Domain.InventoryItem;
using CQRS.Infrastructure;

namespace CQRS.Finders
{
  public class InMemoryFinder : IInventoryItemDetailFinder, IInventoryItemListFinder
  {
    private readonly List<InventoryItemDetail> List = new List<InventoryItemDetail>();

    public InMemoryFinder(IEventStore eventStore, IEventPublisher eventPublisher)
    {
      Initialize(eventStore.GetAll());
      ConfigureListeners(eventPublisher);
    }

    private void ConfigureListeners(IEventPublisher eventPublisher)
    {
      eventPublisher.RegisterHandler<InventoryItemCreated>(Handle);
      eventPublisher.RegisterHandler<InventoryItemRenamed>(Handle);
      eventPublisher.RegisterHandler<InventoryItemDeactivated>(Handle);
      eventPublisher.RegisterHandler<ItemsCheckedInToInventory>(Handle);
      eventPublisher.RegisterHandler<ItemsRemovedFromInventory>(Handle);
    }

    private void Initialize(IEnumerable<Event> events)
    {
      foreach (var @event in events)
      {
        this.AsDynamic().Handle(@event);
      }
    }

    public InventoryItemDetail GetInventoryItemDetails(Guid id)
    {
      return List.First(x => x.Id == id);
    }

    public IEnumerable<InventoryItemList> GetInventoryItems()
    {
      return List.Select(f => new InventoryItemList(f.Id, f.Name));
    }

    public void Handle(InventoryItemCreated obj)
    {
      List.Add(new InventoryItemDetail(obj.Id, obj.Name, 0));
    }

    public void Handle(InventoryItemDeactivated obj)
    {
      List.Remove(List.First(f => f.Id == obj.Id));
    }

    public void Handle(InventoryItemRenamed obj)
    {
      List.First(f => f.Id == obj.Id).Name = obj.NewName;
    }

    public void Handle(ItemsCheckedInToInventory obj)
    {
      List.First(f => f.Id == obj.Id).CurrentCount++;
    }

    public void Handle(ItemsRemovedFromInventory obj)
    {
      List.First(f => f.Id == obj.Id).CurrentCount--;
    }


  }
}
