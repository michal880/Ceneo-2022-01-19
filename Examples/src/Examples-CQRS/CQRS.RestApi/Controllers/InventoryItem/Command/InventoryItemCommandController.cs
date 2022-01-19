using System;
using CQRS.Application.Base;
using CQRS.Application.Contract;
using CQRS.RestApi.Infrastructure;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.RestApi.Controllers.InventoryItem.Command
{
  [Route("api/InventoryItem")]
  public class InventoryItemCommandController : Controller
  {
    private readonly ICommandSender _commandSender;
    
    public InventoryItemCommandController(ICommandSender commandSender)
    {
      _commandSender = commandSender;
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateInventoryItemCommand createInventoryItem)
    {
      if (!createInventoryItem.Id.HasValue)
        createInventoryItem.Id = Guid.NewGuid();

      _commandSender.Send(createInventoryItem);
      
      return Accepted(new Uri(new Uri(
        Request.GetDisplayUrl().TrimEnd('/') + "/"),createInventoryItem.Id.ToString()));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id, [FromBody] DeactivateInventoryItemCommand deactivateInventoryItem)
    {
      deactivateInventoryItem.Id = id;
      _commandSender.Send(deactivateInventoryItem);

      return Accepted();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] RenameInventoryItemCommand renameInventoryItemCommand)
    {
      renameInventoryItemCommand.Id = id;
      _commandSender.Send(renameInventoryItemCommand);

      return Accepted();

    }

    [ModelActionSelector]
    [HttpPost("{id}")]
    public IActionResult Post(Guid id, [FromBody] CheckInItemsToInventoryCommand checkInItemsToInventory)
    {
      checkInItemsToInventory.Id = id;
      _commandSender.Send(checkInItemsToInventory);

      return Accepted();

    }

    [ModelActionSelector]
    [HttpPost("{id}")]
    public IActionResult Post(Guid id, [FromBody] RemoveItemsFromInventoryCommand removeItemsFromInventory)
    {
      removeItemsFromInventory.Id = id;
      _commandSender.Send(removeItemsFromInventory);

      return Accepted();

    }    
  }
}