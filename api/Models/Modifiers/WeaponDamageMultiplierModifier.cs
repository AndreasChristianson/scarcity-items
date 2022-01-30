namespace api.Models;
using api.GameMechanics;

public record WeaponDamageMultiplierModifier(
    Guid Id,
    Uri Icon,
    string Description,
    string Name,
    double Multiplier
  ) : WeaponModifier(
    Id,
    Icon,
    Description,
    Name
  ) {
  public override Weapon Apply(Weapon weapon) {
    return weapon;
  }
}
 