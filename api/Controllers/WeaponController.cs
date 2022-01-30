using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("weapon")]
public class WeaponController : ControllerBase
{
  private readonly ILogger<WeaponController> _logger;
  private readonly WeaponService _service;

  public WeaponController(ILogger<WeaponController> logger, WeaponService service)
  {
    _logger = logger;
    _service = service;
  }

  [HttpGet]
  public async Task<IEnumerable<Weapon>> Get() => await _service.FindAll();

  [HttpGet("{id}")]
  public async Task<ActionResult<Weapon>> Get(Guid id)
  {
    var entity = await _service.FindById(id);
    return entity is null ? NotFound() : Ok(entity);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<Weapon>> Put(Weapon equipment)
  {

    var entity = await _service.Replace(equipment);
    return entity is null ? NotFound() : Ok(entity);
  }

  [HttpPost]
  public async Task<ActionResult<Weapon>> Post(Weapon equipment)
  {

    var entity = await _service.Create(equipment);
    return entity is null ? Conflict() : Ok(entity);
  }
  [HttpDelete("{id}")]
  public async Task<ActionResult<Weapon>> Delete(Guid id)
  {

    var entity = await _service.Remove(id);
    return entity is null ? NotFound() : Ok(entity);
  }
}
