namespace api.Models;

public abstract record EquipmentTemplate<T>(
  Guid Id,
  List<Slot> SlotsConsumed,
  GlomStrategy GlomStrategy,
  Uri Icon,
  string Description,
  string Name,
  double Weight,
  double Volume
) : GameObjectTemplate<T>(
  Id
  ), IDescribable, IPhysicalObject where T: GameObjectInstance<T>
{
  
}

public enum GlomStrategy
{
  BIND_ON_PICKUP,
  BIND_ON_EQUIP,
  BIND_ON_
}
