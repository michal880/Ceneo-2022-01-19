using System;
using CQRS.Finders;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.RestApi.Controllers.InventoryItem.Query
{
  [Route("api/InventoryItem")]
  public class InventoryItemDetailController : Controller
  {
    private readonly IInventoryItemDetailFinder _perspective;

    public InventoryItemDetailController(IInventoryItemDetailFinder perspective)
    {
      _perspective = perspective;
    }

    [HttpGet("{id}")]
    public IActionResult GetInventoryItemDetails(Guid id)
    {
      var detailsDto = _perspective.GetInventoryItemDetails(id);
      if (detailsDto == null)
        return NotFound();

      return Json(detailsDto);
    }
  }  
}