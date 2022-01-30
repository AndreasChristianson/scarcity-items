namespace api.Models;

public record Weapon(
    Guid Id,
    Guid TemplateId,
    Guid? ParentId
  ) : Equipment<Weapon>(
    Id,
    TemplateId,
    ParentId 
    ) {
}
