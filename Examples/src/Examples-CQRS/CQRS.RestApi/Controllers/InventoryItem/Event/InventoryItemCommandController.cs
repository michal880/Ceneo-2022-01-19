using System.Collections.Generic;
using System.Linq;
using CQRS.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.RestApi.Controllers.InventoryItem.Event
{
  [Route("api/InventoryItem/events")]
  public class InventoryItemEventController : Controller
  {
    private readonly IEventStore _eventStore;

    public InventoryItemEventController()
    {
      _eventStore = new EventStore();
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Json(_eventStore.GetAll().Select(f=> new EventDto(f)));

    }    
  }

  public class EventDto
  {
    public string Type => Event.GetType().FullName;

    public Domain.Base.Event Event { get; }

    public EventDto(Domain.Base.Event @event)
    {
      Event = @event;
    }
  }
}