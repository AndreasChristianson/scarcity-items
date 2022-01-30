using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Database;

namespace api.Services;

public class WeaponService
{
  private readonly ILogger<WeaponService> _logger;
  private readonly PersistenceContext _dbContext;

  public WeaponService(
    ILogger<WeaponService> logger,
    PersistenceContext dbContext
    )
  {
    _logger = logger;
    _dbContext = dbContext;
  }

  public async Task<Weapon?> Replace(Weapon newEquipment)
  {
    var oldEquipment = await FindById(newEquipment.Id);
    if (
      oldEquipment is null)
    {
      return null;
    }
    _dbContext.Entry(oldEquipment).CurrentValues.SetValues(newEquipment);
    await _dbContext.SaveChangesAsync();

    return oldEquipment;
  }

  public async Task<Weapon?> FindById(Guid id) => await _dbContext.Weapons
        .Where(equipment => equipment.Id == id)
        .FirstOrDefaultAsync();

  public async Task<List<Weapon>> FindAll() => await _dbContext.Weapons
        .ToListAsync();

  public async Task<Weapon?> Remove(Guid id)
  {
    var oldEquipment = await FindById(id);
    if (oldEquipment is null)
    {
      return null;
    }
    _dbContext.Remove(oldEquipment);
    await _dbContext.SaveChangesAsync();
    return oldEquipment;
  }

  public async Task<Weapon?> Create(Weapon newEquipment)
  {
    var existingEquipment = await FindById(newEquipment.Id);
    if (existingEquipment is null)
    {
      return null;
    }
    var createdEquipment = await _dbContext.AddAsync(newEquipment);
    await _dbContext.SaveChangesAsync();

    return createdEquipment.Entity;
  }
}
