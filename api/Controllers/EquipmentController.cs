using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ItemContext _itemContext;

    public EquipmentController(ILogger<WeatherForecastController> logger, ItemContext itemContext)
    {
        _logger = logger;
        _itemContext = itemContext;
    }

    [HttpGet(Name = "GetEquipment")]
    public IEnumerable<Equipment> Get()
    {
        return _itemContext.Equipment!.ToArray();
    }
}
