namespace api.Models;

public record WeaponTemplate(
  Guid Id,
  List<Slot> SlotsConsumed,
  GlomStrategy GlomStrategy,
  Uri Icon,
  string Description,
  string Name,
  double Weight,
  double Volume,
  double BaseDamagePerTurn,
  double AttackDelay
) : EquipmentTemplate<Weapon>(
  Id,
  SlotsConsumed,
  GlomStrategy,
  Icon, 
  Description,
  Name,
  Weight,
  Volume
  )
{
}
