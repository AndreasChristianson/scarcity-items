namespace api.Models;

public abstract record Equipment<T>(
    Guid Id,
    Guid TemplateId,
    Guid? ParentId
  ) : GameObjectInstance<T> (
    Id,
    TemplateId,
    ParentId
    ) where T:GameObjectInstance<T>
     {
}
