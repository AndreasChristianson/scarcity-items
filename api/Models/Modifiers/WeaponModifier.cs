namespace api.Models;

public abstract record WeaponModifier (
    Guid Id,
    Uri Icon,
    string Description,
    string Name 
  ) : Modifier <Weapon>(
    Id,
    Icon,
    Description, 
    Name
  )
{
 
}
 