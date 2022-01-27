using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("equipment")]
public class EquipmentController : ControllerBase {
  private readonly ILogger<EquipmentController> _logger;
  private readonly ItemContext _itemContext;

  public EquipmentController(ILogger<EquipmentController> logger, ItemContext itemContext) {
    _logger = logger;
    _itemContext = itemContext;
  }

  [HttpGet]
  public IEnumerable<Equipment> Get() {
    return _itemContext.Equipment.ToArray();
  }
  [HttpGet("{id}")]
  public Equipment? Get(Guid id) {
    _logger.LogCritical($"getting by id ({id})!");
    return _itemContext.Equipment
      .Where(equipment => equipment.Id == id)
      .SingleOrDefault();
  }
}
