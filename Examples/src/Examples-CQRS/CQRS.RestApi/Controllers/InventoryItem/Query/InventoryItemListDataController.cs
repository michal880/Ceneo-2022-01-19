using CQRS.Finders;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.RestApi.Controllers.InventoryItem.Query
{
  [Route("api/InventoryItem")]
  public class InventoryItemListDataController : Controller
  {
    private readonly IInventoryItemListFinder _perspective;

    public InventoryItemListDataController(IInventoryItemListFinder perspective)
    {
      _perspective = perspective;
    }

    [HttpGet]
    public IActionResult GetInventoryItems()
    {
      return Json(new InventoryItemListDataCollection(_perspective.GetInventoryItems()));
    }    
  }
}