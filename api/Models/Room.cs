namespace api.Models
{
  public record Room(
    Guid Id,
    Guid TemplateId,
    Guid? ParentId
  ) : GameObjectInstance<Room>(
    Id,
    TemplateId, 
    ParentId
    )
  {

  }
}
