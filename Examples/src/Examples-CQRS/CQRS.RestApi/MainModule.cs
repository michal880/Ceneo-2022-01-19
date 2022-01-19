using Autofac;
using CQRS.Application.Base;
using CQRS.Application.Contract;
using CQRS.Application.Handlers;
using CQRS.Domain.Base;
using CQRS.Domain.InventoryItem;
using CQRS.Finders;
using CQRS.Infrastructure;
using CQRS.RestApi.Controllers.InventoryItem.Command;
using CQRS.RestApi.Infrastructure;

namespace CQRS.RestApi
{
  public class MainModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<EventStore>().AsImplementedInterfaces();
      builder.RegisterType<EventPublisher>().AsImplementedInterfaces();
      builder.RegisterType<CommandSender>().AsImplementedInterfaces();
      builder.RegisterType<InMemoryFinder>().AsImplementedInterfaces().SingleInstance();
      builder.RegisterType<DependencyResolverAdapter>().AsImplementedInterfaces();
      builder.RegisterType<CheckInItemsToInventoryHandler>().AsImplementedInterfaces();
      builder.RegisterType<CreateInventoryItemHandler>().As<IHandler<CreateInventoryItemCommand>>();
      builder.RegisterType<DeactivateInventoryItemHandler>().AsImplementedInterfaces();
      builder.RegisterType<RemoveItemsFromInventoryHandler>().AsImplementedInterfaces();
      builder.RegisterType<RenameInventoryItemHandler>().AsImplementedInterfaces();
      builder.RegisterType<Repository<InventoryItem>>().AsImplementedInterfaces();
    }
  }
}